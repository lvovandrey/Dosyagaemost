// DosyagDll.cpp: определяет экспортированные функции для приложения DLL.
//

#include "stdafx.h"
#include <cmath>

//-------------------------------
//Основная функция этой библиотеки
//Рассчет значения досягаемости
//-------------------------------
extern "C" __declspec(dllexport)
double Dosyagaemost(int FDtype, int OUtype, bool Spec, double x, double y, double z)
{
	//это симуляция результата пока. Чуть позже сделаю нормальный код.
	double r;
	if (Spec)
		r = sqrt(x*x + z*z + FDtype*1000 + OUtype*1000);
	else
		r = sqrt(x*x + z*z + FDtype*1000 + OUtype*1000 - 1000);

	return r/1000;
}









//----------------------------------------------
//Функции перевода прямоугольных координат в цилиндрические
//----------------------------------------------
extern "C" __declspec(dllexport)
double alpha( double x, double y, double z)
{
	//это симуляция результата пока. Чуть позже сделаю нормальный код.
	
	return x / 200;
}

extern "C" __declspec(dllexport)
double dist(double x, double y, double z)
{
	//это симуляция результата пока. Чуть позже сделаю нормальный код.

	double r =  z/20;

	return r ;
}

extern "C" __declspec(dllexport)
double h(double x, double y, double z)
{
	//это симуляция результата пока. Чуть позже сделаю нормальный код.

	return y;
}






//----------------------------------------------
//Функции перевода цилиндрических координат в прямоугольные
//----------------------------------------------
extern "C" __declspec(dllexport)
double x(double alpha, double dist, double height)
{
	//это симуляция результата пока. Чуть позже сделаю нормальный код.

	return alpha*200;
}

extern "C" __declspec(dllexport)
double y(double alpha, double dist, double height)
{
	//это симуляция результата пока. Чуть позже сделаю нормальный код.

	return height;
}

extern "C" __declspec(dllexport)
double z(double alpha, double dist, double height)
{
	//это симуляция результата пока. Чуть позже сделаю нормальный код.

	return dist*20;
}