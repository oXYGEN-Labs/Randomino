using Prism.Ioc;
using Randomizer;
using System.Windows;
using Prism.Modularity;
using Randomizer.Modules.SimpleRandom;
using Randomizer.Services.Interfaces;
using Randomizer.Services;
using Prism.Mvvm;
using System.Reflection;
using System;
using System.Globalization;

namespace Randomizer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            ConfigureViewModelLocator();

            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // containerRegistry.RegisterSingleton<IMessageService, MessageService>();
            containerRegistry.RegisterSingleton<IListService, ListService>();
            containerRegistry.RegisterSingleton<IRandomizeService, RandomizeService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<SimpleRandomModule>();
        }
        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
            {
                var viewName = viewType.FullName;
                var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
                var viewModelName = String.Format(CultureInfo.InvariantCulture, "{0}VM, {1}", viewName, viewAssemblyName);

                return Type.GetType(viewModelName);
            });
        }
    }
}
