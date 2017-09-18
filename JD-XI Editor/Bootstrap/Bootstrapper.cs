using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using Caliburn.Micro;
using JD_XI_Editor.ViewModels;
using JD_XI_Editor.ViewModels.Abstract;
using KnobControl;
using SimpleInjector;

namespace JD_XI_Editor.Bootstrap
{
    public class Bootstrapper : BootstrapperBase
    {
        /// <summary>
        /// IoC Container instance
        /// </summary>
        public static readonly Container ContainerInstance = new Container();

        /// <summary>
        /// Creates an instance of the bootstrapper
        /// </summary>
        public Bootstrapper()
        {
            Initialize();
        }

        /// <summary>
        /// Configure framework and setup IoC container
        /// </summary>
        protected override void Configure()
        {
            ContainerInstance.Register<IWindowManager, WindowManager>();
            //ContainerInstance.RegisterSingleton<IEventAggregator, EventAggregator>();
            //ContainerInstance.RegisterSingleton<IDialogCoordinator, DialogCoordinator>();

            ContainerInstance.RegisterCollection<TabViewModel>(new []
            {
                typeof(AnalogSynthTabViewModel)
            });

            ContainerInstance.Verify();

            ConventionManager.AddElementConvention<Knob>(Knob.ValueProperty, "Value", "ValueChanged");
        }

        /// <summary>
        /// Add custom behavior to execute after the application starts
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The args</param>
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainWindowViewModel>();
        }

        /// <summary>
        /// Get all instances of the service
        /// </summary>
        /// <param name="service">The service to locate</param>
        /// <returns>The located services</returns>
        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            IServiceProvider provider = ContainerInstance;
            var collectionType = typeof(IEnumerable<>).MakeGenericType(service);
            var services = (IEnumerable<object>) provider.GetService(collectionType);
            return services ?? Enumerable.Empty<object>();
        }

        /// <summary>
        /// Get instance of the service
        /// </summary>
        /// <param name="service">The service to locate</param>
        /// <param name="key">The key to locate</param>
        /// <returns>The located service</returns>
        protected override object GetInstance(Type service, string key)
        {
            return ContainerInstance.GetInstance(service);
        }

        /// <summary>
        /// Tell the framework where to find assemblies to inspect
        /// </summary>
        /// <returns>List of assemblies to inspect</returns>
        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            return new[]
            {
                Assembly.GetExecutingAssembly()
            };
        }

        /// <summary>
        /// Provide injection
        /// </summary>
        /// <param name="instance">Instance to perform injection on</param>
        protected override void BuildUp(object instance)
        {
            var registration = ContainerInstance.GetRegistration(instance.GetType(), true);
            registration.Registration.InitializeInstance(instance);
        }
    }
}