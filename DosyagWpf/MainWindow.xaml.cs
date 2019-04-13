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
        public Model DataModel; //КРИВОЙ ЗАКОС ПОД MVVM
       
        public MainWindow()
        {
            InitializeComponent();
            

            DataModel = new Model();
            DataModel.OUs.Add(new OU(DataModel.OUs.Count()+1, "ВКЛ-Выкл", "Кнопка", 1134, 2311, 1123));
            DataModel.OUs.Add(new OU(DataModel.OUs.Count() + 1,"Щелк-Чик", "Тумблер", 1231, 121, 1111323));
            DataModel.OUs.Add(new OU(DataModel.OUs.Count() + 1, "Пым-Пам", "Рычаг", 11241, 234411, 1100023));
            DataModel.SelectedOU = DataModel.OUs.First();
            this.DataContext = DataModel;
        }
        // добавление
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            DataModel.OUs.Add(new OU(DataModel.OUs.Count() + 1, "", "Тумблер", 0, 0, 0)); //Номера криво назначаются... бывают дубли но это ерунда
        }

        // удаление
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DataModel.OUs.Remove(DataModel.SelectedOU);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Результат из DLL " + CppLib.SomeFunc(10).ToString()); // САБЖ.
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("А тут мы выгрузим данные куда-нибудь например в CSV. Ну это мы сами сделаем - как нам нравится"); // САБЖ.

        }
    }
}
