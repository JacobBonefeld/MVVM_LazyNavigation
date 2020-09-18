using LazyViewNavigation.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace LazyViewNavigation.ViewModel
{
    public class BlackViewModel : BaseViewModel
    {
        public ICommand GoToWhiteView => new Command(() =>
        {
            ChangeView(Views.WhiteView);
        });
    }
}
