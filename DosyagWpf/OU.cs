using System.Collections.Generic;
using System.Windows.Data;

namespace DosyagWpf
{
    public class OUType
    {
        public string Name { get; set; }

        public OUType(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class OU
    {

        public string Name { get; set; }
        public int Number { get; set; }

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        
        public double FDLight
        {
            get { return 50; } // Запрашиваем данные через DLL - позже сделаем
            set { FDLight = value; }
        }
        public double FDFull
        {
            get { return 80; }// Запрашиваем данные через DLL - позже сделаем
            set { FDFull = value; }
        }
        public double FDUltimate
        {
            get { return 95; }// Запрашиваем данные через DLL - позже сделаем
            set { FDUltimate = value; }
        }

        public double FDLightSpec
        {
            get { return 33; }// Запрашиваем данные через DLL - позже сделаем
            set { FDLightSpec = value; }
        }
        public double FDFullSpec
        {
            get { return 66; }// Запрашиваем данные через DLL - позже сделаем
            set { FDFullSpec = value; }
        }
        public double FDUltimateSpec
        {
            get { return 92; }// Запрашиваем данные через DLL - позже сделаем
            set { FDUltimateSpec = value; }
        }

        public OU(int number, string name, string OUtype, double x, double y, double z)
        {
            Number = number;
            Name = name;
            Type = OUtype;
            X = x;
            Y = y;
            Z = z;

            
                List<OUType> list = new List<OUType>();
                list.Add(new OUType("Кнопка"));
                list.Add(new OUType("Рычаг"));
                list.Add(new OUType("Тумблер"));

            _outypes = new CollectionView(list);

         }

        private readonly CollectionView _outypes;
        private string _type;

        public CollectionView OUTypes
        {
            get { return _outypes; }
        }

        public string Type
        {
            get { return _type; }
            set
            {
                if (_type == value) return;
                _type = value;
            }
        }
    }


}