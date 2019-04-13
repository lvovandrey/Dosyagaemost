// ConsoleApplication1.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <windows.h>

using namespace std;

typedef int(*TESTFUNCTION)(int);


int main()
{
	int n = 123;
	cout << "My first program!" << endl;
	cout << n << endl;



	int w = 10, h = 10, multi;
	DWORD err;
	HINSTANCE hDll = LoadLibrary("DosyagDll.dll"); //название подключаемой библиотеки
	if (hDll != NULL)
	{
		printf("Library was loaded\n");
	}
	else
	{
		err = GetLastError();
		printf("Couldn't load dll. Error code %d\n", err);
		return 0;
	}
	// получение указателя на функцию библиотеки
	TESTFUNCTION lpTestFunction = (TESTFUNCTION)GetProcAddress(hDll, "SomeFunc");
	if (lpTestFunction != NULL)
	{
		multi = (*lpTestFunction) (h);
		printf("multi = %d\n", multi);
	}
	// освобождение дескриптора
	FreeLibrary(hDll);

	system("pause");
	return 0;
}

