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
    public partial class CustomTabbedPageSampleTwoView : ContentPage
    {
        public CustomTabbedPageSampleTwoView()
        {
            InitializeComponent();
        }

        private void OnFabTabTapped(object sender, Xamarin.CommunityToolkit.UI.Views.TabTappedEventArgs e)
        {

        }
    }
}