#include <iostream>
#include <cstdio>
#include <cstring>
#include <cmath>
#include <process.h>
#include "Winsock2.h"
#include "Ws2tcpip.h"
#include "time.h"
#include "ServerU.h"

#pragma comment(lib, "WS2_32.lib")

using namespace std;

struct SETSINCRO//запрос клиента на синхронизацию счетчика времени
{
	char cmd[16]; //значения SINC
	int correction; //текущее значение счетчика времени
};

// SNTP/NTP (RFC 4330)

// NTP timestamp: секунды с 1 января 1900 года
// Разница между эпохой NTP (1900) и эпохой Unix (1970) в секундах
#define NTP_EPOCH_DIFF 2208988800ULL

// Структура NTP-пакета (48 байт)
#pragma pack(push, 1)
struct NTPPacket
{
	unsigned char li_vn_mode;      // LI (2 бит), VN (3 бит), Mode (3 бит)
	unsigned char stratum;         // уровень сервера (1 = первичный)
	unsigned char poll;            // интервал опроса
	unsigned char precision;       // точность часов
	unsigned int rootDelay;        // задержка до корневого сервера
	unsigned int rootDispersion;   // дисперсия корневого сервера
	unsigned int refId;            // идентификатор источника
	unsigned int refTm_s;          // Reference Timestamp - секунды
	unsigned int refTm_f;          // Reference Timestamp - дробная часть
	unsigned int origTm_s;         // Originate Timestamp (T1) - секунды
	unsigned int origTm_f;         // Originate Timestamp (T1) - дробная часть
	unsigned int rxTm_s;           // Receive Timestamp (T2) - секунды
	unsigned int rxTm_f;           // Receive Timestamp (T2) - дробная часть
	unsigned int txTm_s;           // Transmit Timestamp (T3) - секунды
	unsigned int txTm_f;           // Transmit Timestamp (T3) - дробная часть
};
#pragma pack(pop)

// Получить текущее время как NTP timestamp (секунды с 1900 + дробная часть)
void getCurrentNTPTime(unsigned int& seconds, unsigned int& fraction)
{
	FILETIME ft;
	GetSystemTimeAsFileTime(&ft);
	// FILETIME = 100-наносекундные интервалы с 1 января 1601
	ULARGE_INTEGER uli;
	memcpy(&uli, &ft, sizeof(uli));
	// Разница между 1601 и 1900 в 100-нс интервалах
	// 1 января 1900 - 1 января 1601 = 299 лет (с учётом високосных)
	// = 9435484800 секунд = 94354848000000000 * 100нс
	ULONGLONG epoch1601to1900 = 94354848000000000ULL;
	ULONGLONG ntpTime100ns = uli.QuadPart - epoch1601to1900;
	seconds = (unsigned int)(ntpTime100ns / 10000000ULL);
	// Дробная часть: остаток в 100-нс интервалах -> доля от 2^32
	ULONGLONG remainder = ntpTime100ns % 10000000ULL;
	fraction = (unsigned int)((remainder * 4294967296ULL) / 10000000ULL);
}

// Конвертация NTP timestamp в SYSTEMTIME
SYSTEMTIME ntpToSystemTime(unsigned int ntpSeconds, unsigned int ntpFraction)
{
	// NTP секунды с 1900 -> FILETIME (100-нс с 1601)
	ULONGLONG epoch1601to1900 = 94354848000000000ULL;
	ULONGLONG ntpTime100ns = (ULONGLONG)ntpSeconds * 10000000ULL
		+ (ULONGLONG)ntpFraction * 10000000ULL / 4294967296ULL;
	ULONGLONG fileTime = ntpTime100ns + epoch1601to1900;

	ULARGE_INTEGER uli2;
	uli2.QuadPart = fileTime;
	FILETIME ft;
	memcpy(&ft, &uli2, sizeof(ft));

	SYSTEMTIME st;
	FileTimeToSystemTime(&ft, &st);
	return st;
}

// Вычисление разницы двух NTP timestamp в миллисекундах (a - b)
double ntpDiffMs(unsigned int a_s, unsigned int a_f, unsigned int b_s, unsigned int b_f)
{
	double a = (double)a_s + (double)a_f / 4294967296.0;
	double b = (double)b_s + (double)b_f / 4294967296.0;
	return (a - b) * 1000.0; // в миллисекундах
}

// Синхронизация с глобальным NTP-сервером (10 экспериментов)
void syncWithNTP()
{
	const char* ntpServer = "pool.ntp.org";
	const int ntpPort = 123;
	const int experiments = 10;

	cout << "Синхронизация с NTP-сервером (" << ntpServer << ")" << endl;

	// Разрешение имени NTP-сервера
	struct addrinfo hints, *result = NULL;
	ZeroMemory(&hints, sizeof(hints));
	hints.ai_family = AF_INET;
	hints.ai_socktype = SOCK_DGRAM;
	hints.ai_protocol = IPPROTO_UDP;

	if (getaddrinfo(ntpServer, "123", &hints, &result) != 0)
	{
		cout << "Ошибка: не удалось разрешить адрес " << ntpServer << endl;
		return;
	}

	SOCKET ntpSocket = socket(AF_INET, SOCK_DGRAM, IPPROTO_UDP);
	if (ntpSocket == INVALID_SOCKET)
	{
		cout << "Ошибка создания NTP-сокета" << endl;
		freeaddrinfo(result);
		return;
	}

	// Таймаут на приём — 5 секунд
	int timeout = 5000;
	setsockopt(ntpSocket, SOL_SOCKET, SO_RCVTIMEO, (char*)&timeout, sizeof(timeout));

	double offsets[10] = { 0 };
	double delays[10] = { 0 };
	double maxOffset = 0, minOffset = 1e18, avgOffset = 0;
	double maxDelay = 0, minDelay = 1e18, avgDelay = 0;
	int successCount = 0;

	for (int i = 0; i < experiments; i++)
	{
		cout << endl << "--- Эксперимент " << (i + 1) << " ---" << endl;

		// Формирование NTP-запроса
		NTPPacket packet;
		ZeroMemory(&packet, sizeof(packet));
		// LI = 0 (no warning), VN = 4 (NTPv4), Mode = 3 (client)
		packet.li_vn_mode = (0 << 6) | (4 << 3) | 3;

		// T1 — время отправки запроса (Originate Timestamp)
		unsigned int T1_s, T1_f;
		getCurrentNTPTime(T1_s, T1_f);
		packet.origTm_s = htonl(T1_s);
		packet.origTm_f = htonl(T1_f);

		SYSTEMTIME tmBefore;
		GetSystemTime(&tmBefore);
		cout << "Локальное время до: " << tmBefore.wHour << ":" << tmBefore.wMinute << ":"
			<< tmBefore.wSecond << "." << tmBefore.wMilliseconds << endl;

		// Отправка запроса на NTP-сервер
		int sent = sendto(ntpSocket, (char*)&packet, sizeof(packet), 0,
			result->ai_addr, (int)result->ai_addrlen);
		if (sent == SOCKET_ERROR)
		{
			cout << "Ошибка отправки NTP-запроса: " << WSAGetLastError() << endl;
			Sleep(1000);
			continue;
		}

		// Получение ответа
		NTPPacket response;
		ZeroMemory(&response, sizeof(response));
		int fromLen = (int)result->ai_addrlen;
		int received = recvfrom(ntpSocket, (char*)&response, sizeof(response), 0,
			result->ai_addr, &fromLen);

		// T4 — время получения ответа (Destination Timestamp)
		unsigned int T4_s, T4_f;
		getCurrentNTPTime(T4_s, T4_f);

		if (received == SOCKET_ERROR)
		{
			cout << "Ошибка приёма NTP-ответа (таймаут или сетевая ошибка): " << WSAGetLastError() << endl;
			Sleep(1000);
			continue;
		}

		// Извлечение T2 (Receive Timestamp) и T3 (Transmit Timestamp) из ответа
		unsigned int T2_s = ntohl(response.rxTm_s);
		unsigned int T2_f = ntohl(response.rxTm_f);
		unsigned int T3_s = ntohl(response.txTm_s);
		unsigned int T3_f = ntohl(response.txTm_f);

		// Вычисление offset и delay по формулам NTP:
		// offset = ((T2 - T1) + (T3 - T4)) / 2
		// delay  = (T4 - T1) - (T3 - T2)
		double t2_t1 = ntpDiffMs(T2_s, T2_f, T1_s, T1_f);
		double t3_t4 = ntpDiffMs(T3_s, T3_f, T4_s, T4_f);
		double t4_t1 = ntpDiffMs(T4_s, T4_f, T1_s, T1_f);
		double t3_t2 = ntpDiffMs(T3_s, T3_f, T2_s, T2_f);

		double offset = (t2_t1 + t3_t4) / 2.0;
		double delay = t4_t1 - t3_t2;

		offsets[i] = offset;
		delays[i] = delay;

		// Серверное время из Transmit Timestamp
		SYSTEMTIME ntpTime = ntpToSystemTime(T3_s, T3_f);

		cout << "Время NTP-сервера: " << ntpTime.wHour << ":" << ntpTime.wMinute << ":"
			<< ntpTime.wSecond << "." << ntpTime.wMilliseconds << endl;
		cout << "Offset = " << offset << " мс, Delay = " << delay << " мс" << endl;
		cout << "Stratum = " << (int)response.stratum << endl;

		// Статистика
		if (fabs(offset) > fabs(maxOffset)) maxOffset = offset;
		if (fabs(offset) < fabs(minOffset)) minOffset = offset;
		if (delay > maxDelay) maxDelay = delay;
		if (delay < minDelay) minDelay = delay;
		avgOffset += offset;
		avgDelay += delay;
		successCount++;

		// Корректировка системных часов (после последнего эксперимента)
		if (i == experiments - 1 && successCount > 0)
		{
			// Получаем текущее системное время и прибавляем offset
			FILETIME ft;
			GetSystemTimeAsFileTime(&ft);
			ULARGE_INTEGER uli;
			memcpy(&uli, &ft, sizeof(uli));

			// offset в миллисекундах -> в 100-наносекундных интервалах
			double avgOff = avgOffset / successCount;
			LONGLONG correction100ns = (LONGLONG)(avgOff * 10000.0);
			uli.QuadPart += correction100ns;

			memcpy(&ft, &uli, sizeof(ft));

			SYSTEMTIME correctedTime;
			FileTimeToSystemTime(&ft, &correctedTime);

			if (SetSystemTime(&correctedTime))
			{
				cout << endl << "Системные часы скорректированы на " << avgOff << " мс" << endl;
				cout << "Новое системное время: " << correctedTime.wHour << ":" << correctedTime.wMinute
					<< ":" << correctedTime.wSecond << "." << correctedTime.wMilliseconds << endl;
			}
			else
			{
				cout << endl << "Не удалось установить системное время (требуются права администратора)" << endl;
			}
		}

		Sleep(1000); // пауза между экспериментами
	}

	// Итоговая статистика
	if (successCount > 0)
	{
		avgOffset /= successCount;
		avgDelay /= successCount;
		cout << endl << "Итоги NTP-синхронизации" << endl;
		cout << "Успешных экспериментов: " << successCount << " из " << experiments << endl;
		cout << "Средний offset: " << avgOffset << " мс" << endl;
		cout << "Средний delay:  " << avgDelay << " мс" << endl;
		cout << "Max offset: " << maxOffset << " мс, Min offset: " << minOffset << " мс" << endl;
		cout << "Max delay:  " << maxDelay << " мс, Min delay:  " << minDelay << " мс" << endl;
	}

	closesocket(ntpSocket);
	freeaddrinfo(result);
}

//Конец SNTP/NTP

string GetErrorMsgText(int code)
{
	string msgText;

	switch (code)
	{
	case WSAEINTR:				 msgText = "Работа функции прервана\n";						  break;
	case WSAEACCES:				 msgText = "Разрешение отвергнуто\n";						  break;
	case WSAEFAULT:				 msgText = "Ошибочный адрес\n";								  break;
	case WSAEINVAL:				 msgText = "Ошибка в аргументе\n";							  break;
	case WSAEMFILE:				 msgText = "Слишком много файлов открыто\n";				  break;
	case WSAEWOULDBLOCK:		 msgText = "Ресурс временно недоступен\n";					  break;
	case WSAEINPROGRESS:		 msgText = "Операция в процессе развития\n";				  break;
	case WSAEALREADY: 			 msgText = "Операция уже выполняется\n";					  break;
	case WSAENOTSOCK:   		 msgText = "Сокет задан неправильно\n";						  break;
	case WSAEDESTADDRREQ:		 msgText = "Требуется адрес расположения\n";				  break;
	case WSAEMSGSIZE:  			 msgText = "Сообщение слишком длинное\n";				      break;
	case WSAEPROTOTYPE:			 msgText = "Неправильный тип протокола для сокета\n";		  break;
	case WSAENOPROTOOPT:		 msgText = "Ошибка в опции протокола\n";					  break;
	case WSAEPROTONOSUPPORT:	 msgText = "Протокол не поддерживается\n";					  break;
	case WSAESOCKTNOSUPPORT:	 msgText = "Тип сокета не поддерживается\n";				  break;
	case WSAEOPNOTSUPP:			 msgText = "Операция не поддерживается\n";					  break;
	case WSAEPFNOSUPPORT:		 msgText = "Тип протоколов не поддерживается\n";			  break;
	case WSAEAFNOSUPPORT:		 msgText = "Тип адресов не поддерживается протоколом\n";	  break;
	case WSAEADDRINUSE:			 msgText = "Адрес уже используется\n";						  break;
	case WSAEADDRNOTAVAIL:		 msgText = "Запрошенный адрес не может быть использован\n";	  break;
	case WSAENETDOWN:			 msgText = "Сеть отключена\n";								  break;
	case WSAENETUNREACH:		 msgText = "Сеть не достижима\n";							  break;
	case WSAENETRESET:			 msgText = "Сеть разорвала соединение\n";					  break;
	case WSAECONNABORTED:		 msgText = "Программный отказ связи\n";						  break;
	case WSAECONNRESET:			 msgText = "Связь восстановлена\n";							  break;
	case WSAENOBUFS:			 msgText = "Не хватает памяти для буферов\n";				  break;
	case WSAEISCONN:			 msgText = "Сокет уже подключен\n";							  break;
	case WSAENOTCONN:			 msgText = "Сокет не подключен\n";							  break;
	case WSAESHUTDOWN:			 msgText = "Нельзя выполнить send: сокет завершил работу\n";  break;
	case WSAETIMEDOUT:			 msgText = "Закончился отведенный интервал  времени\n";		  break;
	case WSAECONNREFUSED:		 msgText = "Соединение отклонено\n";						  break;
	case WSAEHOSTDOWN:			 msgText = "Хост в неработоспособном состоянии\n";			  break;
	case WSAEHOSTUNREACH:		 msgText = "Нет маршрута для хоста\n";						  break;
	case WSAEPROCLIM:			 msgText = "Слишком много процессов\n";						  break;
	case WSASYSNOTREADY:		 msgText = "Сеть не доступна\n";							  break;
	case WSAVERNOTSUPPORTED:	 msgText = "Данная версия недоступна\n";					  break;
	case WSANOTINITIALISED:		 msgText = "Не выполнена инициализация WS2_32.DLL\n";		  break;
	case WSAEDISCON:			 msgText = "Выполняется отключение\n";						  break;
	case WSATYPE_NOT_FOUND:		 msgText = "Класс не найден\n";								  break;
	case WSAHOST_NOT_FOUND:		 msgText = "Хост не найден\n";								  break;
	case WSATRY_AGAIN:			 msgText = "Неавторизированный хост не найден\n";			  break;
	case WSANO_RECOVERY:		 msgText = "Неопределенная ошибка\n";						  break;
	case WSANO_DATA:			 msgText = "Нет записи запрошенного типа\n";				  break;
	case WSA_INVALID_HANDLE:	 msgText = "Указанный дескриптор события  с ошибкой\n";		  break;
	case WSA_INVALID_PARAMETER:	 msgText = "Один или более параметров с ошибкой\n";			  break;
	case WSA_IO_INCOMPLETE:		 msgText = "Объект ввода-вывода не в сигнальном состоянии\n"; break;
	case WSA_IO_PENDING:		 msgText = "Операция завершится позже\n";					  break;
	case WSA_NOT_ENOUGH_MEMORY:	 msgText = "Не достаточно памяти\n";						  break;
	case WSA_OPERATION_ABORTED:	 msgText = "Операция отвергнута\n";							  break;
	case WSAEINVALIDPROCTABLE:	 msgText = "Ошибочный сервис\n";							  break;
	case WSAEINVALIDPROVIDER:	 msgText = "Ошибка в версии сервиса\n";						  break;
	case WSAEPROVIDERFAILEDINIT: msgText = "Невозможно инициализировать сервис\n";			  break;
	case WSASYSCALLFAILURE:		 msgText = "Аварийное завершение системного вызова\n";		  break;
	default:					 msgText = "Error\n";										  break;
	};

	return msgText;
}

string SetErrorMsgText(string msgText, int code)
{
	return  msgText + GetErrorMsgText(code);
};

//реализация нахождения средней коррекции
int setAverageCorrection(int averageCorrection[], int length)
{
	int sum = 0;
	for (int i = 0; i < length; i++)
	{
		sum += averageCorrection[i];
	}
	return sum / length;
}

// Параметры для потока обработки клиента
struct ClientThreadParams
{
	SOCKET serverSocket;
	SETSINCRO getsincro;
	SOCKADDR_IN clientAddr;
	int clientAddrLen;
	int* pCount;
	int* averageCorrection;
	clock_t startTime;
};

// Функция потока для параллельной обработки клиентских запросов
void __cdecl ClientHandler(void* params)
{
	ClientThreadParams* p = (ClientThreadParams*)params;

	SYSTEMTIME tm;
	GetSystemTime(&tm);//получение системного времени

	clock_t c = clock();//отсчет времени

	SETSINCRO setsincro;
	ZeroMemory(&setsincro, sizeof(setsincro));
	strcpy_s(setsincro.cmd, "SINCRO");//начальная установка из структуры

	int count = *(p->pCount);

	//реализация получения значения коррекции
	setsincro.correction = (int)(c - p->startTime) - p->getsincro.correction;

	//реализация получения значения средней коррекции в одном эксперименте
	p->averageCorrection[count - 1] = setsincro.correction;

	//реализация получения значения средней коррекции за все эксперименты
	int average = setAverageCorrection(p->averageCorrection, count);

	sendto(p->serverSocket, (char*)&setsincro, sizeof(setsincro), 0,
		(sockaddr*)&p->clientAddr, sizeof(p->clientAddr));

	//нахождение адреса клиента
	char clientIP[INET_ADDRSTRLEN];
	inet_ntop(AF_INET, &p->clientAddr.sin_addr, clientIP, INET_ADDRSTRLEN);

	cout << endl << count << "." << " Date and time " << tm.wMonth << "/" << tm.wDay << "/" << tm.wYear
		<< " " << endl << tm.wHour << " Hours " << tm.wMinute << " Minutes " << tm.wSecond
		<< " Seconds " << tm.wMilliseconds << " Milliseconds " << endl << "Correction = " << setsincro.correction
		<< ", Average correction = " << average << endl;
	cout << "Client's adress " << clientIP << ":" << ntohs(p->clientAddr.sin_port) << endl;

	(*(p->pCount))++;

	delete p;
}

int main()
{
	SetConsoleOutputCP(CP_UTF8);
	SetConsoleCP(CP_UTF8);
	setvbuf(stdout, nullptr, _IONBF, 0);
	setvbuf(stderr, nullptr, _IONBF, 0);

	cout << "Сервер запущен" << endl;

	try
	{
		SOCKET sS;
		WSADATA wsaData;

		if (WSAStartup(MAKEWORD(2, 0), &wsaData) != 0)
			throw SetErrorMsgText("Startup: ", WSAGetLastError());

		if ((sS = socket(AF_INET, SOCK_DGRAM, NULL)) == INVALID_SOCKET)
			throw SetErrorMsgText("Socket: ", WSAGetLastError());

		SOCKADDR_IN serv;
		serv.sin_family = AF_INET;
		serv.sin_port = htons(2000);
		serv.sin_addr.s_addr = INADDR_ANY;

		if (bind(sS, (LPSOCKADDR)&serv, sizeof(serv)) == SOCKET_ERROR)
			throw SetErrorMsgText("Bind_Server: ", WSAGetLastError());

		// Синхронизация с глобальным NTP-сервером (10 экспериментов)
		syncWithNTP();

		cout << "Сервер готов к обслуживанию клиентов..." << endl;

		int count = 1;//какой по счету эксперимент
		int averageCorrection[50];//значение средней коррекции
		ZeroMemory(averageCorrection, sizeof(averageCorrection));
		clock_t startTime = clock();//время работы сервера с момента запуска

		while (true)
		{
			SETSINCRO getsincro;
			ZeroMemory(&getsincro, sizeof(getsincro));
			SOCKADDR_IN client;
			int lc = sizeof(client);

			recvfrom(sS, (char*)&getsincro, sizeof(getsincro), 0, (sockaddr*)&client, &lc);

			// Создаём параметры для потока
			ClientThreadParams* params = new ClientThreadParams;
			params->serverSocket = sS;
			params->getsincro = getsincro;
			params->clientAddr = client;
			params->clientAddrLen = lc;
			params->pCount = &count;
			params->averageCorrection = averageCorrection;
			params->startTime = startTime;

			// Запускаем поток для параллельной обработки клиента
			_beginthread(ClientHandler, 0, params);
		}

		if (closesocket(sS) == SOCKET_ERROR)
			throw SetErrorMsgText("close socket: ", WSAGetLastError());
		if (WSACleanup() == SOCKET_ERROR)
			throw SetErrorMsgText("Cleanup: ", WSAGetLastError());
	}
	catch (string errorMsgText)
	{
		cout << endl << errorMsgText;
	}

	return 0;
}
