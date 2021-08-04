using Android.App;
using System;
using Xamarin.Forms;

namespace SampleApp.MVVMLight.Droid.Helpers
{
    public class BaseDependencyImplementation : Object
    {
        public Activity GetActivity()
        {
            var activity = (Activity)Forms.Context;
            return activity;
        }
    }
}