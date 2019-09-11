using System.Windows;
using Ninject;
using PeopleViewer.Common;
using PersonDataReader.CSV;
using PersonDataReader.Decorators;
using PersonDataReader.Service;

namespace PeopleViewer.Ninject
{
    public partial class App : Application
    {
        IKernel Container = new StandardKernel();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            ComposeObjects();
            Application.Current.MainWindow.Title = "With Dependency Injection - Ninject";
            Application.Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
            // if someone requests an IPersonReader, provide them a ServiceReader
            //Container.Bind<IPersonReader>().To<ServiceReader>();

            // A single intance is maintained
            //Container.Bind<IPersonReader>().To<CSVReader>().InSingletonScope();

            // Provide a fresh instance for each request - probably the default
            //Container.Bind<IPersonReader>().To<CSVReader>().InTransientScope();

            // One instance per thread
            //Container.Bind<IPersonReader>().To<CSVReader>().InThreadScope();

            // Requires a parameter. We can request the container to provide and manage
            // the reader implementation
            Container.Bind<IPersonReader>().To<CachingReader>()
                .InSingletonScope()
                .WithConstructorArgument<IPersonReader>(Container.Get<ServiceReader>());
        }

        private void ComposeObjects()
        {
            // no reference to the view model is needed. Ninject can see what is necessary
            // by reading through the constructors
            //
            // It looks like pieces are missing, so it's important to understand the DI chains
            Application.Current.MainWindow = Container.Get<PeopleViewerWindow>();
        }
    }
}
