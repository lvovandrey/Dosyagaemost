
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

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
                      System.Windows.MessageBox.Show("ТУТ РАБОТА С NX");
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
                      try
                      {
                          CsvWrite.Write(OUs);
                      }
                      catch { System.Windows.MessageBox.Show("Ошибка экспорта файла"); }
                  }));
            }
        }


        private RelayCommand importCommand;
        public RelayCommand ImportCommand
        {
            get
            {
                return importCommand ??
                  (importCommand = new RelayCommand(obj =>
                  {

                          OpenFileDialog openFileDialog = new OpenFileDialog();
                          openFileDialog.Title = "Добавление информации";
                          openFileDialog.Filter = "CSV files(*.csv)|*.csv";

                          if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                              return;
                          // получаем выбранный файл
                          string filename = openFileDialog.FileName;
                          // сохраняем текст в файл
                          try
                          {
                              CsvWrite.Read(filename, OUs, true);

                          }
                          catch { System.Windows.MessageBox.Show("Ошибка открытия файла"); }

                  }));
            }
        }

        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ??
                  (saveCommand = new RelayCommand(obj =>
                  {
                      SaveFileDialog saveFileDialog = new SaveFileDialog();
                      saveFileDialog.Filter = "CSV files(*.csv)|*.csv";

                    if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                        return;
                    // получаем выбранный файл
                    string filename = saveFileDialog.FileName;
                      // сохраняем текст в файл
                      try
                      {
                          CsvWrite.Write(OUs, filename);
                          System.Windows.MessageBox.Show("Файл сохранен");
                      }
                      catch { System.Windows.MessageBox.Show("Ошибка сохранения файла"); }
                          

                    
                  }));
            }
        }


        private RelayCommand openCommand;
        public RelayCommand OpenCommand
        {
            get
            {
                return openCommand ??
                  (openCommand = new RelayCommand(obj =>
                  {
                      
                      MessageBoxResult res = System.Windows.MessageBox.Show("Текущая информация будет стерта и заменена данными из файла. Продолжить?", "Открытие файла", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
                      if (res == MessageBoxResult.OK)
                      {
                          OpenFileDialog openFileDialog = new OpenFileDialog();
                          openFileDialog.Filter = "CSV files(*.csv)|*.csv";

                          if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                              return;
                          // получаем выбранный файл
                          string filename = openFileDialog.FileName;
                          // сохраняем текст в файл
                          try
                          {
                              ObservableCollection<OU> NewOUs = new ObservableCollection<OU>();
                              NewOUs = CsvWrite.Read(filename, OUs, false);
                              OUs.Clear(); 
                              foreach  (OU item in NewOUs)
                              {
                                  OUs.Add(item);
                              }
                          }
                          catch { System.Windows.MessageBox.Show("Ошибка открытия файла"); }
                      }
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
