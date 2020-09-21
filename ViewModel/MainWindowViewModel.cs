using GalaSoft.MvvmLight.Messaging;
using LazyViewNavigation.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace LazyViewNavigation.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {

        #region Constructor
        public MainWindowViewModel()
        {
            // Make the viewmodels ready, but do not create before they are needed
            CreateViewModelList();

            // Default viewmodel is the black one
            CurrentViewModel = ViewModelDictionary[Views.BlackView].Value;
            //CurrentViewModel = ViewModelList[0].Value;

            // Listen for view change requests
            RegisterViewChangeRequests();
        }

        #endregion

        #region Properties

        // Viewmodel is bound to the main window view
        // Whenever this is changed, the window will automatically show the corresponding view
        private BaseViewModel _currentViewModel;

        public BaseViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Private fields
        private Dictionary<Views, Lazy<BaseViewModel>> ViewModelDictionary;
        private List<Lazy<BaseViewModel>> ViewModelList;
        #endregion

        #region Private methods

        /// <summary>
        /// Used to register whenever a viewmodel wants to change with 
        /// </summary>
        private void RegisterViewChangeRequests()
        {
            Messenger.Default.Register<Views>(this, (Action) =>
           {
               CurrentViewModel = ViewModelDictionary[Action].Value;

               /*
               switch (Action)
               {
                   case Views.BlackView:
                       CurrentViewModel = ViewModelList[0].Value;
                       break;
                   case Views.WhiteView:
                       CurrentViewModel = ViewModelList[1].Value;
                       break;
                       
               }
               */
           });
        }

        /// <summary>
        /// Creates a dicticonary with all our viewmodels
        /// Key to access the Lazy viewmodel is the Views enum, which is defined in BaseViewModel
        /// </summary>
        private void CreateViewModelList()
        {
            Debug.WriteLine("Starting create list");
            ViewModelDictionary = new Dictionary<Views, Lazy<BaseViewModel>>
            {
                { Views.BlackView, new Lazy<BaseViewModel>(()=> new BlackViewModel())},
                { Views.WhiteView, new Lazy<BaseViewModel>(()=> new WhiteViewModel())}
            };
            Debug.WriteLine("Ended creating list");
            /*
            ViewModelList = new List<Lazy<BaseViewModel>>
            {
                new Lazy<BaseViewModel>(() => new BlackViewModel()),
                new Lazy<BaseViewModel>(() => new WhiteViewModel())
            };
            */
        }

        #endregion

    }
}
