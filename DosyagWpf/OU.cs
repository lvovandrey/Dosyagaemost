using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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

    public class OU: INotifyPropertyChanged
    {
        string _name { get; set; }
        int _number { get; set; }

        double _x { get; set; }
        double _y { get; set; }
        double _z { get; set; }

        double _FDLight { get; set; }
        double _FDFull { get; set; }
        double _FDUltimate { get; set; }
        double _FDLightSpec { get; set; }
        double _FDFullSpec { get; set; }
        double _FDUltimateSpec { get; set; }
        string _type { get; set; }
        int _IntType { get; set; }


        void UpdateFD()
        {
            //OnPropertyChanged("Name");
            //OnPropertyChanged("Number");
            //OnPropertyChanged("X");
            //OnPropertyChanged("Y");
            //OnPropertyChanged("Z");
            OnPropertyChanged("FDLight");
            OnPropertyChanged("FDFull");
            OnPropertyChanged("FDUltimate");
            OnPropertyChanged("FDLightSpec");
            OnPropertyChanged("FDFullSpec");
            OnPropertyChanged("FDUltimateSpec");
            //OnPropertyChanged("Type");
            //OnPropertyChanged("IntType");
        }






        public string Name { get { return _name; } set { _name = value; OnPropertyChanged("Name"); } }
        public int Number { get { return _number; } set { _number = value; OnPropertyChanged("Number"); } }

        public double X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
                OnPropertyChanged("X");
                UpdateFD();
                UpdateARH();
            }
        }
        public double Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
                OnPropertyChanged("Y");
                UpdateFD();
                UpdateARH();
            }
        }
        public double Z
        {
            get
            {
                return _z;
            }
            set
            {
                _z = value;
                OnPropertyChanged("Z");
                UpdateFD();
                UpdateARH();
            }
        }

        void UpdateXYZ()
        {
            OnPropertyChanged("X");
            OnPropertyChanged("Y");
            OnPropertyChanged("Z");
        }


        void UpdateARH()
        {
            OnPropertyChanged("Alpha");
            OnPropertyChanged("Dist");
            OnPropertyChanged("Height");
        }

        double _Alpha { get; set; }

        public double Alpha
        {
            get
            {
                return _Alpha = CppLib.alpha(_x, _y, _z);
            }
            set
            {
                _Alpha = value;
                _x = CppLib.x(_Alpha, _Dist, _Height);
                _y = CppLib.y(_Alpha, _Dist, _Height);
                _z = CppLib.z(_Alpha, _Dist, _Height);
                UpdateXYZ();
                UpdateFD();
                OnPropertyChanged("Alpha");

            }
        }

        double _Dist { get; set; }

        public double Dist
        {
            get
            {
                return _Dist = CppLib.dist(_x, _y, _z);
            }
            set
            {
                _Dist = value;
                _x = CppLib.x(_Alpha, _Dist, _Height);
                _y = CppLib.y(_Alpha, _Dist, _Height);
                _z = CppLib.z(_Alpha, _Dist, _Height);
                UpdateXYZ();
                UpdateFD();
                OnPropertyChanged("Dist");
            }
        }

        double _Height { get; set; }

        public double Height
        {
            get
            {
                return _Height = CppLib.h(_x, _y, _z);
            }
            set
            {
                _Height = value;
                _x = CppLib.x(_Alpha, _Dist, _Height);
                _y = CppLib.y(_Alpha, _Dist, _Height);
                _z = CppLib.z(_Alpha, _Dist, _Height);
                UpdateXYZ();
                UpdateFD();
                OnPropertyChanged("Height");
            }
        }




        public double FDLight
        {
            get
            {
                _FDLight = CppLib.Dosyagaemost(1, this.IntType, false, X, Y, Z);
                return _FDLight;
            } // Запрашиваем данные через DLL - позже сделаем
            set
            {
                _FDLight = value;
                OnPropertyChanged("FDLight");
            }
        }
        public double FDLightSpec
        {
            get
            {
                _FDLightSpec = CppLib.Dosyagaemost(1, this.IntType, true, X, Y, Z);
                return _FDLightSpec;
            } // Запрашиваем данные через DLL - позже сделаем
            set
            {
                _FDLightSpec = value;
                OnPropertyChanged("FDLightSpec");
            }
        }


        public double FDFull
        {
            get
            {
                _FDFull = CppLib.Dosyagaemost(1, this.IntType, false, X, Y, Z);
                return _FDFull;
            } // Запрашиваем данные через DLL - позже сделаем
            set
            {
                _FDFull = value;
                OnPropertyChanged("FDFull");
            }
        }
        public double FDFullSpec
        {
            get
            {
                _FDFullSpec = CppLib.Dosyagaemost(1, this.IntType, true, X, Y, Z);
                return _FDFullSpec;
            } // Запрашиваем данные через DLL - позже сделаем
            set
            {
                _FDFullSpec = value;
                OnPropertyChanged("FDFullSpec");
            }
        }





        public double FDUltimate
        {
            get
            {
                _FDUltimate = CppLib.Dosyagaemost(1, this.IntType, false, X, Y, Z);
                return _FDUltimate;
            } // Запрашиваем данные через DLL - позже сделаем
            set
            {
                _FDUltimate = value;
                OnPropertyChanged("FDUltimate");
            }
        }
        public double FDUltimateSpec
        {
            get
            {
                _FDUltimateSpec = CppLib.Dosyagaemost(1, this.IntType, true, X, Y, Z);
                return _FDUltimateSpec;
            } // Запрашиваем данные через DLL - позже сделаем
            set
            {
                _FDUltimateSpec = value;
                OnPropertyChanged("FDUltimateSpec");
            }
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
        public CollectionView OUTypes
        {
            get { return _outypes; }
        }

        public int IntType
        {
            get
            {
                switch (_type)
                {
                    case "Кнопка": return 1;
                    case "Рычаг": return 2;
                    case "Тумблер": return 3;
                    default: return 0;
                }
            }
            set
            {
                switch (value)
                {
                    case 1: _type = "Кнопка"; break;
                    case 2: _type = "Рычаг"; break;
                    case 3: _type = "Тумблер"; break;
                    default: _type = "Другое"; break;
                }
                UpdateFD();
            }
        }

        public string Type
        {
            get { return _type; }
            set
            {
                if (_type == value) return;
                _type = value;
                UpdateFD();
                OnPropertyChanged("Type");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }


}