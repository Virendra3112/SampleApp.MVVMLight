using Autofac;
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
        private static void RegisterServices(ContainerBuilder containerBuilder)
        {
            var nav = new NavigationService();
            CreateNavigationService(nav);
            containerBuilder.Register<SampleApp.MVVMLight.Services.Interface.INavigationService>(c => nav).SingleInstance();
        }

        private static NavigationService CreateNavigationService(NavigationService navigationService)
        {
            navigationService.Configure(PageKeys.DrawerPageURI, typeof(NavigationDrawerPage));
            navigationService.Configure(PageKeys.DashboardPageURI, typeof(DasboardView));
            navigationService.Configure(PageKeys.NotificationViewURI, typeof(NotificationView));
            navigationService.Configure(PageKeys.StepbarSamplePageURI, typeof(StepbarSampleView));

            return navigationService;
        }

        private static void RegisterViewModel(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(BaseViewModel).Assembly).InstancePerLifetimeScope().AsImplementedInterfaces().AsSelf().AssignableTo<BaseViewModel>();
        }
    }
}
