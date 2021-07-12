using CommonServiceLocator;
using SampleApp.MVVMLight.Services.Interface;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SampleApp.MVVMLight.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected readonly INavigationService NavigationService;

        public BaseViewModel()
        {
            NavigationService = ServiceLocator.Current.GetInstance<INavigationService>();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
