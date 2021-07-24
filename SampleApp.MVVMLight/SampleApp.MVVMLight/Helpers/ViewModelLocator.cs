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
    }
}
