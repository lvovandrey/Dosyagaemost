using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DosyagWpf
{
    class DosyagDLLEmulator
    {
//#define PI 3.14159265    

//        //Сигмы по досягаемости. Строка - высота от -200 до 1200 с шагом в 200 мм. Столбец - угол от 0 до 120 с шагом 15 град.
//        double sigmas[8][9] = {
//{55, 57, 56, 57, 59, 57, 52, 47, 44 },
//{55, 57, 56, 57, 59, 57, 52, 57, 44 },
//{48, 49, 48, 44, 43, 40, 37, 37, 35 },
//{47, 45, 45, 42, 41, 41, 36, 34, 34 },
//{49, 48, 48, 48, 43, 42, 40, 36, 34 },
//{54, 53, 53, 52, 45, 43, 41, 39, 38 },
//{58, 38, 57, 55, 50, 49, 46, 77, 46 },
//{0,  0,  0,  70, 70, 70, 67, 70, 72 },
//};

////Удаления по досягаемости. Строка - высота от -200 до 1200 с шагом в 200 мм. Столбец - угол от 0 до 120 с шагом 15 град.
//double fd[8][9] = {
//{ 484, 523, 546, 562, 577, 594, 597, 594, 597 },
//{ 484, 523, 546, 562, 577, 594, 597, 594, 597 },
//{ 640, 679, 702, 722, 735, 749, 752, 753, 749 },
//{ 720, 758, 777, 797, 814, 824, 830, 828, 823 },
//{ 740, 770, 794, 804, 831, 841, 847, 846, 839 },
//{ 684, 713, 738, 753, 775, 785, 795, 799, 797 },
//{ 564, 593, 613, 622, 647, 661, 675, 685, 638 },
//{ 0,   0,   0,   434, 435, 440, 445, 470, 479 }
//};




////----------------------------------------------
////Функции перевода прямоугольных координат в цилиндрические
////----------------------------------------------
//extern "C" __declspec(dllexport)
//double alpha(double x, double y, double z)
//        {
//            return atan2(z, x) * 180 / PI;
//        }


//        extern "C" __declspec(dllexport)
//double dist(double x, double y, double z)
//        {
//            return sqrt(x * x + z * z);
//        }

//        extern "C" __declspec(dllexport)
//double h(double x, double y, double z)
//        {
//            return y;
//        }






//        //----------------------------------------------
//        //Функции перевода цилиндрических координат в прямоугольные
//        //----------------------------------------------
//        extern "C" __declspec(dllexport)
//double x(double alpha, double dist, double height)
//        {
//            double alphaRad = alpha * PI / 180;
//            return dist * cos(alphaRad);
//        }

//        extern "C" __declspec(dllexport)
//double y(double alpha, double dist, double height)
//        {
//            return height;
//        }

//        extern "C" __declspec(dllexport)
//double z(double alpha, double dist, double height)
//        {
//            double alphaRad = alpha * PI / 180;
//            return dist * sin(alphaRad);
//        }



//        //--------------------------------------
//        // Функция билинейной интерполяции (не экспортирую пока)
//        //аргументы называются стандартно - в соответствии со статьей в википедии например https://en.wikipedia.org/wiki/Bilinear_interpolation
//        //--------------------------------------
//        double BilinearInterpolation(
//            double x, double x1, double x2,
//            double y, double y1, double y2,
//            double Q11, double Q12, double Q21, double Q22)
//        {
//            double xt1 = (x2 - x) / (x2 - x1);
//            double xt2 = (x - x1) / (x2 - x1);

//            double yt1 = (y2 - y) / (y2 - y1);
//            double yt2 = (y - y1) / (y2 - y1);

//            double R1 = xt1 * Q11 + xt2 * Q21;
//            double R2 = xt1 * Q12 + xt2 * Q22;

//            double P = yt1 * R1 + yt2 * R2;

//            return P;
//        }

//        //--------------------------------
//        // Функция нормального распределения
//        //--------------------------------
//        double NORMSDIST(double z)
//        {
//            double sign = 1;
//            if (z < 0) sign = -1;
//            return 0.5 * (1.0 + sign * erf(fabs(z) / sqrt(2)));
//        }


//        //***********************************************************
//        //-------------------------------
//        //Основная функция этой библиотеки
//        //Рассчет значения досягаемости
//        //-------------------------------
        
//double Dosyagaemost(int FDtype, int OUtype, bool Spec, double x, double y, double z)
//        {
//            double H = y;
//            double L = dist(x, y, z);
////            double Alpha = abs(alpha(x, y, z));
//            double Alpha = Math.Abs(alpha(x, y, z));

//            if ((H > 1200) || (H < -200) || (Alpha > 120)) return -1; // проверка наличия значений в таблице величин

//            //готовим значения для билинейной интерполяции
//            double h1, h2, alpha1, alpha2;
//            double Sigma11, Sigma12, Sigma21, Sigma22;
//            double fd11, fd12, fd21, fd22;

//            int Nh1, Nh2, Nalpha1, Nalpha2; //номера нужный ячеек в таблицах из ГОСТа
//            Nh1 = floor(H / 200) + 1;
//            Nh2 = ceil(H / 200) + 1;
//            Nalpha1 = floor(Alpha / 15);
//            Nalpha2 = ceil(Alpha / 15);

//            h1 = (Nh1 - 1) * 200;
//            h2 = (Nh2 - 1) * 200;
//            alpha1 = Nalpha1 * 15;
//            alpha2 = Nalpha1 * 15;

//            //Ищем значения четырех окружающих точке в таблице досягаемости
//            fd11 = fd[Nh1][Nalpha1];
//            fd12 = fd[Nh2][Nalpha1];
//            fd21 = fd[Nh1][Nalpha2];
//            fd22 = fd[Nh2][Nalpha2];

//            //Ищем значения четырех окружающих точке в таблице стандартных отклонений
//            Sigma11 = sigmas[Nh1][Nalpha1];
//            Sigma12 = sigmas[Nh2][Nalpha1];
//            Sigma21 = sigmas[Nh1][Nalpha2];
//            Sigma22 = sigmas[Nh2][Nalpha2];

//            //Проводим саму интерполяцию
//            double FD, SIGMA;
//            FD = BilinearInterpolation(Alpha, alpha1, alpha2, H, h1, h2, fd11, fd12, fd21, fd22);
//            SIGMA = BilinearInterpolation(Alpha, alpha1, alpha2, H, h1, h2, Sigma11, Sigma12, Sigma21, Sigma22);


//            //Считаем с помощью статистической функции нормального распределения процент досягающих
//            double Percent = 100 * NORMSDIST((FD - L) / SIGMA);

//            return Percent;
//        }


    }
}
