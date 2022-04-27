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

namespace Aeroflot
{
    /// <summary>
    /// Логика взаимодействия для Recording.xaml
    /// </summary>
    public partial class Recording : Window
    {
        bool _isEdit;
        Race race;
        AeroflotEntities timeDB = DBContext.GetContext();
        public Recording()
        {
            InitializeComponent();
        }
        public Recording(Race timeRace)
        {
            InitializeComponent();
            RaceID.IsReadOnly = true;
            _isEdit = true;
            DoIt.Content = "Изменить";
            Title = "Редактировать записи";
            race = timeRace;
        }

        private void DoIt_Click(object sender, RoutedEventArgs e)
        {
            if (race == null) race = new Race();
            int raceID, freePlaceCount, airplaneCapacity;
            TimeSpan departureTime, arriveTime;
            try
            {
                raceID = Convert.ToInt32(RaceID.Text);
                if (raceID < 1) throw new Exception();
            }
            catch
            {
                MessageForCorrect("'Код'");
                RaceID.Focus();
                return;
            }
            if (ArrivePlace.Text == "")
            {
                MessageForEmpty("'Место прибытия'");
                RaceID.Focus();
                return;
            }
            try
            {
                departureTime = new TimeSpan(Convert.ToInt32(DepartureTimeHours.Text), Convert.ToInt32(DepartureTimeMinutes.Text), 0);
                if (departureTime.Hours > 23 || departureTime.Minutes > 59) throw new Exception();
            }
            catch
            {
                MessageForCorrect("'Время отправления'");
                DepartureTimeHours.Focus();
                return;
            }
            try
            {
                arriveTime = new TimeSpan(Convert.ToInt32(ArriveTimeHours.Text), Convert.ToInt32(ArriveTimeMinutes.Text), 0);
                if (arriveTime.Hours > 23 || arriveTime.Minutes > 59) throw new Exception();
            }
            catch
            {
                MessageForCorrect("'Время прибытия'");
                ArriveTimeHours.Focus();
                return;
            }
            try
            {
                freePlaceCount = Convert.ToInt32(FreePlaceCount.Text);
                if (freePlaceCount < 0) throw new Exception();
            }
            catch
            {
                MessageForCorrect("'Свободные места'");
                FreePlaceCount.Focus();
                return;
            }
            if (AirplaneKind.Text == "")
            {
                MessageForEmpty("'Вид самолета'");
                AirplaneKind.Focus();
                return;
            }
            try
            {
                airplaneCapacity = Convert.ToInt32(AirplaneCapacity.Text);
                if (airplaneCapacity < 0) throw new Exception();
            }
            catch
            {
                MessageForCorrect("'Вместимость'");
                AirplaneCapacity.Focus();
                return;
            }
            ToSubject(raceID, ArrivePlace.Text, departureTime, arriveTime, freePlaceCount, AirplaneKind.Text, airplaneCapacity);
            if (!_isEdit) timeDB.Races.Add(race);
            timeDB.SaveChanges();
            DialogResult = true;
            Close();
        }
        private void ToSubject(int ID, string arrivePlace, TimeSpan departureTime, TimeSpan arriveTime, int freePlaceCount, string airplaneKind, int airplaneCapacity)
        {
            race.RaceID = ID;
            race.ArrivePlace = arrivePlace;
            race.DepartureTime = departureTime;
            race.ArriveTime = arriveTime;
            race.FreePlaceCount = freePlaceCount;
            race.AirplaneKind = airplaneKind;
            race.AirplaneCapacity = airplaneCapacity;
        }
        private void MessageForCorrect(string text)
        {
            MessageBox.Show($"Некорректно введено значение для {text}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void MessageForEmpty(string text)
        {
            MessageBox.Show($"Не может быть пустого значения для {text}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RaceID.Focus();
            if (_isEdit)
            {
                RaceID.Text = race.RaceID.ToString();
                ArrivePlace.Text = race.ArrivePlace;
                DepartureTimeHours.Text = race.DepartureTime.Hours.ToString();
                DepartureTimeMinutes.Text = race.DepartureTime.Minutes.ToString();
                ArriveTimeHours.Text = race.ArriveTime.Hours.ToString();
                ArriveTimeMinutes.Text = race.ArriveTime.Minutes.ToString();
                FreePlaceCount.Text = race.FreePlaceCount.ToString();
                AirplaneKind.Text = race.AirplaneKind;
                AirplaneCapacity.Text = race.AirplaneCapacity.ToString();
            }
        }
    }
}
