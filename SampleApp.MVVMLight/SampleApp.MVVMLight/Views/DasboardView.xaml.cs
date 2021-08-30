using CommonServiceLocator;
using SampleApp.MVVMLight.CustomControls;
using SampleApp.MVVMLight.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.MVVMLight.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DasboardView : ContentPage
    {
        private DasboardViewModel DashboardViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DasboardViewModel>();
            }
        }
        public DasboardView()
        {
            InitializeComponent();
            BindingContext = DashboardViewModel;

            Label label = new Label() { Text = "Welcome,", BackgroundColor = Color.Green, WidthRequest = 100, HeightRequest = 150 };
            FloatingContentView box = new FloatingContentView();
            box.Content = label;

            //container.Children.Add(box);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}