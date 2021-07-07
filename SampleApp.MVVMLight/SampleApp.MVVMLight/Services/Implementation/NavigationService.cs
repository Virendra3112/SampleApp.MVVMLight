using SampleApp.MVVMLight.Services.Interface;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SampleApp.MVVMLight.Services.Implementation
{
    public class NavigationService : INavigationService
    {
        private readonly Dictionary<string, Type> _pagesByKey;

        public NavigationService()
        {
            _pagesByKey = new Dictionary<string, Type>();
        }

        public MainPage MainPage//ToDo: Add Master Details page
        {
            get { return (MainPage)Application.Current.MainPage; }
        }


        public void Configure(string pageKey, Type pageType)
        {
            lock (_pagesByKey)
            {
                if (_pagesByKey.ContainsKey(pageKey))
                {
                    _pagesByKey[pageKey] = pageType;
                }
                else
                {
                    _pagesByKey.Add(pageKey, pageType);
                }
            }
        }

        public string CurrentPageKey => throw new NotImplementedException();

        public async void GoBack()
        {
            await MainPage.Navigation.PopAsync();
        }

        public void HideDrawerMenu()
        {
            throw new NotImplementedException();
        }

        public void NavigateTo(string pageKey)
        {

        }

        public void NavigateTo(string pageKey, object parameter)
        {
            throw new NotImplementedException();
        }

        public async void PopToRoot()
        {
            await MainPage.Navigation.PopToRootAsync();
        }
    }
}
