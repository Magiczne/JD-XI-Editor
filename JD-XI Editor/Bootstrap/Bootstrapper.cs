using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using Caliburn.Micro;
using JD_XI_Editor.ViewModels;
using MahApps.Metro.Controls.Dialogs;
using SimpleInjector;

namespace JD_XI_Editor.Bootstrap
{
    public class Bootstrapper : BootstrapperBase
    {
        /// <summary>
        ///     IoC Container instance
        /// </summary>
        public static readonly Container ContainerInstance = new Container();

        /// <inheritdoc />
        public Bootstrapper()
        {
            Initialize();
        }

        /// <inheritdoc />
        protected override void Configure()
        {
            ContainerInstance.Register<MainWindowViewModel>();

            ContainerInstance.Register<IWindowManager, WindowManager>();
            ContainerInstance.RegisterSingleton<IEventAggregator, EventAggregator>();
            ContainerInstance.RegisterSingleton<IDialogCoordinator, DialogCoordinator>();
        }

        /// <inheritdoc />
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewForAsync<MainWindowViewModel>();
        }

        /// <inheritdoc />
        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            IServiceProvider provider = ContainerInstance;

            var collectionType = typeof(IEnumerable<>).MakeGenericType(service);
            var services = (IEnumerable<object>) provider.GetService(collectionType);

            return services ?? Enumerable.Empty<object>();
        }

        /// <inheritdoc />
        protected override object GetInstance(Type service, string key)
        {
            return ContainerInstance.GetInstance(service);
        }

        /// <inheritdoc />
        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            return new[]
            {
                Assembly.GetExecutingAssembly()
            };
        }

        /// <inheritdoc />
        protected override void BuildUp(object instance)
        {
            ContainerInstance
                .GetRegistration(instance.GetType(), true)
                .Registration
                .InitializeInstance(instance);
        }
    }
}