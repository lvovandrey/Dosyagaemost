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

namespace DosyagWpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
    //    public Model DataModel; //КРИВОЙ ЗАКОС ПОД MVVM
       
        public MainWindow()
        {
            InitializeComponent();
            

            //DataModel = new Model();
            //DataModel.OUs.Add(new OU(DataModel.OUs.Count() + 1, "Орган управления сбросом", "Кнопка", 100, 100, 100));
            //DataModel.OUs.Add(new OU(DataModel.OUs.Count() + 1, "Тумблер включения электропитания", "Тумблер", 100, 100, 200));
            //DataModel.OUs.Add(new OU(DataModel.OUs.Count() + 1, "Выпуск шасси", "Рычаг", -100, 100, 100));
            //DataModel.OUs.Add(new OU(DataModel.OUs.Count() + 1, "Гашетка", "Кнопка", 100, 100, 0));
            //DataModel.OUs.Add(new OU(DataModel.OUs.Count() + 1, "Передача изобажения ВЫКЛ", "Тумблер", 333, 123, 323));
            //DataModel.OUs.Add(new OU(DataModel.OUs.Count() + 1, "Стоп-кран левого двигателя", "Рычаг", 555, 411, 463));
            //DataModel.SelectedOU = DataModel.OUs.First();
            //this.DataContext = DataModel;
        }
        // добавление
        private void Add_Click(object sender, RoutedEventArgs e)
        {
          //  DataModel.OUs.Add(new OU(DataModel.OUs.Count() + 1, "", "Тумблер", 0, 0, 0)); //Номера криво назначаются... бывают дубли но это ерунда
        }

        // удаление
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            //DataModel.OUs.Remove(DataModel.SelectedOU);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        //    MessageBox.Show("Тут надо получить данные из NX и вставить их в соответствующие поля");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
       //     CsvWrite.Write(DataModel.OUs);
        }

        private void levelsList_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (e.ExtentHeightChange > 0.0)
                ((ScrollViewer)e.OriginalSource).ScrollToEnd();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            WindowNew wn = new WindowNew();
            wn.DataContext = this.DataContext;
            wn.Show();
   //         DataModel.windowNew = wn;
        }
    }
}
