using Foundation;
using SampleApp.MVVMLight.CustomControls;
using SampleApp.MVVMLight.iOS.CustomRendrers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExtendedTabbedPage), typeof(ExtendedTabbedPageRenderer))]
namespace SampleApp.MVVMLight.iOS.CustomRendrers
{
   public class ExtendedTabbedPageRenderer : TabbedRenderer
    {
    }
}