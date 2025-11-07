using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace prak7_WPF
{
    internal class Doctor : INotifyPropertyChanged
    {
        private int _id = 0;
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }


        private string _name = "Железнов";
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _lastName = "Евгений";

        public string LastName
        {
            get => _lastName;
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _middleName = "Иванович";
        public string MiddleName
        {
            get => _middleName;
            set
            {
                if (_middleName != value)
                {
                    _middleName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _specialisation = "Хирург";
        public string Specialisation
        {
            get => _specialisation;
            set
            {
                if (value != _specialisation)
                {
                    _specialisation = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _password = "Password";

        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged();
                }
            }
        }


        private string _repeatPassword = "";

        public string RepeatPassword
        {
            get => _repeatPassword;
            set
            {
                if (_repeatPassword != value)
                {
                    _repeatPassword = value;
                    OnPropertyChanged();
                }
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

    }
}
