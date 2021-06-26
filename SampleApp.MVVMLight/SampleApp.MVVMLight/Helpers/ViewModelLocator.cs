using GalaSoft.MvvmLight.Ioc;
using SampleApp.MVVMLight.ViewModels;

namespace SampleApp.MVVMLight.Helpers
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<DasboardViewModel>();
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
    }
}
