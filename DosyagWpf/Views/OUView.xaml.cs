﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DosyagWpf.Views
{
    /// <summary>
    /// Логика взаимодействия для OUView.xaml
    /// </summary>
    public partial class OUView : UserControl
    {
        public OUView()
        {
            InitializeComponent();


        }
    }

    public class OUTypeToSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Uri tmp = new Uri("DosyagWpf;component/Images/PNG/Delete.png",UriKind.Relative);

            if (value != null)
            {
                int val = (int)value;
                switch (val)
                {
                    case 3: { tmp = new Uri("DosyagWpf;component/Images/tumbler.png", UriKind.Relative); break; }
                    case 1: { tmp = new Uri("DosyagWpf;component/Images/button.png", UriKind.Relative); break; }
                    case 2: { tmp = new Uri("DosyagWpf;component/Images/lever.png", UriKind.Relative); break; }
                    default:
                        break;
                }
            }
            return tmp;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    public class OUFDToColorConverter2 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Brush BB = new SolidColorBrush(Colors.Gray);

            if (value != null)
            {
                double val = (double)value;
                if ((val >= 0.05) && (val < 0.99)) BB = new SolidColorBrush(Colors.Yellow);
                else if (val >= 0.99) BB = new SolidColorBrush(Colors.Green);
                else if ((val > -0.1) && (val < 0.05)) BB = new SolidColorBrush(Colors.Red);

                else BB = new SolidColorBrush(Colors.Gray);
            }
            
            return BB;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    public class OUWidthOfItemConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double width = 30;
           if (value != null)
            {
                    double val = (double)value;
                    double param;

                    if ((parameter != null) && (parameter is string))
                    {
                        double.TryParse((string)parameter, out param);
                        width = val - param;
                    }
                    else width = val - 20;
              
            }

            return width;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
