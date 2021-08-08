using CommonServiceLocator;
using SampleApp.MVVMLight.Helpers;
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
    public partial class FormValidationPage : ContentPage
    {
        private FormValidationPageModel FormValidationPageModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<FormValidationPageModel>();
            }
        }
        public FormValidationPage()
        {
            InitializeComponent();
            BindingContext = FormValidationPageModel;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

        }
    }
}