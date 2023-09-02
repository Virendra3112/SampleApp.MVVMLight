using CommonServiceLocator;
using SampleApp.MVVMLight.CustomControls;
using SampleApp.MVVMLight.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.MVVMLight.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomTabbedPageSampleView : ExtendedTabbedPage
    {
        private CustomTabbedPageSampleViewModel CustomTabbedPageSampleViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CustomTabbedPageSampleViewModel>();
            }
        }
        public CustomTabbedPageSampleView()
        {
            InitializeComponent();
            BindingContext = CustomTabbedPageSampleViewModel;

            this.SelectedItem = this.Children[0];

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();

            if (CurrentPage.Title == "Home")
            {
                //ToDo:Update icon here

                //HomeTab.Icon = "app_logo.png";
            }
            else
            {
                //HomeTab.Icon = "app_logo_unselected.png";
            }
            this.Title = CurrentPage.Title;
        }
    }
}