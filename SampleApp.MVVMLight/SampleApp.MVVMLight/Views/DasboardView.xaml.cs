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

            //customLabel.Text = "<p>Hello<br/><b>Demo Test</b><br> <b>This is second</b><br/><font color='red'>This is some text!</font></p>";
            //customLabel.Text = "<p>test first line thbekgjrej</br></br><b>this is bold </b></ p>";

            //container.Children.Add(box);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}