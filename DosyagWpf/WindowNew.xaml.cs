﻿using System;
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
using System.Windows.Shapes;

namespace DosyagWpf
{
   
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
           // DataModel.SelectedOU = DataModel.OUs.First();
            this.DataContext = DataModel;
        }
    }
}
