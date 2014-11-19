using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using ReactiveUI;

namespace M3Conf_ReactiveUI
{
    public class ClassicMainWindowViewModel : ViewModelBase
    {
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    RaisePropertyChanged("FirstName");
                    RaisePropertyChanged("FullName");
                    RaisePropertyChanged("Sentence");
                }
                
            }
        } 
        
        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    RaisePropertyChanged("LastName");
                    RaisePropertyChanged("FullName");
                    RaisePropertyChanged("Sentence");
                }
            }
        }

        private string _favoriteColor;
        public string FavoriteColor
        {
            get { return _favoriteColor; }
            set
            {
                if (_favoriteColor != value)
                {
                    _favoriteColor = value;
                    RaisePropertyChanged("FavoriteColor");
                    RaisePropertyChanged("Sentence");
                }
            }
        }

        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }

        public string Sentence
        {
            get { return string.Format("{0}'s favorite color is {1}", FullName, FavoriteColor); }
        }
    }

    public class ReactiveMainWindowViewModel : ReactiveObject
    {
        
    }
}
