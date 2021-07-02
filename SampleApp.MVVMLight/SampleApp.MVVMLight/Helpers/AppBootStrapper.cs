using Autofac;
using SampleApp.MVVMLight.ViewModels;

namespace SampleApp.MVVMLight.Helpers
{
    public class AppBootStrapper : Locator
    {
        protected static void Init(ContainerBuilder builder)
        {
            Locator.RegisterCommon(builder);
            RegisterServices(builder);
            RegisterViewModel(builder);
        }

        /// <summary>
        /// Registers the services.
        /// </summary>
        private static void RegisterServices(ContainerBuilder builder)
        {

        }

        private static void RegisterViewModel(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(BaseViewModel).Assembly).InstancePerLifetimeScope().AsImplementedInterfaces().AsSelf().AssignableTo<BaseViewModel>();
        }

    }
}
