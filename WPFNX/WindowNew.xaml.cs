using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFNX
{

    public static class Sets
    {
        public static string WPFNXLibDir = "";
    } 
    
    /// <summary>
    /// Логика взаимодействия для WindowNew.xaml
    /// </summary>
    public partial class WindowNew : Window
    {
        
        public Model DataModel; //КРИВОЙ ЗАКОС ПОД MVVM

        public WindowNew()
        {
            InitializeComponent();

            DataModel = new Model();
            this.DataContext = DataModel;
            DataModel.windowNew = this;
            Sets.WPFNXLibDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        }
    }
}
