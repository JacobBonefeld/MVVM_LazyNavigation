using GalaSoft.MvvmLight.Messaging;
using LazyViewNavigation.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace LazyViewNavigation.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public enum Views
        {
            BlackView,
            WhiteView
        }

        /// <summary>
        /// Command for changing views
        /// Input string from xaml gets converted to enum
        /// Tells MainWindowViewModel to change the view
        /// </summary>
        public ICommand ChangeView => new NewCommand((object obj) =>
        {
            string input = obj as string;

            Messenger.Default.Send<Views>((Views)Enum.Parse(typeof(Views), input));
        });


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        
    }
}
