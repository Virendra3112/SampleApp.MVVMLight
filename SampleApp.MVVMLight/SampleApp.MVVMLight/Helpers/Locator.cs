using Autofac;

namespace SampleApp.MVVMLight.Helpers
{
    public class Locator
    {
        public static Autofac.IContainer Container { get; set; }


        protected static void RegisterCommon(ContainerBuilder builder)
        {
            RegisterServices(builder);
        }


        private static void RegisterServices(ContainerBuilder containerBuilder)
        {
            // containerBuilder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();

        }
    }
}
