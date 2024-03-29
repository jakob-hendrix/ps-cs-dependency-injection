﻿using PeopleViewer.Presentation;
using PersonDataReader.CSV;
using PersonDataReader.Service;
using System.Windows;

namespace PeopleViewer
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ComposeObjects();

            Application.Current.MainWindow.Title = "With Dependency Injection";
            Application.Current.MainWindow.Show();
        }

        // This is where we snap together our loosely coupled code
        private static void ComposeObjects()
        {
            //var reader = new ServiceReader();
            var reader = new CSVReader();
            var viewModel = new PeopleViewModel(reader);
            Application.Current.MainWindow = new PeopleViewerWindow(viewModel);
        }
    }
}
