using CommonServiceLocator;
using SampleApp.MVVMLight.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.MVVMLight.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomTabbedPageSampleView : ContentPage
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
        }
    }
}