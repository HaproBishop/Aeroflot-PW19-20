using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace Aeroflot
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        AeroflotEntities db = DBContext.GetContext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PasswordWin win = new PasswordWin()
            {
                Owner = this
            };
            if (win.ShowDialog() == false) Close();
            Title += Data.AdvancedForTitle;
            if (Data.Right == "П")
            {
                AddRecord.IsEnabled = EditRecord.IsEnabled = RmRecord.IsEnabled = ToView.IsEnabled = false;
            }
            db.Races.Load();
            DBView.ItemsSource = db.Races.Local.ToBindingList();
        }

        private void AddRecord_Click(object sender, RoutedEventArgs e)
        {
            Recording rec = new Recording
            {
                Owner = this
            };
            if (rec.ShowDialog() == true)
            {
                MessageBox.Show("Запись добавлена успешно", "Добавление записи", MessageBoxButton.OK, MessageBoxImage.Information);
                DBView.Items.Refresh();
            }
        }

        private void EditRecord_Click(object sender, RoutedEventArgs e)
        {
            int iRow = DBView.SelectedIndex;
            if (iRow != -1)
            {
                Race curRace = (Race)DBView.Items[iRow];
                Recording rec = new Recording(curRace)
                {
                    Owner = this
                };
                if (rec.ShowDialog() == true)
                {
                    MessageBox.Show("Запись изменена успешно", "Изменение записи", MessageBoxButton.OK, MessageBoxImage.Information);
                    DBView.Items.Refresh();
                }
            }
            else MessageForNoSelected();
        }

        private void RmRecord_Click(object sender, RoutedEventArgs e)
        {
            int iRow = DBView.SelectedIndex;
            if (iRow != -1)
            {
                if (QueAcceptRm() == true)
                {
                    if (DBView.SelectedItems.Count == 1)
                    {
                        Race curRace = (Race)DBView.Items[iRow];
                        db.Races.Remove(curRace);
                    }
                    else
                    {
                        while (DBView.SelectedItems.Count != 0)
                        {
                            db.Races.Remove((Race)DBView.SelectedItem);
                        }
                    }
                    DBView.Items.Refresh();
                }
            }
            else MessageForNoSelected();
        }
        private void MessageForNoSelected()
        {
            MessageBox.Show("Перед выполнением действия необходимо выбрать запись", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        private bool? QueAcceptRm()
        {
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить выбранную(ые) запись(и)?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes) return true;
            return false;
        }

        private void ToView_Click(object sender, RoutedEventArgs e)
        {
            Viewer viewer = new Viewer()
            {
                Owner = this
            };
            if (viewer.ShowDialog() == true)
            {
                if (viewer.que != null) DBView.ItemsSource = viewer.que.ToListAsync().Result;
                else
                {
                    db = new AeroflotEntities();
                    db.Races.Load();
                    DBView.ItemsSource = db.Races.Local.ToBindingList();
                }
            }
        }

        private void AboutProgram_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вариант 8. Сведения о рейсах Аэрофлота.База данных должна содержать следующую информацию:" +
            "номер рейса, пункт назначения, время вылета, время прибытия, количество свободных" +
            "мест, тип самолета и его вместимость.\n" +
            "Разработчик: Лопаткин Сергей ИСП-31 (Hapro Bishop)", "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Данная программа имеет следующие особенности:\n" +
                "1) Позволяет изменять и удалять по выбранной записи\n" +
                "2) Позволяет при помощи 'Просмотр' выполнить удаление записи по ID, " +
                "Изменение указанной записи с выбранным условием (столбцом и </=/>)\n" +
                "3) Позволяет добавить запись через бланк, а также изменить ее", "Справка", MessageBoxButton.OK, MessageBoxImage.Question);
        }

        private void RefreshView_Click(object sender, RoutedEventArgs e)
        {
            DBView.ItemsSource = db.Races.Local.ToBindingList();
        }
    }
}
