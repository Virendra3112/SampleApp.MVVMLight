using SampleApp.MVVMLight.Services.Interface;
using System;
using System.Collections.Generic;

namespace SampleApp.MVVMLight.Services.Implementation
{
    public class NavigationService : INavigationService
    {
        private readonly Dictionary<string, Type> _pagesByKey;

        public NavigationService()
        {
            _pagesByKey = new Dictionary<string, Type>();
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

        public void GoBack()
        {
            throw new NotImplementedException();
        }

        public void HideDrawerMenu()
        {
            throw new NotImplementedException();
        }

        public void NavigateTo(string pageKey)
        {
            throw new NotImplementedException();
        }

        public void NavigateTo(string pageKey, object parameter)
        {
            throw new NotImplementedException();
        }

        public void PopToRoot()
        {
            throw new NotImplementedException();
        }
    }
}
