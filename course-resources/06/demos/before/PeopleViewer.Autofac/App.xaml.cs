using System.Windows;
using Autofac;
using Autofac.Features.ResolveAnything;
using PeopleViewer.Common;
using PeopleViewer.Presentation;
using PersonDataReader.CSV;
using PersonDataReader.Decorators;
using PersonDataReader.Service;

namespace PeopleViewer.Autofac
{
    public partial class App : Application
    {
        public IContainer Container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            ComposeObjects();
            Application.Current.MainWindow.Title = "With Dependency Injection - Autofac";
            Application.Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // maps concrete ServiceReader to the interface as a singleton
            //builder.RegisterType<ServiceReader>().As<IPersonReader>()
            //    .SingleInstance();

            builder.RegisterType<CSVReader>().Named<IPersonReader>("reader")
                .SingleInstance();

            builder.RegisterDecorator<IPersonReader>(
                (c, inner) => new CachingReader(inner), fromKey: "reader");


            // auto register. No recommened since it uses Reflection which is slow (apparently)
            // this is here for people used to other DI containers
            //builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());


            // Autofac prefers a more specific registration
            builder.RegisterType<PeopleViewerWindow>()
                .InstancePerDependency();  // new instance provide when requested

            builder.RegisterType<PeopleViewModel>()
                .InstancePerDependency();

            Container = builder.Build();

        }

        private void ComposeObjects()
        {
            // Figure out all of the details
            Application.Current.MainWindow = Container.Resolve<PeopleViewerWindow>();
        }
    }
}
