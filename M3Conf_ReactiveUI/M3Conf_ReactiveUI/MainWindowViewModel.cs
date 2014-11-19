﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
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
                    //RaisePropertyChanged("Sentence");
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
                    //RaisePropertyChanged("Sentence");
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
          private string _firstName;
        private string _lastName;
        private string _favoriteColor;


        ObservableAsPropertyHelper<string> _fullName;
        public string FullName
        {
            get { return _fullName.Value; }
        }


        ObservableAsPropertyHelper<string> _sentence;
        public string Sentence
        {
            get { return _sentence.Value; }
        }
        public ReactiveMainWindowViewModel()
        {
            this.WhenAnyValue(x => x.FirstName, x => x.LastName, (first, last) => new {first,last})
                .Select(name => string.Format("{0} {1}", name.first, name.last))
                .ToProperty(this, x => x.FullName, out _fullName);

            this.WhenAnyValue(x => x.FullName, x => x.FavoriteColor, (full,color) => new {full,color})
                .Select(x => string.Format("{0}'s favorite color is: {1}", x.full, x.color))
                .ToProperty(this, x => x.Sentence, out _sentence);
        }

        public string FirstName
        {
            get { return _firstName; }
            set { this.RaiseAndSetIfChanged(ref _firstName, value); }
        }

        public string LastName
        {
            get { return _lastName; }
            set { this.RaiseAndSetIfChanged(ref _lastName, value); }
        }

        public string FavoriteColor
        {
            get { return _favoriteColor; }
            set { this.RaiseAndSetIfChanged(ref _favoriteColor, value); }
        }
    }
}
