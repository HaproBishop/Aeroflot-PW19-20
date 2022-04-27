using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Aeroflot
{
    /// <summary>
    /// Логика взаимодействия для Viewer.xaml
    /// </summary>
    public partial class Viewer : Window
    {
        public IQueryable que;
        AeroflotEntities timeDB = DBContext.GetContext();

        public Viewer()
        {
            InitializeComponent();            
        }

        private void UpdateAct_Checked(object sender, RoutedEventArgs e)
        {
            RepBox.Visibility = Visibility.Visible;
            RaceID.IsChecked = false;
            RaceID.IsEnabled = false;
        }

        private void UpdateAct_Unchecked(object sender, RoutedEventArgs e)
        {
            RepBox.Visibility = Visibility.Hidden;            
            RaceID.IsEnabled = true;
        }

        private void DoIt_Click(object sender, RoutedEventArgs e)
        {
            if (CurVal.Text != "")
            {
                if (SelectAct.IsChecked == true)
                {
                    ViewSelect();
                }
                if (UpdateAct.IsChecked == true)
                {
                    if (RepVal.Text == "")
                    {
                        MessageBox.Show("Пустое поле значения для замены!", "Обновление", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    ViewUpdate();
                }
                if (DeleteAct.IsChecked == true)
                {
                    ViewDelete();
                }
                DialogResult = true;
                Close();
            }
            else MessageBox.Show("Поле значения не может быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void ViewSelect()//-----------------------------------------ViewSelect
        {
            if (RaceID.IsChecked == true)//RaceID
            {
                int raceID = 0;
                if (ProoverNumber(ref raceID, true) == false) return;
                que = from p in timeDB.Races
                      where p.RaceID == raceID
                      select p;
            }
            if (ArrivePlace.IsChecked == true)//ArrivePlace
            {
                que = from p in timeDB.Races
                      where p.ArrivePlace.Contains(CurVal.Text)
                      select p;
            }
            if (AirplaneCapacity.IsChecked == true)//AirplaneCapacity
            {
                int airplaneCapacity = 0;
                if (ProoverNumber(ref airplaneCapacity, true) == false) return;
                if (CapacityEqual.IsChecked == true)
                {
                    que = from p in timeDB.Races
                          where p.AirplaneCapacity == airplaneCapacity
                          select p;
                }
                if (CapacityLess.IsChecked == true)
                {
                    que = from p in timeDB.Races
                          where p.AirplaneCapacity < airplaneCapacity
                          select p;
                }
                if (CapacityMore.IsChecked == true)
                {
                    que = from p in timeDB.Races
                          where p.AirplaneCapacity > airplaneCapacity
                          select p;
                }
            }
            if (FreePlaces.IsChecked == true)//AirplaneCapacity
            {
                int freePlaces = 0;
                if (ProoverNumber(ref freePlaces, true) == false) return;
                if (FreePlacesEqual.IsChecked == true)
                {
                    que = from p in timeDB.Races
                          where p.FreePlaceCount == freePlaces
                          select p;
                }
                if (FreePlacesLess.IsChecked == true)
                {
                    que = from p in timeDB.Races
                          where p.FreePlaceCount < freePlaces
                          select p;
                }
                if (FreePlacesMore.IsChecked == true)
                {
                    que = from p in timeDB.Races
                          where p.FreePlaceCount > freePlaces
                          select p;
                }
            }
        }
        private void ViewUpdate()
        {
            string column = "", action = "=";
            SqlParameter curPar = new SqlParameter(), repPar = new SqlParameter();
            if (ArrivePlace.IsChecked == true)//ArrivePlace
            {
                column = "ArrivePlace";
                curPar = new SqlParameter()
                {
                    ParameterName = "@CurVal",
                    Value = CurVal.Text
                };
                repPar = new SqlParameter()
                {
                    ParameterName = "@RepVal",
                    Value = RepVal.Text
                };                
            }
            if (AirplaneCapacity.IsChecked == true)//AirplaneCapacity
            {
                column = "AirplaneCapacity";
                int curAirplaneCapacity = 0, repAirplaneCapacity = 0;
                if (ProoverNumber(ref curAirplaneCapacity, true) == false) return;
                if (ProoverNumber(ref repAirplaneCapacity, false) == false) return;
                curPar = new SqlParameter()
                {
                    ParameterName = "@CurVal",
                    Value = curAirplaneCapacity
                };
                repPar = new SqlParameter()
                {
                    ParameterName = "@RepVal",
                    Value = repAirplaneCapacity
                };
                if (CapacityLess.IsChecked == true)
                {
                    action = "<";
                }
                if (CapacityMore.IsChecked == true)
                {
                    action = ">";
                }
            }
            if (FreePlaces.IsChecked == true)//AirplaneCapacity
            {
                column = "FreePlaceCount";
                int curFreePlaces = 0, repFreePlaces = 0;
                if (ProoverNumber(ref curFreePlaces, true) == false) return;
                if (ProoverNumber(ref repFreePlaces, false) == false) return;
                curPar = new SqlParameter()
                {
                    ParameterName = "@CurVal",
                    Value = curFreePlaces
                };
                repPar = new SqlParameter()
                {
                    ParameterName = "@RepVal",
                    Value = repFreePlaces
                };
                if (FreePlacesLess.IsChecked == true)
                {
                    action = "<";
                }
                if (FreePlacesMore.IsChecked == true)//--------------------------------------------------------UPDATECONTEXT
                {
                    action = ">";
                }
            }
            timeDB.Database.ExecuteSqlCommand($"Update Races Set {column} = @RepVal Where {column} {action} @CurVal", curPar, repPar);//Обновить контекст
        }
        private void ViewDelete()
        {
            int raceID = 0;
            if (ProoverNumber(ref raceID, true) == false) return;
            SqlParameter id = new SqlParameter()
            {
                ParameterName = "@ID",
                Value = raceID
            };
            timeDB.Database.ExecuteSqlCommand("Delete From Races Where RaceID = @ID", id);
        }
        private bool? ProoverNumber(ref int val, bool isCurrentVal)
        {
            try
            {
                if (isCurrentVal) val = Convert.ToInt32(CurVal.Text);
                else val = Convert.ToInt32(RepVal.Text);
                if (val < 0) throw new Exception();
            }
            catch
            {
                MessageBox.Show("Некорректно введено значение для замены!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private void DeleteAct_Checked(object sender, RoutedEventArgs e)
        {
            RaceID.IsChecked = true;
            ArrivePlace.IsEnabled = AirplaneCapacity.IsEnabled = FreePlaces.IsEnabled = false;                          
        }

        private void DeleteAct_Unchecked(object sender, RoutedEventArgs e)
        {
            ArrivePlace.IsEnabled = AirplaneCapacity.IsEnabled = FreePlaces.IsEnabled = true;
        }
    }
}
