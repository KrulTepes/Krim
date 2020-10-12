using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KrimWPF.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public bool Set<T>(ref T oldValue, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (Equals(oldValue, newValue))
                return false;

            oldValue = newValue;
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }
        public static Action CloseAction { get; set; }

    }
}