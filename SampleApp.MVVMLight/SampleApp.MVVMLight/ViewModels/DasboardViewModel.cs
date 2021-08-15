using SampleApp.MVVMLight.Helpers;
using SampleApp.MVVMLight.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleApp.MVVMLight.ViewModels
{
    public class DasboardViewModel : BaseViewModel
    {

        private ObservableCollection<MenuModel> _categoryList;

        public ObservableCollection<MenuModel> CategoryList
        {
            get { return _categoryList; }
            set { _categoryList = value; OnPropertyChanged(); }
        }
        public ICommand MenuItemCommand { get; set; }
        public DasboardViewModel()
        {

            MenuItemCommand = new Command(MenuSelected);

            CategoryList = new ObservableCollection<MenuModel>();


            CategoryList.Add(new MenuModel { PageName = "Notification View", Icon = "icon.png" });
            CategoryList.Add(new MenuModel { PageName = "Stepbar View", Icon = "icon.png" });
            CategoryList.Add(new MenuModel { PageName = "FormValidatiion", Icon = "icon.png" });
            CategoryList.Add(new MenuModel { PageName = "OTP", Icon = "icon.png" });

        }

        private void MenuSelected(object obj)
        {
            try
            {
                if (obj != null)
                {
                    var model = obj as MenuModel;
                    switch (model.PageName)
                    {
                        case "Notification View":
                            NavigationService.NavigateTo(PageKeys.NotificationViewURI);
                            break;
                        case "Stepbar View":
                            NavigationService.NavigateTo(PageKeys.StepbarSamplePageURI);
                            break;
                        case "FormValidatiion":
                            NavigationService.NavigateTo(PageKeys.FormValidationPageURI);
                            break;
                        case "OTP":
                            NavigationService.NavigateTo(PageKeys.OTPPageURI);
                            break;
                    }
                }

            }
            catch (System.Exception ex)
            {

            }
        }
    }
}
