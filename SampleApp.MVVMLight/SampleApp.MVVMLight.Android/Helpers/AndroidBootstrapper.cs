using Android.App;
using Android.Gms.Auth.Api.Phone;
using Android.Gms.Tasks;
using Autofac;
using Java.Interop;
using SampleApp.MVVMLight.Helpers;
using System;

namespace SampleApp.MVVMLight.Droid.Helpers
{
    public class AndroidBootstrapper : AppBootStrapper
    {
        public static void Initialize()
        {
            var builder = new ContainerBuilder();
            AppBootStrapper.Init(builder);

            RegisterHelpers(builder);
            RegisterServices(builder);

            Container = builder.Build();
#pragma warning disable S1854 // Dead stores should be removed
            builder = null;
#pragma warning restore S1854 // Dead stores should be removed
        }

        private static void RegisterHelpers(ContainerBuilder builder)
        {
            //RegisterHelpers
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            //register services
        }
    }
}