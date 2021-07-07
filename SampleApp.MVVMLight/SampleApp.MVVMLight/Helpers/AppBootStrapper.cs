using Autofac;
using GalaSoft.MvvmLight.Views;
using SampleApp.MVVMLight.Services.Implementation;
using SampleApp.MVVMLight.ViewModels;
using SampleApp.MVVMLight.Views;

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
            var navigationService = new NavigationService();
            CreateNavigationService(navigationService);
            builder.Register<INavigationService>(c => (INavigationService)navigationService).SingleInstance();
        }

        private static void CreateNavigationService(NavigationService navigationService)
        {
            navigationService.Configure(PageKeys.DashboardPageURI, typeof(DasboardView));
        }

        private static void RegisterViewModel(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(BaseViewModel).Assembly).InstancePerLifetimeScope().AsImplementedInterfaces().AsSelf().AssignableTo<BaseViewModel>();
        }

    }
}
