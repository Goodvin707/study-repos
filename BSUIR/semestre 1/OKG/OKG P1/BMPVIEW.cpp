//------------------------------------------------------
//	Файл:		BMPVIEW.CPP
//	Описание:	Демонстрирует работу с растрами
//------------------------------------------------------


#define STRICT
#define WIN32_LEAN_AND_MEAN 

#include <windows.h>
#include <windowsx.h>
#include <stdlib.h>
#include <time.h>
#include <math.h>
#include <string.h>
#include "bmpview.h"
#include <iostream>

//Объекты контекста в памяти и шрифт
HDC	hMemDC;
HBITMAP hMemBitmap;
HFONT	hInfoFont;

//Два цвета для надписей
COLORREF crFontColor1;
COLORREF crFontColor2;

//Имя выводимого растра
const char* szFileName = "Airplane.bmp";
LPCWSTR LszFileName = L"Airplane.bmp";

//Ширина и высота экрана
UINT	nScreenX;
UINT	nScreenY;

//Реальные ширина и высота картинки
UINT	nBmpWidth;
UINT	nBmpHeight;

//Ширина и высота картинки при выводе
UINT	nVBmpWidth;
UINT	nVBmpHeight;

//Отступ сверху для надписи
UINT	nTopDown = 100;



int WINAPI WinMain(HINSTANCE hInst, HINSTANCE hPrevInst, LPSTR lpszCmdLine, int nCmdShow)
{
	WNDCLASSEX wndClass;
	HWND hWnd;
	MSG msg;


	nScreenX = GetSystemMetrics(SM_CXSCREEN);
	nScreenY = GetSystemMetrics(SM_CYSCREEN);

	//Регистрация оконного класса
	wndClass.cbSize = sizeof(wndClass);
	wndClass.style = CS_HREDRAW | CS_VREDRAW;
	wndClass.lpfnWndProc = WndProc;
	wndClass.cbClsExtra = 0;
	wndClass.cbWndExtra = 0;
	wndClass.hInstance = hInst;
	wndClass.hIcon = LoadIcon(NULL, IDI_WINLOGO);
	wndClass.hCursor = LoadCursor(NULL, IDC_ARROW);
	wndClass.hbrBackground = GetStockBrush(BLACK_BRUSH);
	wndClass.lpszMenuName = NULL;
	wndClass.lpszClassName = szClassName;
	wndClass.hIconSm = LoadIcon(NULL, IDI_WINLOGO);


	RegisterClassEx(&wndClass);

	//Создание окна на основе класса
	hWnd = CreateWindowEx(
		WS_EX_LEFT,	//Дополнит. стиль окна
		szClassName,	//Класс окна
		szAppName,	//Текст заголовка
		WS_POPUP,	//Стиль окна
		0, 0,		//Координаты X и Y
		nScreenX, nScreenY,	//Ширина и высота
		NULL,		//Дескриптор родит. окна
		NULL,		//Дескриптор меню
		hInst,		//Описатель экземпляра
		NULL);		//Дополнит. данные

	ShowWindow(hWnd, nCmdShow);
	UpdateWindow(hWnd);

	//Главный цикл программы
	while (TRUE)
	{
		if (PeekMessage(&msg, NULL, 0, 0, PM_REMOVE))
		{
			if (msg.message == WM_QUIT)
				break;

			TranslateMessage(&msg);
			DispatchMessage(&msg);
		}
		else
			BMP_OnIdle(hWnd);
	}
	return (msg.wParam);
}


/////////////////////////////////////////////////
//	Оконная процедура
////////////////////////////////////////////////

LRESULT CALLBACK WndProc(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
	switch (msg)
	{
		HANDLE_MSG(hWnd, WM_CREATE, BMP_OnCreate);
		HANDLE_MSG(hWnd, WM_DESTROY, BMP_OnDestroy);
		HANDLE_MSG(hWnd, WM_TIMER, BMP_OnTimer);
		HANDLE_MSG(hWnd, WM_KEYDOWN, BMP_OnKey);
	default:
		return DefWindowProc(hWnd, msg, wParam, lParam);
	}
}

/* Обработчики сообщений */

BOOL BMP_OnCreate(HWND hwnd, LPCREATESTRUCT lpCreateStruct)
{

	HDC	hTempDC;

	//Получаем контекст Рабочего стола
	hTempDC = GetDC(HWND_DESKTOP);

	//Создаём контекст в памяти и растр, совместимые с экраном
	hMemDC = CreateCompatibleDC(hTempDC);
	hMemBitmap = CreateCompatibleBitmap(hTempDC, nScreenX, nScreenY);

	//Заливаем содержимое контекста черным цветом
	SelectBitmap(hMemDC, hMemBitmap);
	SelectBrush(hMemDC, GetStockBrush(BLACK_BRUSH));
	PatBlt(hMemDC, 0, 0, nScreenX, nScreenY, PATCOPY);

	//Копируем картинку в контекст памяти
	if (!LoadBMP(hMemDC, LszFileName))
	{
		MessageBox(hwnd, L"Не найден файл", L"Ошибка", MB_OK | MB_ICONSTOP);
		return (FALSE);
	}

	//Освобождаем временный контекст
	ReleaseDC(HWND_DESKTOP, hTempDC);

	//Создаём шрифт и переменные для цветов шрифта
	hInfoFont = CreateFont(22, 0, 0, 0, FW_NORMAL, FALSE, FALSE, FALSE,
		ANSI_CHARSET, OUT_DEFAULT_PRECIS, CLIP_DEFAULT_PRECIS,
		DEFAULT_QUALITY, VARIABLE_PITCH, L"Courier New");

	crFontColor1 = RGB(255, 0, 0);
	crFontColor2 = RGB(0, 255, 0);

	//Выбираем цвет шрифта
	SetTextColor(hMemDC, crFontColor1);

	//Рисуем текст в контексте памяти
	ShowText();

	//Устанавливаем таймер
	if (!SetTimer(hwnd, TIMER_ID, TIMER_RATE, NULL))
		return (FALSE);
	return (TRUE);
}

//-----------------------------------------------------------------

void BMP_OnDestroy(HWND hwnd)
{
	//Убираем после себя
	KillTimer(hwnd, TIMER_ID);
	DeleteDC(hMemDC);
	DeleteBitmap(hMemBitmap);
	DeleteFont(hInfoFont);
	PostQuitMessage(0);
}

//-----------------------------------------------------------------

void BMP_OnTimer(HWND hwnd, UINT id)
{
	//Рисуем текст в контексте памяти
	ShowText();
}

//-----------------------------------------------------------------

void BMP_OnIdle(HWND hwnd)
{
	HDC	hWindowDC;
	//Получаем контекст окна, копируем в него содержимое
	//контекста памяти, освобождаем контекст окна
	hWindowDC = GetDC(hwnd);
	BitBlt(hWindowDC, 0, 0, nScreenX, nScreenY, hMemDC, 0, 0, SRCCOPY);
	ReleaseDC(hwnd, hWindowDC);
}

//-----------------------------------------------------------------

void BMP_OnKey(HWND hwnd, UINT vk, BOOL fDown, int cRepeat, UINT flags)
{
	//При нажатии пробела - прекратить программу
	if (vk == VK_SPACE)
		DestroyWindow(hwnd);
}

//-------------------------------------------------------------------

/* Копирует содержимое файла BMP в контекст устройства */

BOOL LoadBMP(HDC hdc, LPCWSTR szFileName)
{
	BYTE* pBmp;
	DWORD dwBmpSize;
	DWORD dwFileLength;
	DWORD dwBytesRead;

	BITMAPFILEHEADER BmpHeader;
	BITMAPINFO* pBmpInfo;
	BYTE* pPixels;

	//Пытаемся открыть файл
	HANDLE hFile = CreateFile(szFileName, GENERIC_READ, FILE_SHARE_READ, NULL, OPEN_EXISTING, 0, NULL);

	if (hFile == INVALID_HANDLE_VALUE)
		return (FALSE);

	//Определяем размер данных, которые необходимо загрузить
	dwFileLength = GetFileSize(hFile, NULL);
	dwBmpSize = dwFileLength - sizeof(BITMAPFILEHEADER);

	//Выделяем память и считываем данные
	pBmp = (BYTE*)malloc(dwBmpSize);
	ReadFile(hFile, &BmpHeader, sizeof(BmpHeader), &dwBytesRead, NULL);
	ReadFile(hFile, (LPVOID)pBmp, dwBmpSize, &dwBytesRead, NULL);
	CloseHandle(hFile);

	//Инициализируем указатели на информацию о картинке
	//и на графические данные
	pBmpInfo = (BITMAPINFO*)pBmp;
	pPixels = pBmp + BmpHeader.bfOffBits - sizeof(BITMAPFILEHEADER);

	//Получаем ширину и высоту картинки
	nBmpHeight = pBmpInfo->bmiHeader.biHeight;
	nBmpWidth = pBmpInfo->bmiHeader.biWidth;

	//Вычистляем ширину и высоту картинки для вывода на экран
	nVBmpHeight = nScreenY - nTopDown * 2;
	nVBmpWidth = (UINT)((double)nBmpWidth * (double)nVBmpHeight / (double)nBmpHeight);
	if (nVBmpWidth > nScreenX)
		nVBmpWidth = nScreenX;


	//Устанавливаем режим масштабирования
	SetStretchBltMode(hdc, HALFTONE);

	//Копируем картинку в контекст памяти
	StretchDIBits(hdc, (nScreenX - nVBmpWidth) / 2, nTopDown, nVBmpWidth, nVBmpHeight, 0, 0, nBmpWidth, nBmpHeight, pPixels, pBmpInfo, 0, SRCCOPY);

	//Освобождаем память
	free(pBmp);
	return (TRUE);
}

/* Меняет текущий цвет шрифта и выводит текст в контекст памяти*/
void ShowText()
{
	HFONT	hOldFont;
	RECT	rTextRect;
	char	szInfoText[300] = "Выполнил: Сушко Алексей | Группа: 381574\nДействительная ширина: %d, Действительная высота: %d\nВиртуальная ширина: %d, Виртуальная высота: %d";
	LPCWSTR LszInfoText = L"Выполнил: Сушко Алексей | Группа: 381574\nДействительная ширина: %d, Действительная высота: %d\nВиртуальная ширина: %d, Виртуальная высота: %d";
	int		szInfoTextLen = strlen(szInfoText);

	//Определяем текущий цвет шрифта
	if (GetTextColor(hMemDC) == crFontColor1)
		SetTextColor(hMemDC, crFontColor2);
	else
		SetTextColor(hMemDC, crFontColor1);

	//Производим настройки...
	SetBkMode(hMemDC, TRANSPARENT);
	hOldFont = SelectFont(hMemDC, hInfoFont);

	//...и выводим текст.
	SetRect(&rTextRect, 0, 0, nScreenX, nTopDown);
	DrawText(hMemDC, LszFileName, strlen(szFileName) + 1, &rTextRect, DT_SINGLELINE | DT_CENTER | DT_VCENTER);

	wsprintf((LPWSTR)szInfoText, LszInfoText, nBmpWidth, nBmpHeight, nVBmpWidth, nVBmpHeight);
	
	SetRect(&rTextRect, 0, nScreenY - nTopDown, nScreenX, nScreenY);
	DrawText(hMemDC, (LPCWSTR)szInfoText, szInfoTextLen + 6, &rTextRect, DT_CENTER);

	SelectFont(hMemDC, hOldFont);
}