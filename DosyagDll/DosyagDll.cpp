// DosyagDll.cpp: определяет экспортированные функции для приложения DLL.
//

#include "stdafx.h"

extern "C" __declspec(dllexport)
int SomeFunc(int a)
{
	return a * 5;
}
