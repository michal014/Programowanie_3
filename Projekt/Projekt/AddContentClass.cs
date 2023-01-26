using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Projekt
{
    public class AddContentClass: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        string _name;
        string _type;
        int _numberofepisodes;
        string _description;
        string _genres;
        string _producers;
        string _picture_location;
        string _separator;

        public string name
        {
            get 
            { 
                return _name; 
            }
            set
            {
                _name = value;
                OnPropertyChanged("name");
            }
        }
        public string type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                OnPropertyChanged("type");
            }
        }
        public int numberofepisodes
        {
            get
            {
                return _numberofepisodes;
            }
            set
            {
                _numberofepisodes = value;
                OnPropertyChanged("numberofepisodes");
            }
        }
        public string description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged("description");
            }
        }
        public string genres
        {
            get
            {
                return _genres;
            }
            set
            {
                _genres = value;
                OnPropertyChanged("genres");
            }
        }
        public string producers
        {
            get
            {
                return _producers;
            }
            set
            {
                _producers = value;
                OnPropertyChanged("producers");
            }
        }
        public string picture_location
        {
            get
            {
                return _picture_location;
            }
            set
            {
                _picture_location = value;
                OnPropertyChanged("picture_location");
            }
        }

        public string separator
        {
            get
            {
                return _separator;
            }
            set
            {
                _separator = value;
                OnPropertyChanged("separator");
            }
        }

        public AddContentClass()
        {
            this._name = string.Empty;
            this._type = string.Empty;
            this._numberofepisodes = 0;
            this._description = string.Empty;
            this._genres = string.Empty;
            this._producers = string.Empty;
            this._picture_location = string.Empty;
            this._separator = string.Empty;
        }

        public AddContentClass(string name, string type, int numberofepisodes, string description, string genres, string producers, string picture_location,string separator)
        {
            this._name = name;
            this._type = type;
            this._numberofepisodes = numberofepisodes;
            this._description = description;
            this._genres = genres;
            this._producers = producers;
            this._picture_location = picture_location;
            this._separator = separator;
        }

        public AddContentClass(AddContentClass acc)
        {
            this._name = acc._name;
            this._type = acc._type;
            this._numberofepisodes = acc._numberofepisodes;
            this._description = acc._description;
            this._genres = acc._genres;
            this._producers = acc._producers;
            this._picture_location = acc._picture_location;
            this._separator = acc._separator;
        }
    }
}
