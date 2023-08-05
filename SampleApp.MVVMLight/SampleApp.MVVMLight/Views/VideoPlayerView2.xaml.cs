using MediaManager;
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
    public partial class VideoPlayerView2 : ContentPage
    {
        public VideoPlayerView2()
        {
            try
            {
                InitializeComponent();
            }
            catch(Exception ex)
            {

            }
        }

        string url = "http://clips.vorwaerts-gmbh.de/big_buck_bunny.mp4";
            //"https://scontent-mia3-2.cdninstagram.com/vp/7ee034d0e5eefab4c11acaddab638303/5BCDEF06/t50.2886-16/39004123_312845009463436_4371229804754632704_n.mp4";

        void BtnPlayVideo_Clicked(object sender, System.EventArgs e)
        {
            CrossMediaManager.Current.Play(url);//, MediaFileType.Video);
        }

        void BtnStopVideo_Clicked(object sender, System.EventArgs e)
        {
            CrossMediaManager.Current.Stop();
        }
    }
}