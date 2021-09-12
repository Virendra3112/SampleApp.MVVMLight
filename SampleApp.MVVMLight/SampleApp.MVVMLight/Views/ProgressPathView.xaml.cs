using CommonServiceLocator;
using SampleApp.MVVMLight.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.MVVMLight.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProgressPathView : ContentPage
    {
        private ProgressPathViewModel VM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ProgressPathViewModel>();
            }
        }
        public ProgressPathView()
        {
            InitializeComponent();
            BindingContext = VM;
        }
    }
}