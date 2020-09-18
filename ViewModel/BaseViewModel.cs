using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace LazyViewNavigation.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected enum Views
        {
            BlackView,
            WhiteView
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        protected void ChangeView(Views viewName)
        {
            Messenger.Default.Send<Views>(viewName);
        }
    }
}
