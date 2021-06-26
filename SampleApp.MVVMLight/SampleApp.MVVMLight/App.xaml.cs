using SampleApp.MVVMLight.Helpers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.MVVMLight
{
    public partial class App : Application
    {
        private static ViewModelLocator _viewModelLocator;

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        public static ViewModelLocator ViewModelLocator
        {
            get { return _viewModelLocator ?? (_viewModelLocator = new ViewModelLocator()); }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
