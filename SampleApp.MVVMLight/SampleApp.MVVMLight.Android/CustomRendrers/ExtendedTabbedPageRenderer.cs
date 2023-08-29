using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms.Platform.Android.AppCompat;

namespace SampleApp.MVVMLight.Droid.CustomRendrers
{
    public class ExtendedTabbedPageRenderer : TabbedPageRenderer
    {
        public ExtendedTabbedPageRenderer(Context context) : base(context)
        {
        }
    }
}