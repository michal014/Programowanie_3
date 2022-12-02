using Statki.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Resources;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Statki
{
    internal class Game : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        ObservableCollection<int> player1 = new ObservableCollection<int> { };
        ObservableCollection<int> player2 = new ObservableCollection<int> { };

        public ObservableCollection<int> Player1
        {
            get
            {
                return player1;
            }
            set
            {
                player1 = value;
                OnPropertyChanged("PersonID");
            }
        }

        public ObservableCollection<int> Player2
        {
            get
            {
                return player2;
            }
            set
            {
                player2 = value;
                OnPropertyChanged("PersonID");
            }
        }

        public Game(int[] borderp1, int[] borderp2)
        {
            foreach (int person in borderp1)
            {
                player1.Add(person);
            }

            foreach (int person2 in borderp2)
            {
                player2.Add(person2);
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler is not null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class GameValueToResourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch (value)
            {
                case 3:
                    return new ImageBrush(new BitmapImage(new Uri(Environment.CurrentDirectory + "/Resources/destroyed_boat.png")));
                case 2:
                    return new ImageBrush(new BitmapImage(new Uri(Environment.CurrentDirectory + "/Resources/shoot.png")));
                case 1:
                    return new ImageBrush(new BitmapImage(new Uri(Environment.CurrentDirectory + "/Resources/boat.png")));
                case 0:
                    return new ImageBrush(new BitmapImage(new Uri(Environment.CurrentDirectory + "/Resources/water.png")));
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.ToString() == (Environment.CurrentDirectory + "/Resources/destroyed_boat.png"))
            {
                return 3;
            }
            else if (value.ToString() == (Environment.CurrentDirectory + "/Resources/shoot.png"))
            {
                return 2;
            }
            else if (value.ToString() == (Environment.CurrentDirectory + "/Resources/boat.png"))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }

    public class GameValueToResourceConverter2 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch (value)
            {
                case 3:
                    return new ImageBrush(new BitmapImage(new Uri(Environment.CurrentDirectory + "/Resources/destroyed_boat.png")));
                case 2:
                    return new ImageBrush(new BitmapImage(new Uri(Environment.CurrentDirectory + "/Resources/shoot.png")));
                case 1:
                    return new ImageBrush(new BitmapImage(new Uri(Environment.CurrentDirectory + "/Resources/water.png")));
                case 0:
                    return new ImageBrush(new BitmapImage(new Uri(Environment.CurrentDirectory + "/Resources/water.png")));
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.ToString() == (Environment.CurrentDirectory + "/Resources/destroyed_boat.png"))
            {
                return 3;
            }
            else if (value.ToString() == (Environment.CurrentDirectory + "/Resources/shoot.png"))
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }
    }
}
