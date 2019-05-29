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
    /// Логика взаимодействия для OUView.xaml
    /// </summary>
    public partial class OUView : UserControl
    {
        public OUView()
        {
            InitializeComponent();


        }
    }



    //public class OUTypeToSourceConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        return ((DateTime)value).ToString("dd.MM.yyyy");
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        return DependencyProperty.UnsetValue;
    //    }
    //}
}
