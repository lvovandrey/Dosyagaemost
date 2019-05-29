using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DosyagWpf
{
    /// <summary>
    /// По сути это ViewModel
    /// </summary>
    public class Model
    {
        public ObservableCollection<OU> OUs { get; set; }
        public OU SelectedOU { get; set; }
        public string Test { get; set; }
        public WindowNew windowNew;
        public Model()
        {
            SelectedOU = new OU(0,"", "", 0, 0, 0);
            OUs = new ObservableCollection<OU>();
            Test = "Test 1";
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      OUs.Add(new OU(OUs.Count() + 1, "", "Тумблер", 0, 0, 0)); //Номера криво назначаются... бывают дубли но это ерунда
                  }));
            }
        }

        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new RelayCommand(obj =>
                  {
                      OUs.Remove(SelectedOU);
                  }));
            }
        }
        private RelayCommand measureCommand;
        public RelayCommand MeasureCommand
        {
            get
            {
                return measureCommand ??
                  (measureCommand = new RelayCommand(obj =>
                  {
                      MessageBox.Show("ТУТ РАБОТА С NX");
                  }));
            }
        }
        private RelayCommand exportCommand;
        public RelayCommand ExportCommand
        {
            get
            {
                return exportCommand ??
                  (exportCommand = new RelayCommand(obj =>
                  {
                      CsvWrite.Write(OUs);
                  }));
            }
        }

        private RelayCommand showTableCommand;
        public RelayCommand ShowTableCommand
        {
            get
            {
                return showTableCommand ??
                  (showTableCommand = new RelayCommand(obj =>
                  {
                      windowNew.TableCol.Width = new System.Windows.GridLength(1000);
                      windowNew.ListCol.Width = new System.Windows.GridLength(0);
                  }));
            }
        }
        private RelayCommand hideTableCommand;
        public RelayCommand HideTableCommand
        {
            get
            {
                return hideTableCommand ??
                  (hideTableCommand = new RelayCommand(obj =>
                  {
                      windowNew.TableCol.Width = new System.Windows.GridLength(0);
                      windowNew.ListCol.Width = new System.Windows.GridLength(500);
                  }));
            }
        }


        private RelayCommand aboutCommand;
        public RelayCommand AboutCommand
        {
            get
            {
                return aboutCommand ??
                  (aboutCommand = new RelayCommand(obj =>
                  {
                      AboutWindow aboutWindow = new AboutWindow();
                      aboutWindow.Show();
                  }));
            }
        }


        private RelayCommand exitCommand;
        public RelayCommand ExitCommand
        {
            get
            {
                return exitCommand ??
                  (exitCommand = new RelayCommand(obj =>
                  {
                      windowNew.Close();
                  }));
            }
        }
    }
}
