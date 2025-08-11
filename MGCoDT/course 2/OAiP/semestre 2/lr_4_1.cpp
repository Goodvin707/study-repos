/*Задание 1: Разработать перечисленные ниже классы. При разработке каждого класса возможны два варианта решения: 
а) данные-члены класса представляют собой переменные и массивы фиксированной размерности; 
б) память для данных-членов класса выделяется динамически.
Составить описания класса, обеспечивающего представление матрицы заданного размера n×m и любого минора в ней. Память для матрицы выделять динамически. Написать несколько конструкторов, в том числе конструктор копирования. Реализовать методы для отображения на экране как матрицы в целом, так и заданного минора, а также для изменения минора; сложения, вычитания, умножения миноров. Перегрузить операции сложения, вычитания, умножения и присваивания для данного класса. Создать массив объектов данного класса и передать его в функцию, которая изменяет для i -й матрицы ее минор путем умножения на константу.*/

#include<iostream>
using namespace std;
class Matrix // целочисленная матрица
{
private:
	int **a; // для хранения информации
	int w, h;// кол-вл строк и столбцов
public:
	Matrix(int H, int W); // конструктор с параметрами
	Matrix(); // пустой конструктор
	~Matrix();// деструктор
	void SetXY(int Y, int X, int data); // для заполнения ячейки строки y и столбца x
	int GetXY(int Y, int X); // возвращает значение элемента строки y и столбца x
	void Show(); // вывод всей матрицы
	void Show(int Hbeg, int Wbeg, int Hend, int Wend);// вывод начиная со строки HBeg и заканчивая Hend, и столбца с WBeg до Wend
	void SetH(int H); // установка кол-ва строк
	void SetW(int W);// установка кол-ва столбцов
	int GetH() { return h; }
	int GetW() { return w; }
};
Matrix::Matrix()
{
	h = w = 0;
}
Matrix::Matrix(int H, int W)
{
	h = H;
	w = W;
	a = new int*[H];// выделение памяти под строки
	for (int i = 0; i < H; i++)
		a[i] = new int[W];// выделение памяти под каждую строку
}
Matrix::~Matrix()
{
	for (int i = 0; i < h; i++)
		delete[] a[i];
	delete[] a;
}
void Matrix::SetXY(int Y, int X, int data)
{
	if (Y < h &&Y >= 0 && X < w && X >= 0)
		a[Y][X] = data;
}
int Matrix::GetXY(int Y, int X)
{
	if (Y < h &&Y >= 0 && X < w && X >= 0)
		return a[Y][X];
	else
		return -1;
}
void Matrix::Show()
{
	for (int i = 0; i < h; i++, cout << endl)
		for (int j = 0; j < w; j++)
			cout << a[i][j] << " ";
}
void Matrix::Show(int Hbeg, int Hend, int Wbeg, int Wend)
{
	if (Hend < h &&Hbeg >= 0 && Wend < w && Wbeg >= 0)
	{
		for (int i = Hbeg; i <= Hend; i++, cout << endl)
			for (int j = Wbeg; j <= Wend; j++)
				cout << a[i][j] << " ";
	}
}
void Matrix::SetH(int H)
{
	int **b;// новый участок памяти
	b = new int*[H];// выделение памяти под строки
	for (int i = 0; i < H; i++)
	{
		b[i] = new int[w];// выделение памяти под каждую строку
		for (int j = 0; j < w; j++)
			b[i][j] = 0; // сразу обнуляем строки
	}

	for (int i = 0; i < H && i < h; i++)
		for (int j = 0; j < w; j++)
			b[i][j] = a[i][j]; // копируем информацию
	// устанавливаем новое кол-во строк

	for (int i = 0; i < h; i++)
		delete[] a[i]; // очистка памяти из под старой информации
	delete[] a;
	h = H;
	a = b;

}
void Matrix::SetW(int W)
{
	int **b;
	b = new int*[h];// выделение памяти под строки
	for (int i = 0; i < h; i++)
	{
		b[i] = new int[W];// выделение памяти под каждую строку
		for (int j = 0; j < W; j++)
			b[i][j] = 0; // сразу обнуляем строки
	}

	for (int i = 0; i < h; i++)
		for (int j = 0; j < w &&j < W; j++)
			b[i][j] = a[i][j]; // копируем информацию


	for (int i = 0; i < h; i++) // очистка памяти из под старой информации
		delete[] a[i];
	delete[] a;
	w = W; // устанавливаем новое кол-во столбцов
	a = b;
}
int main()
{
	setlocale(LC_CTYPE, "");    //Для вывода кирилицы в консоли

	char m_key;

	register int i, j;   //Переменные для циклов
	Matrix *MyMatrix = new Matrix(10, 10);   //Твоя матрица

	do
	{
		system("cls");  //Очистка экрана
		cout << "1. Установить размер матрицы." << endl;
		cout << "2. Заполнить матрицу случайными числами." << endl;
		cout << "3. Установить значение конкретного элемента матрицы." << endl;
		cout << "4. Вывести всю матрицу." << endl;
		cout << "5. Вывести часть матрицы." << endl;
		cout << "0. Выход." << endl;
		cin >> m_key;

		switch (m_key)
		{
		case '1':
		{
			cout << "Введите через пробел размеры матрицы \n(количество строк, количество столбцов)." << endl;
			int x, y;
			cin >> x >> y;
			MyMatrix->SetH(x);
			MyMatrix->SetW(y);
			cout << "Матрица имеет размеры " << x << " на " << y << endl;
			system("pause"); //ожидание нажатия клавиши
			break;
		}
		case '2':
		{
			for (i = 0; i < MyMatrix->GetH(); i++)
				for (j = 0; j < MyMatrix->GetW(); j++)
					MyMatrix->SetXY(i, j, rand() % 100);
			cout << "Матрица заполнена случайными числами." << endl;
			system("pause"); //ожидание нажатия клавиши
			break;
		}
		case '3':
		{
			cout << "Введите через пробел номер элемента \n(номер строки, номер столбца) и требуемое значение." << endl;
			int y, x, z;
			cin >> y >> x >> z;
			MyMatrix->SetXY(y - 1, x - 1, z);
			cout << "Элемент изменён." << endl;
			system("pause"); //ожидание нажатия клавиши
			break;
		}
		case '4':
		{
			MyMatrix->Show();
			system("pause"); //ожидание нажатия клавиши
			break;
		}
		case '5':
		{
			cout << "Введите через пробел номер начальной и конечной строки,\nа также номер начального и конечного столбца для вывода." << endl;
			int x1, y1, x2, y2;
			cin >> x1 >> y1 >> x2 >> y2;
			MyMatrix->Show(x1 - 1, y1 - 1, x2 - 1, y2 - 1);
			system("pause"); //ожидание нажатия клавиши
			break;
		}
		}

	} while (m_key != '0');  //Пока не выбран 0, продолжаем

	delete MyMatrix;    //Удаляем матрицу
	return 0;
}