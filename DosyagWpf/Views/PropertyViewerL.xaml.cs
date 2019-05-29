using System;
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
    /// Логика взаимодействия для PropertyViewerL.xaml
    /// </summary>
    public partial class PropertyViewerL : UserControl
    {
        public PropertyViewerL()
        {
            InitializeComponent();
        }

    }


    public class OUFDToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string tmp = "";
            if (value != null)
            {
                double val = (double)value;
                if (val >= 0) tmp = String.Format("{0:P1}", val);
                else tmp = "Н/Д";
            }
            return tmp;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    public class OUFDToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Brush BB = new SolidColorBrush(Colors.Gray);
           
            if (value != null)
            {
                double val = (double)value;
                if ((val >= 0.05) && (val < 0.99)) BB = new SolidColorBrush(Colors.Yellow);
                else if (val >= 0.99) BB = new SolidColorBrush(Colors.Green);
                else if ((val > 0) && (val < 0.05)) BB = new SolidColorBrush(Colors.Red);

                else BB = new SolidColorBrush(Colors.Gray);
            }
            BB.Opacity = 0.5;
            return BB;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
