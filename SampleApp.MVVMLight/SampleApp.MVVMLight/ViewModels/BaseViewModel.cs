using Acr.UserDialogs;
using CommonServiceLocator;
using Plugin.Connectivity;
using SampleApp.MVVMLight.Services.Interface;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SampleApp.MVVMLight.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected readonly INavigationService NavigationService;

        #region Properties
        public bool IsConnected
        {
            get { return CrossConnectivity.Current.IsConnected; }
        }

        bool isBusy;

        public bool IsBusy
        {
            get
            {
                return isBusy;
            }
            set
            {
                isBusy = value;
                ShowLoading(value);
                OnPropertyChanged();
            }
        }

        private bool _isNetworkAvailable;

        public bool IsNetworkAvailable
        {
            get => _isNetworkAvailable;
            set
            {
                _isNetworkAvailable = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public BaseViewModel()
        {
            NavigationService = ServiceLocator.Current.GetInstance<INavigationService>();
            CheckConnectivity();
        }


        private void ShowLoading(bool value)
        {
            try
            {

                if (value)
                    UserDialogs.Instance.ShowLoading("Loading...", MaskType.Black);

                else
                    UserDialogs.Instance.HideLoading();
            }
            catch (Exception ex)
            {
            }
        }

        public void CheckConnectivity()
        {
            try
            {
                CrossConnectivity.Current.ConnectivityChanged += (sender, args) =>
                {
                    IsNetworkAvailable = args.IsConnected;

                    ToastConfig.DefaultPosition = ToastPosition.Top;

                    if (IsNetworkAvailable)
                    {
                        UserDialogs.Instance.Toast("Internet connected");

                    }

                    else
                        UserDialogs.Instance.Toast("Internet Lost");

                };
            }
            catch (System.Exception ex)
            {

            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
