using Caliburn.Micro;
using FireVape.Data;
using FireVape.Data.ClientModel;
using FireVape.Interfaces.Data.Client;
using FireVape.Interfaces.Data.Repositories;
using FireVape.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;

namespace FireVape.WPF
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer();

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            _container.Singleton<IWindowManager, WindowManager>();
            _container.Singleton<IEventAggregator, EventAggregator>();
            _container.PerRequest<IUnitOfWork, UnitOfWork>();
            _container.PerRequest<ShellViewModel, ShellViewModel>();
        }

        protected override object GetInstance(Type serviceType, string key)
        {
            return _container.GetInstance(serviceType, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return _container.GetAllInstances(serviceType);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            base.OnStartup(sender, e);
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
