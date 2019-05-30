using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для PropertyViewerFloat.xaml
    /// </summary>
    public partial class PropertyViewerFloat : UserControl
    {
        public PropertyViewerFloat()
        {
            InitializeComponent();
        }


        private void TextBox_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (!((TextBox)sender).IsFocused) return;
            double x = (double)this.DataContext;
            if (e.Delta > 0) x++;
            else x--;
            this.DataContext = (object)x;
            e.Handled = true;
        }
    }
}
