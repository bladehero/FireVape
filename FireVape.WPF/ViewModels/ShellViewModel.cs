using Caliburn.Micro;
using FireVape.Interfaces;
using FireVape.Interfaces.Data.Repositories;
using FireVape.WPF.ViewModels.BaseViewModels;
using FireVape.WPF.Views;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FireVape.WPF.ViewModels
{
    public class ShellViewModel : BaseUnitViewModel
    {
        public ShellViewModel(IUnitOfWork unitOfWork,
                              IResourceService resourceService,
                              IWindowManager windowManager)
            : base(unitOfWork, resourceService, windowManager)
        {
            _viewModels = new List<BaseUnitViewModel>
            {
                new FirmsViewModel(UnitOfWork, ResourceService, WindowManager),
                new ComponentsViewModel(UnitOfWork, ResourceService, WindowManager),
                new ClientsViewModel(UnitOfWork, ResourceService, WindowManager),
            };
        }

        private List<BaseUnitViewModel> _viewModels;

        public BaseUnitViewModel GetViewModel<T>() where T : BaseUnitViewModel, IAsyncSaveable
            => _viewModels.FirstOrDefault(x => x is T);

        public async void SaveMenu()
        {
            await UnitOfWork.SaveAsync();
            var tasks = new List<Task>(_viewModels.Count);
            foreach (var viewModel in _viewModels)
            {
                if (viewModel is IAsyncSaveable saveable)
                {
                    tasks.Add(saveable.SaveAsync());
                }
            }
            await Task.WhenAll(tasks);
        }

        public async void ExitMenu()
        {
            Modal_ConfirmationViewModel modal;
            if (!UnitOfWork.IsSaved)
            {
                modal = new Modal_ConfirmationViewModel(ResourceService.SaveBeforeExitMessage) { NoIsVisible = true };
                WindowManager.ShowDialog(modal);
                if (!modal.Result.HasValue)
                {
                    return;
                }
                else if (modal.Result.Value)
                {
                    await UnitOfWork.DisposeAsync();
                }
            }

            modal = new Modal_ConfirmationViewModel(ResourceService.ExitMessage);
            WindowManager.ShowDialog(modal);
            if (modal.Result.GetValueOrDefault())
            {
                TryClose();
            }
        }

        public void FirmsMenu()
        {
            var vm = GetViewModel<FirmsViewModel>();
            ActivateItem(vm);
        }

        public void ProductLinesMenu()
        {
            ActivateItem(null);
        }

        public void LiquidsMenu()
        {
            ActivateItem(null);
        }

        public void CustomLiquidsMenu()
        {
            ActivateItem(null);
        }

        public void ComponentsMenu()
        {
            var vm = GetViewModel<ComponentsViewModel>();
            ActivateItem(vm);
        }

        public void ComponentsForSaleMenu()
        {
            ActivateItem(null);
        }

        public void ClientsMenu()
        {
            var vm = GetViewModel<ClientsViewModel>();
            ActivateItem(vm);
        }

        public void OrdersMenu()
        {
            ActivateItem(null);
        }

        public void NewOrderMenu()
        {
            ActivateItem(null);
        }

        public void OrderStatusesMenu()
        {
            ActivateItem(null);
        }

        public void SettingsMenu()
        {
            ActivateItem(null);
        }
    }
}
