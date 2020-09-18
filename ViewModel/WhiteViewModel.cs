using LazyViewNavigation.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace LazyViewNavigation.ViewModel
{
    public class WhiteViewModel : BaseViewModel
    {
        public ICommand GoToBlackView => new Command(() =>
        {
            ChangeView(Views.BlackView);
        });
    }
}
