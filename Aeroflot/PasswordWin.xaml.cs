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
using System.Windows.Shapes;
using System.Data.Entity;

namespace Aeroflot
{
    /// <summary>
    /// Логика взаимодействия для PasswordWin.xaml
    /// </summary>
    public partial class PasswordWin : Window
    {
        AeroflotEntities timeDB = DBContext.GetContext();
        public PasswordWin()
        {
            InitializeComponent();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            Login.Focus();            
        }

        private void User_Click(object sender, RoutedEventArgs e)
        {
            Login.Text = "User";
            Password.Password = "0000";
        }

        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            Login.Text = "Hapro";
            Password.Password = "1234";
        }

        private void LoginToProg_Click(object sender, RoutedEventArgs e)
        {
            var val = from p in timeDB.Autorizations
                      where p.Login == Login.Text && p.Password == Password.Password
                      select p;
            if (val.Count() == 1)
            {
                Data.AdvancedForTitle = $" - {val.First().SecondName} {val.First().FirstName} - {val.First().Access}";
                Data.Right = val.First().Access.First().ToString();
                DialogResult = true;
                Close();
            }
            else MessageBox.Show("Неверно введен логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timeDB.Autorizations.Load();
        }
    }
}
