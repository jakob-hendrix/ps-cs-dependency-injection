using Autofac;
using Autofac.Configuration;
using Autofac.Features.ResolveAnything;
using Microsoft.Extensions.Configuration;
using System.Windows;

namespace PeopleViewer.Autofac.LateBinding
{
    public partial class App : Application
    {
        IContainer Container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            ComposeObjects();
            Application.Current.MainWindow.Title = "With Dependency Injection - Autofac Late Binding";
            Application.Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
            // create a config builder
            var config = new ConfigurationBuilder();
            config.AddJsonFile("autofac.json");

            // build the configuration
            var module = new ConfigurationModule(config.Build());

            // register ocnfig builder with the builder
            var builder = new ContainerBuilder();
            builder.RegisterModule(module);

            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());

            Container = builder.Build();
        }

        private void ComposeObjects()
        {
            Application.Current.MainWindow = Container.Resolve<PeopleViewerWindow>();
        }
    }
}
