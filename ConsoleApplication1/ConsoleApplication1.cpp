// ConsoleApplication1.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include "windows.h"
#include <stdio.h>
#include <iostream>
#include <windows.h>


// тип PFN_MyFunction будет объявлять указатель на функцию,
// принимающую указатель на символьный буфер и выдающую значение типа int

int main()
{
	double res;
	HINSTANCE hModule = NULL;
	hModule = ::LoadLibrary("DosyagDll.dll");
	if (hModule != NULL)
	{
		double(*pFunction)(double, double, double);
		(FARPROC &)pFunction = GetProcAddress((HMODULE)hModule, "x");
		if (pFunction != NULL)
		{
			res = pFunction(50, 100, 100);
			printf("FD = %d\n", int(res));
			system("pause");
			return 0;
		}
		printf("Error Load function");
		::FreeLibrary(hModule);
	}
	printf("error load Dll");

	system("pause");

	return 0;
}

// Запуск программы: CTRL+F5 или меню "Отладка" > "Запуск без отладки"
// Отладка программы: F5 или меню "Отладка" > "Запустить отладку"

// Советы по началу работы 
//   1. В окне обозревателя решений можно добавлять файлы и управлять ими.
//   2. В окне Team Explorer можно подключиться к системе управления версиями.
//   3. В окне "Выходные данные" можно просматривать выходные данные сборки и другие сообщения.
//   4. В окне "Список ошибок" можно просматривать ошибки.
//   5. Последовательно выберите пункты меню "Проект" > "Добавить новый элемент", чтобы создать файлы кода, или "Проект" > "Добавить существующий элемент", чтобы добавить в проект существующие файлы кода.
//   6. Чтобы снова открыть этот проект позже, выберите пункты меню "Файл" > "Открыть" > "Проект" и выберите SLN-файл.
