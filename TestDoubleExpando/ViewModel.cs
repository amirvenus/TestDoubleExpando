using System;
using System.ComponentModel;
using System.Dynamic;
using System.Runtime.CompilerServices;

namespace TestDoubleExpando
{
    public class ViewModel : INotifyPropertyChanged
    {
        private static ViewModel _instance;

        public static ViewModel Instance => _instance ??= new ViewModel();

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var propertyChanged = PropertyChanged;
            propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private ExpandoObject _expando;
        public ExpandoObject Expando
        {
            get => _expando ??= new ExpandoObject();
            set
            {
                _expando = value;
                OnPropertyChanged(nameof(Expando));
            }
        }

    }
}
