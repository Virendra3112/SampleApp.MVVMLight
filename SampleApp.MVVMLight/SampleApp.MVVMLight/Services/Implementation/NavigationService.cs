using SampleApp.MVVMLight.Services.Interface;
using System;

namespace SampleApp.MVVMLight.Services.Implementation
{
    public class NavigationService : INavigationService
    {
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
