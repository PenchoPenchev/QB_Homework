using Autofac;
using Backend.Data;
using Backend.Interfaces;
using Backend.Solutions;

namespace Backend.Config
{
    public static class DiConfiguratator
    {
        public static ILifetimeScope GetLifetimeScope()
        {
            var container = BuildContainer();

            return container.BeginLifetimeScope();
        }

        private static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<AppDbContext>().As<IAppContext>();
            builder.RegisterType<PopulationSolutions>().As<ICalculatePopulation>();
            builder.RegisterType<MergeSolutions>().As<ICollectionsMerger>();

            return builder.Build();
        }
    }
}
