using Acr.UserDialogs;
using Rg.Plugins.Popup.Services;
using SampleApp.MVVMLight.CustomControls;
using SampleApp.MVVMLight.Helpers;
using SampleApp.MVVMLight.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Essentials;
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
            CategoryList.Add(new MenuModel { PageName = "tab View", Icon = "icon.png" });
            CategoryList.Add(new MenuModel { PageName = "tab View2", Icon = "icon.png" });
            CategoryList.Add(new MenuModel { PageName = "Notification View", Icon = "icon.png" });
            CategoryList.Add(new MenuModel { PageName = "Stepbar View", Icon = "icon.png" });
            CategoryList.Add(new MenuModel { PageName = "FormValidatiion", Icon = "icon.png" });
            CategoryList.Add(new MenuModel { PageName = "OTP", Icon = "icon.png" });
            CategoryList.Add(new MenuModel { PageName = "Feedback", Icon = "icon.png" });
            CategoryList.Add(new MenuModel { PageName = "Popup", Icon = "icon.png" });
            CategoryList.Add(new MenuModel { PageName = "CameraPreview", Icon = "icon.png" });
            CategoryList.Add(new MenuModel { PageName = "ProgressPath", Icon = "icon.png" });
            CategoryList.Add(new MenuModel { PageName = "VideoView", Icon = "icon.png" });
            CategoryList.Add(new MenuModel { PageName = "QRScannerView", Icon = "icon.png" });
            CategoryList.Add(new MenuModel { PageName = "QRScannerView2", Icon = "icon.png" });
            CategoryList.Add(new MenuModel { PageName = "VideoView2", Icon = "icon.png" });
            CategoryList.Add(new MenuModel { PageName = "PaytmPaymentDemo", Icon = "icon.png" });
            CategoryList.Add(new MenuModel { PageName = "ChatDemoUI", Icon = "icon.png" });
            CategoryList.Add(new MenuModel { PageName = "ConnectToWiFi", Icon = "icon.png" });
        }

        private async void MenuSelected(object obj)
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
                        case "Feedback":
                            await PopupNavigation.Instance.PushAsync(new CustomFeedbackPage());
                            break;
                        case "Popup":
                            NavigationService.NavigateTo(PageKeys.BottomSheetPageURI);
                            break;

                        case "CameraPreview":
                            NavigationService.NavigateTo(PageKeys.CameraPreviewPageURI);
                            break;

                        case "ProgressPath":
                            NavigationService.NavigateTo(PageKeys.ProgressPathViewPageURI);
                            break;

                        case "VideoView":
                            NavigationService.NavigateTo(PageKeys.VideoViewURI);
                            break;

                        case "QRScannerView":
                            //NavigationService.NavigateTo(PageKeys.QRScannerViewURI);
                            //DependencyService.Get<IOpenScannerPage>().OpenScanner();
                            var result = await DependencyService.Get<IOpenScannerPage>().ScanAsync();// OpenScanner();
                            break;

                        case "QRScannerView2":
                            {
                                var status = await Permissions.RequestAsync<Permissions.Camera>();

                                if (status != PermissionStatus.Granted)
                                {
                                    await UserDialogs.Instance.AlertAsync(
                                        "Camera permission is required for QR scanner.", "", "OK");
                                }
                                else
                                {
                                    NavigationService.NavigateTo(PageKeys.QRScannerViewURI);
                                }
                            }
                            break;

                        case "VideoView2":
                            NavigationService.NavigateTo(PageKeys.VideoView2URI);
                            break;

                        //case "PaytmPaymentDemo":
                        //    NavigationService.NavigateTo(PageKeys.PaytmPaymentViewURI);
                        //    break; 

                        //case "ChatDemoUI":
                        //    NavigationService.NavigateTo(PageKeys.PaytmPaymentViewURI);
                        //    break; 

                        case "ConnectToWiFi":
                            NavigationService.NavigateTo(PageKeys.ConnectToWiFiPageURI);
                            break;

                        case "tab View":
                            NavigationService.NavigateTo(PageKeys.CustomTabPageURI);
                            break;

                        case "tab View2":
                            NavigationService.NavigateTo(PageKeys.CustomTabPageTwoURI);
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
