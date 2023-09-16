using GalaSoft.MvvmLight.Ioc;
using SampleApp.MVVMLight.ViewModels;

namespace SampleApp.MVVMLight.Helpers
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<DasboardViewModel>();
            SimpleIoc.Default.Register<NavigationDrawerPageViewModel>();
            SimpleIoc.Default.Register<NotificationViewModel>();
            SimpleIoc.Default.Register<CustomPopupViewModel>();
            SimpleIoc.Default.Register<CustomTabbedPageSampleViewModel>();
            SimpleIoc.Default.Register<CustomTabbedPageSampleTwoViewModel>();
            SimpleIoc.Default.Register<CustomTabbedPageSampleThreeViewModel>();
        }

        public DasboardViewModel DasboardViewModel
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<DasboardViewModel>())
                {
                    SimpleIoc.Default.Register<DasboardViewModel>();
                }
                return SimpleIoc.Default.GetInstance<DasboardViewModel>();
            }
        }

        public NotificationViewModel NotificationViewModel
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<NotificationViewModel>())
                {
                    SimpleIoc.Default.Register<NotificationViewModel>();
                }
                return SimpleIoc.Default.GetInstance<NotificationViewModel>();
            }
        }

        public NavigationDrawerPageViewModel NavigationDrawerPageViewModel
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<NavigationDrawerPageViewModel>())
                {
                    SimpleIoc.Default.Register<NavigationDrawerPageViewModel>();
                }
                return SimpleIoc.Default.GetInstance<NavigationDrawerPageViewModel>();
            }
        }

        public CustomPopupViewModel CustomPopupViewModel
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<CustomPopupViewModel>())
                {
                    SimpleIoc.Default.Register<CustomPopupViewModel>();
                }
                return SimpleIoc.Default.GetInstance<CustomPopupViewModel>();
            }
        }

        public ConnectToWiFiPageViewModel ConnectToWiFiPageViewModel
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<ConnectToWiFiPageViewModel>())
                {
                    SimpleIoc.Default.Register<ConnectToWiFiPageViewModel>();
                }
                return SimpleIoc.Default.GetInstance<ConnectToWiFiPageViewModel>();
            }
        }

        public CustomTabbedPageSampleViewModel CustomTabbedPageSampleViewModel
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<CustomTabbedPageSampleViewModel>())
                {
                    SimpleIoc.Default.Register<CustomTabbedPageSampleViewModel>();
                }
                return SimpleIoc.Default.GetInstance<CustomTabbedPageSampleViewModel>();
            }
        }

        public CustomTabbedPageSampleTwoViewModel CustomTabbedPageSampleTwoViewModel
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<CustomTabbedPageSampleTwoViewModel>())
                {
                    SimpleIoc.Default.Register<CustomTabbedPageSampleTwoViewModel>();
                }
                return SimpleIoc.Default.GetInstance<CustomTabbedPageSampleTwoViewModel>();
            }
        }

        public CustomTabbedPageSampleThreeViewModel CustomTabbedPageSampleThreeViewModel
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<CustomTabbedPageSampleThreeViewModel>())
                {
                    SimpleIoc.Default.Register<CustomTabbedPageSampleThreeViewModel>();
                }
                return SimpleIoc.Default.GetInstance<CustomTabbedPageSampleThreeViewModel>();
            }
        }
    }
}
