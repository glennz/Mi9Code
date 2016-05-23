namespace App
{
    using App.Controllers;
    using App.Services;

    using Autofac;
    using Autofac.Integration.WebApi;

    public static class IocConfig
    {
        public static IContainer BuildContainer()
        {
            var b = new ContainerBuilder();
            
            var thisAssembly = typeof(PayloadController).Assembly;
            b.RegisterApiControllers(thisAssembly);

            //service
            b.RegisterType<DataService>().As<IDataService>();

            return b.Build();
        }
    }
}