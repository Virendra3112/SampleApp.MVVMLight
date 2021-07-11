using SampleApp.MVVMLight.Services.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace SampleApp.MVVMLight.Services.Implementation
{
    public class NavigationService : INavigationService
    {
        private readonly Dictionary<string, Type> _pageKeyDictionary;

        public NavigationService()
        {
            _pageKeyDictionary = new Dictionary<string, Type>();
        }

        public MasterDetailPage MasterDetailPage
        {
            get { return (MasterDetailPage)Application.Current.MainPage; }
        }

        public void Configure(string pageKey, Type pageType)
        {
            lock (_pageKeyDictionary)
            {
                if (_pageKeyDictionary.ContainsKey(pageKey))
                {
                    _pageKeyDictionary[pageKey] = pageType;
                }
                else
                {
                    _pageKeyDictionary.Add(pageKey, pageType);
                }
            }
        }

        #region INavigationService implementation
#pragma warning disable S3168 // "async" methods should not return "void"
        public async void GoBack()
#pragma warning disable S3168 // "async" methods should not return "void"
        {
            await MasterDetailPage.Detail.Navigation.PopAsync();
        }

        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, null);
        }

#pragma warning disable S3168 // "async" methods should not return "void"
        public async void NavigateTo(string pageKey, object parameter)
#pragma warning disable S3168 // "async" methods should not return "void"
        {
            try
            {
                object[] parameters = null;
                if (parameter != null)
                {
                    parameters = new[] { parameter };
                }
                if (_pageKeyDictionary != null)
                {
                    var displayPage = (Page)Activator.CreateInstance(_pageKeyDictionary[pageKey], parameters);
                    var isModal = displayPage is IModalPage;
                    NavigationPage.SetHasBackButton(displayPage, isModal);
                    CurrentPageKey = pageKey;
                    await MasterDetailPage.Detail.Navigation.PushAsync(displayPage);
                    MasterDetailPage.IsPresented = false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                Debugger.Break();
            }
        }

#pragma warning disable S3168 // "async" methods should not return "void"
        public async void PopToRoot()
#pragma warning disable S3168 // "async" methods should not return "void"
        {
            await MasterDetailPage.Detail.Navigation.PopToRootAsync();
            MasterDetailPage.IsPresented = false;
        }

        public void HideDrawerMenu()
        {
            MasterDetailPage.IsPresented = false;
        }

        public string CurrentPageKey { get; set; }

        #endregion
    }
}