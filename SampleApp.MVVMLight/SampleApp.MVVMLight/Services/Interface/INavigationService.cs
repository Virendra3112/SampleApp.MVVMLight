namespace SampleApp.MVVMLight.Services.Interface
{
    public interface INavigationService
    {
        string CurrentPageKey { get; }
        void GoBack();
        void NavigateTo(string pageKey);
        void NavigateTo(string pageKey, object parameter);
        void PopToRoot();
        void HideDrawerMenu();
    }
}
