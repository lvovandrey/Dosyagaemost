using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.IO;
using CsvHelper.Configuration.Attributes;
using System.Globalization;
using System.Diagnostics;

namespace DosyagWpf
{
    public class OURec 
    {
        [Name("№")]
        public int _number { get; set; }
        [Name("Название ОУ")]
        public string _name { get; set; }
        [Name("Тип ОУ")]
        public string _type { get; set; }

        [Name("Угол отведения")]
        public double _Alpha { get; set; }
        [Name("Дистанция")]
        public double _Dist { get; set; }
        [Name("Высота")]
        public double _Height { get; set; }

        [Name("ФД легкая")]
        public double _FDLight { get; set; }
        [Name("ФД полная")]
        public double _FDFull { get; set; }
        [Name("ФД предельная")]
        public double _FDUltimate { get; set; }
        [Name("ФД легкая в спецснар.")]
        public double _FDLightSpec { get; set; }
        [Name("ФД полная в спецснар.")]
        public double _FDFullSpec { get; set; }
        [Name("ФД предельная в спецснар.")]
        public double _FDUltimateSpec { get; set; }

        [Name("X")]
        public double _x { get; set; }
        [Name("Y")]
        public double _y { get; set; }
        [Name("Z")]
        public double _z { get; set; }

       
    }

    public class CsvWrite
    {
        public static void Write(IEnumerable<OU> OUs) {
            // указываем путь к файлу csv
            string pathCsvFile = "C:\\tmpDosyag.csv";
            List<OURec> oURecs = new List<OURec>();

            foreach(OU ou in OUs)
            {
                OURec rec = new OURec();
                rec._number = ou.Number;
                rec._Alpha = ou.Alpha;
                rec._Dist = ou.Dist;
                rec._FDFull = ou.FDFull;
                rec._FDFullSpec = ou.FDFullSpec;
                rec._FDLight = ou.FDLight;
                rec._FDLightSpec = ou.FDLightSpec;
                rec._FDUltimate = ou.FDUltimate;
                rec._FDUltimateSpec = ou.FDUltimateSpec;
                rec._Height = ou.Height;
                rec._name = ou.Name;
                rec._number = ou.Number;
                rec._type = ou.Type;
                rec._x = ou.X;
                rec._y = ou.Y;
                rec._z = ou.Z;
                oURecs.Add(rec);
            }

            // добавляем тестовые данные, которые будем записывать в csv файл
            using (StreamWriter streamReader = new StreamWriter(pathCsvFile,false, Encoding.UTF8))
            {
                using (CsvWriter csvReader = new CsvWriter(streamReader))
                {
                    // указываем разделитель, который будет использоваться в файле
                    csvReader.Configuration.Delimiter = ";";
//                    csvReader.Configuration.CultureInfo = CultureInfo.GetCultureInfo("ru-RU");
                    // записываем данные в csv файл
                    csvReader.WriteRecords(oURecs);
                }
            }
            Process.Start("C:\\tmpDosyag.csv");

        }
    }
}

