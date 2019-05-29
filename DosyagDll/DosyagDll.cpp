//////████  ████ ███ ██ ██ ████ ████ ████ ███ █   █ ████ ███ ███   ████  █   █
//////█  ██ █  █ █    ███  █  █ █    █  █ █   ██ ██ █  █ █    █    █  ██ █   █
//////█  ██ █  █ ███   █   ████ █ ██ ████ ███ █ █ █ █  █ ███  █    █  ██ █   █
//////█  ██ █  █   █   █   █  █ █  █ █  █ █   █   █ █  █   █  █    █  ██ █   █
//////████  ████ ███   █   █  █ ████ █  █ ███ █   █ ████ ███  █  █ ████  ███ ███

// DosyagDll.cpp: определяет экспортированные функции для приложения DLL.


#include "stdafx.h"
#include <cmath>
#define PI 3.14159265    

//Сигмы по досягаемости. Легкая досягаемость. Строка - высота от -200 до 1200 с шагом в 200 мм. Столбец - угол от 0 до 120 с шагом 15 град.
double sigmas[8][9] = {
{55, 57, 56, 57, 59, 57, 52, 47, 44 },
{55, 57, 56, 57, 59, 57, 52, 57, 44 },
{48, 49, 48, 44, 43, 40, 37, 37, 35 },
{47, 45, 45, 42, 41, 41, 36, 34, 34 },
{49, 48, 48, 48, 43, 42, 40, 36, 34 },
{54, 53, 53, 52, 45, 43, 41, 39, 38 },
{58, 38, 57, 55, 50, 49, 46, 77, 46 },
{0,  0,  0,  70, 70, 70, 67, 70, 72 },
};

//Удаления по досягаемости. Легкая досягаемость. Строка - высота от -200 до 1200 с шагом в 200 мм. Столбец - угол от 0 до 120 с шагом 15 град.
double fd[8][9] = {
{ 484, 523, 546, 562, 577, 594, 597, 594, 597 },
{ 484, 523, 546, 562, 577, 594, 597, 594, 597 },
{ 640, 679, 702, 722, 735, 749, 752, 753, 749 },
{ 720, 758, 777, 797, 814, 824, 830, 828, 823 },
{ 740, 770, 794, 804, 831, 841, 847, 846, 839 },
{ 684, 713, 738, 753, 775, 785, 795, 799, 797 },
{ 564, 593, 613, 622, 647, 661, 675, 685, 638 },
{ 0,   0,   0,   434, 435, 440, 445, 470, 479 }
};


//Сигмы по досягаемости. Предельная досягаемость. Строка - высота от -200 до 1200 с шагом в 200 мм. Столбец - угол от 0 до 120 с шагом 15 град.
double sigmasUlt[8][9] = {
{ 100,	106,	109,	112,	0,	0,	0,	0,	0 },
{ 100,	106,	109,	112,	0,	0,	0,	0,	0 },
{ 76,	83,		87,		91,		0,	0,	0,	0,	0 },
{ 63,	71,		75,		79,		0,	0,	0,	0,	0 },
{ 60,	62,		64,		66,		0,	0,	0,	0,	0 },
{ 59,	62,		66,		68,		0,	0,	0,	0,	0 },
{ 64,	63,		65,		73,		0,	0,	0,	0,	0 },
{ 82,	81,		81,		82,		0,	0,	0,	0,	0 }
};

//Удаления по досягаемости. Предельная досягаемость. Строка - высота от -200 до 1200 с шагом в 200 мм. Столбец - угол от 0 до 120 с шагом 15 град.
double fdUlt[8][9] = {
{ 1079,	1084,	1082,	1051,	0,	0,	0,	0,	0 },
{ 1079,	1084,	1082,	1051,	0,	0,	0,	0,	0 },
{ 1161,	1156,	1152,	1124,	0,	0,	0,	0,	0 },
{ 1184,	1177,	1172,	1145,	0,	0,	0,	0,	0 },
{ 1140,	1136,	1122,	1103,	0,	0,	0,	0,	0 },
{ 1047,	1033,	1029,	1006,	0,	0,	0,	0,	0 },
{ 900,	893,	868,	859,	0,	0,	0,	0,	0 },
{ 657,	657,	641,	623,	0,	0,	0,	0,	0 }
};



//------------------------------------------
// Досягаемость в спецснаряжении
//-----------------------------------------

//Сигмы по досягаемости. Легкая досягаемость. СПЕЦСНАР. Строка - высота от -200 до 1200 с шагом в 200 мм. Столбец - угол от 0 до 120 с шагом 15 град.
double sigmasSpec[8][9] = {
{ 0,	49,	50,	51,	51,	51,	51,	51,	48 },
{ 0,	49,	50,	51,	51,	51,	51,	51,	48 },
{ 49,	45,	42,	40,	38,	38,	38,	37,	40 },
{ 40,	38,	37,	36,	35,	35,	35,	37,	43 },
{ 45,	45,	43,	42,	40,	38,	38,	38,	37 },
{ 48,	44,	44,	44,	44,	45,	46,	48,	0 },
{ 55,	51,	51,	51,	49,	49,	49,	52,	0 },
{ 0,	0,	0,	0,	70,	70,	70,	0,	0 }
};

//Удаления по досягаемости. Легкая досягаемость. СПЕЦСНАР.  Строка - высота от -200 до 1200 с шагом в 200 мм. Столбец - угол от 0 до 120 с шагом 15 град.
double fdSpec[8][9] = {
{ 0,	534,	548,	568,	584,	607,	614,	604,	585 },
{ 0,	534,	548,	568,	584,	607,	614,	604,	585 },
{ 637,	678,	699,	724,	738,	754,	760,	755,	732 },
{ 703,	745,	772,	795,	808,	821,	828,	821,	799 },
{ 703,	745,	774,	801,	816,	830,	834,	831,	807 },
{ 623,	670,	701,	725,	749,	764,	771,	775,	0 },
{ 476,	540,	561,	588,	609,	628,	633,	649,	0 },
{ 0,	0,		0,		0,		393,	385,	374,	0,		0 }
};

//Сигмы по досягаемости. Предельная досягаемость. СПЕЦСНАР. Строка - высота от -200 до 1200 с шагом в 200 мм. Столбец - угол от 0 до 120 с шагом 15 град.
double sigmasUltSpec[8][9] = {
{ 0,	0,	0,	0,	0,	0,	0,	0,	0 },
{ 90,	92,	94,	98,	0,	0,	0,	0,	0 },
{ 79,	79,	79,	79,	0,	0,	0,	0,	0 },
{ 73,	71,	70,	70,	0,	0,	0,	0,	0 },
{ 71,	71,	71,	71,	0,	0,	0,	0,	0 },
{ 75,	73,	71,	68,	0,	0,	0,	0,	0 },
{ 88,	82,	80,	74,	0,	0,	0,	0,	0 },
{ 0,	0,	0,	80,	0,	0,	0,	0,	0 }
};

//Удаления по досягаемости. Предельная досягаемость. СПЕЦСНАР. Строка - высота от -200 до 1200 с шагом в 200 мм. Столбец - угол от 0 до 120 с шагом 15 град.
double fdUltSpec[8][9] = {
{ 0,	0,		0,		0,		0,	0,	0,	0,	0 },
{ 865,	907,	930,	930,	0,	0,	0,	0,	0 },
{ 947,	996,	1012,	1013,	0,	0,	0,	0,	0 },
{ 971,	1019,	1038,	1036,	0,	0,	0,	0,	0 },
{ 930,	971,	978,	981,	0,	0,	0,	0,	0 },
{ 833,	868,	870,	862,	0,	0,	0,	0,	0 },
{ 680,	692,	681,	680,	0,	0,	0,	0,	0 },
{ 0,	0,		0,		453,	0,	0,	0,	0,	0 }
};


//----------------------------------------------
//Функции перевода прямоугольных координат в цилиндрические
//----------------------------------------------
extern "C" __declspec(dllexport)
double alpha( double x, double y, double z)
{
	return atan2(z, x) * 180 / PI;
}


extern "C" __declspec(dllexport)
double dist(double x, double y, double z)
{
	return sqrt(x*x + z*z);
}

extern "C" __declspec(dllexport)
double h(double x, double y, double z)
{
	return y;
}






//----------------------------------------------
//Функции перевода цилиндрических координат в прямоугольные
//----------------------------------------------
extern "C" __declspec(dllexport)
double x(double alpha, double dist, double height)
{
	double alphaRad = alpha * PI/180;
	return dist*cos(alphaRad);
}

extern "C" __declspec(dllexport)
double y(double alpha, double dist, double height)
{
	return height;
}

extern "C" __declspec(dllexport)
double z(double alpha, double dist, double height)
{
	double alphaRad = alpha * PI/180;
	return dist * sin(alphaRad);
}



//--------------------------------------
// Функция билинейной интерполяции (не экспортирую пока)
//аргументы называются стандартно - в соответствии со статьей в википедии например https://en.wikipedia.org/wiki/Bilinear_interpolation
//--------------------------------------
double BilinearInterpolation(
	double x, double x1, double x2,
	double y, double y1, double y2,
	double Q11, double Q12, double Q21, double Q22)
{
	double xt1 = (x2 - x) / (x2 - x1);
	double xt2 = (x - x1) / (x2 - x1);

	double yt1 = (y2 - y) / (y2 - y1);
	double yt2 = (y - y1) / (y2 - y1);

	double R1 = xt1 * Q11 + xt2 * Q21;
	double R2 = xt1 * Q12 + xt2 * Q22;

	double P = yt1 * R1 + yt2 * R2;

	return P;
}

//--------------------------------
// Функция нормального распределения
//--------------------------------
double NORMSDIST(double z)
{
	double sign = 1;
	if (z < 0) sign = -1;
	return 0.5 * (1.0 + sign * erf(fabs(z) / sqrt(2)));
}


//***********************************************************
//-------------------------------
//Основная функция этой библиотеки
//Рассчет значения досягаемости
//-------------------------------
extern "C" __declspec(dllexport)
double Dosyagaemost(int FDtype, int OUtype, bool Spec, double x, double y, double z)
{
	double H = y;
	double L = dist(x, y, z);
	double Alpha = abs(alpha(x, y, z));

	if (Alpha == 0) Alpha = 0.00001;
	if ((Alpha == 0) || (Alpha == 15) || (Alpha == 30) || (Alpha == 45) || (Alpha == 60) || (Alpha == 75) || (Alpha == 90) || (Alpha == 105) || (Alpha == 120)) Alpha += 0.00001;
	if ((H == -200) || (H == 0) || (H == 200) || (H == 400) || (H == 600) || (H == 800) || (H == 1000) || (H == 1200)) H += 0.001;

	
	if ((FDtype>3) || (FDtype<1)) return -2; // неверное значения типа досягаемости
	if ((OUtype>3) || (OUtype<1)) return -3; // неверное значение типа ОУ

										   //готовим значения для билинейной интерполяции
	double h1, h2, alpha1, alpha2;
	double Sigma11, Sigma12, Sigma21, Sigma22;
	double fd11, fd12, fd21, fd22;

	int Nh1, Nh2, Nalpha1, Nalpha2; //номера нужный ячеек в таблицах из ГОСТа
	Nh1 = floor(H / 200) + 1;
	Nh2 = ceil(H / 200) + 1;
	Nalpha1 = floor(Alpha / 15);
	Nalpha2 = ceil(Alpha / 15);

	h1 = (Nh1 - 1) * 200;
	h2 = (Nh2 - 1) * 200;
	alpha1 = Nalpha1 * 15;
	alpha2 = Nalpha2 * 15;

	if ((FDtype == 1) || (FDtype == 2)) // Легкая или полная досягаемость 
	{
		if (!Spec) // Без спецснаряжения 
		{
			if ((H > 1200) || (H < -200) || (Alpha > 120)) return -1; // проверка наличия значений в таблице величин
			//Ищем значения четырех окружающих точке в таблице досягаемости
			fd11 = fd[Nh1][Nalpha1];
			fd12 = fd[Nh2][Nalpha1];
			fd21 = fd[Nh1][Nalpha2];
			fd22 = fd[Nh2][Nalpha2];

			//Ищем значения четырех окружающих точке в таблице стандартных отклонений
			Sigma11 = sigmas[Nh1][Nalpha1];
			Sigma12 = sigmas[Nh2][Nalpha1];
			Sigma21 = sigmas[Nh1][Nalpha2];
			Sigma22 = sigmas[Nh2][Nalpha2];
		}
		else  //Со спецснаряжением
		{
			if ((H > 1200) || (H < -200) || (Alpha > 120)) return -1; // проверка наличия значений в таблице величин
			//Ищем значения четырех окружающих точке в таблице досягаемости
			fd11 = fdSpec[Nh1][Nalpha1];
			fd12 = fdSpec[Nh2][Nalpha1];
			fd21 = fdSpec[Nh1][Nalpha2];
			fd22 = fdSpec[Nh2][Nalpha2];

			//Ищем значения четырех окружающих точке в таблице стандартных отклонений
			Sigma11 = sigmasSpec[Nh1][Nalpha1];
			Sigma12 = sigmasSpec[Nh2][Nalpha1];
			Sigma21 = sigmasSpec[Nh1][Nalpha2];
			Sigma22 = sigmasSpec[Nh2][Nalpha2];
		}
	}
	if (FDtype == 3)
	{
		if (!Spec) // Без спецснаряжения 
		{
			if ((H > 1200) || (H < -200) || (Alpha > 120)) return -1; // проверка наличия значений в таблице величин
			//Ищем значения четырех окружающих точке в таблице досягаемости
			fd11 = fdUlt[Nh1][Nalpha1];
			fd12 = fdUlt[Nh2][Nalpha1];
			fd21 = fdUlt[Nh1][Nalpha2];
			fd22 = fdUlt[Nh2][Nalpha2];

			//Ищем значения четырех окружающих точке в таблице стандартных отклонений
			Sigma11 = sigmasUlt[Nh1][Nalpha1];
			Sigma12 = sigmasUlt[Nh2][Nalpha1];
			Sigma21 = sigmasUlt[Nh1][Nalpha2];
			Sigma22 = sigmasUlt[Nh2][Nalpha2];
		}
		else  //Со спецснаряжением
		{
			if ((H > 1200) || (H < -200) || (Alpha > 120)) return -1; // проверка наличия значений в таблице величин
			//Ищем значения четырех окружающих точке в таблице досягаемости
			fd11 = fdUltSpec[Nh1][Nalpha1];
			fd12 = fdUltSpec[Nh2][Nalpha1];
			fd21 = fdUltSpec[Nh1][Nalpha2];
			fd22 = fdUltSpec[Nh2][Nalpha2];

			//Ищем значения четырех окружающих точке в таблице стандартных отклонений
			Sigma11 = sigmasUltSpec[Nh1][Nalpha1];
			Sigma12 = sigmasUltSpec[Nh2][Nalpha1];
			Sigma21 = sigmasUltSpec[Nh1][Nalpha2];
			Sigma22 = sigmasUltSpec[Nh2][Nalpha2];
		}
	}

	//если хоть одна из этих точек пустая, значит в ГОСТ для нее нет значения, а следовательно эта область вне зоны оценки по ГОСТ
	if ((fd11 == 0) || (fd12 == 0) || (fd21 == 0) || (fd22 == 0)) return -4; 
	
    //Проводим саму интерполяцию
	double FD, SIGMA;
	FD = BilinearInterpolation(Alpha, alpha1, alpha2, H, h1, h2, fd11, fd12, fd21, fd22);
	SIGMA = BilinearInterpolation(Alpha, alpha1, alpha2, H, h1, h2, Sigma11, Sigma12, Sigma21, Sigma22);

	if (OUtype == 1) FD += 60; //модификация для ОУ типа кнопка
	if (OUtype == 2) FD -= 50; //модификация для ОУ типа рычаг

	if (FDtype == 2) FD += 90; //модификация для Полной досягаемости


	//Считаем с помощью статистической функции нормального распределения долю досягающих (ДОЛЮ - НЕ ПРОЦЕНТ!)
	double Percent = NORMSDIST((FD - L) / SIGMA);

	return Percent;
}

