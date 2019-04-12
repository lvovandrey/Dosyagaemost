using System.Collections.Generic;
using System.Windows.Data;

namespace DosyagWpf
{
    public class PhoneBookEntry
    {
        public string Name { get; set; }

        public PhoneBookEntry(string name)
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
        public string Type { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        
        public double FDLight
        {
            get { return 50; }
            set { FDLight = value; }
        }
        public double FDFull
        {
            get { return 80; }
            set { FDFull = value; }
        }
        public double FDUltimate
        {
            get { return 95; }
            set { FDUltimate = value; }
        }

        public double FDLightSpec
        {
            get { return 33; }
            set { FDLightSpec = value; }
        }
        public double FDFullSpec
        {
            get { return 66; }
            set { FDFullSpec = value; }
        }
        public double FDUltimateSpec
        {
            get { return 92; }
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

            
                List<PhoneBookEntry> list = new List<PhoneBookEntry>();
                list.Add(new PhoneBookEntry("test"));
                list.Add(new PhoneBookEntry("test2"));
                _phonebookEntries = new CollectionView(list);
         }

        private readonly CollectionView _phonebookEntries;
        private string _phonebookEntry;

        public CollectionView PhonebookEntries
        {
            get { return _phonebookEntries; }
        }

        public string PhonebookEntry
        {
            get { return _phonebookEntry; }
            set
            {
                if (_phonebookEntry == value) return;
                _phonebookEntry = value;
            }
        }
    }


}