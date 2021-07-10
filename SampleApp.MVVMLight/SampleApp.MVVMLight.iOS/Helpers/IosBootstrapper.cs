using Autofac;
using SampleApp.MVVMLight.Helpers;

namespace SampleApp.MVVMLight.iOS.Helpers
{
    public class IosBootstrapper : AppBootStrapper
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
            // Register platform helpers here.
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            // Register platform services here.
        }
    }
}