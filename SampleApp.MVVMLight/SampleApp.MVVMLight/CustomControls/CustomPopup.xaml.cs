using Rg.Plugins.Popup.Pages;
using System;
using Xamarin.Forms.Xaml;

namespace SampleApp.MVVMLight.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomPopup : PopupPage
    {
        public CustomPopup()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //todo
        }
    }
}