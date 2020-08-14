using Caliburn.Micro;
using FireVape.Interfaces;
using FireVape.Interfaces.Data.Repositories;
using FireVape.WPF.ViewModels.BaseViewModels;

namespace FireVape.WPF.ViewModels
{
    public class ShellViewModel : BaseUnitViewModel
    {
        public ShellViewModel(IUnitOfWork unitOfWork,
                              IResourceService resourceService,
                              IWindowManager windowManager)
            : base(unitOfWork, resourceService, windowManager)
        {
        }

        public async void SaveMenu()
        {
            await UnitOfWork.SaveAsync();
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
            ActivateItem(new FirmsViewModel(UnitOfWork, ResourceService, WindowManager));
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
            ActivateItem(new ComponentsViewModel(UnitOfWork, ResourceService, WindowManager));
        }

        public void ComponentsForSaleMenu()
        {
            ActivateItem(null);
        }

        public void ClientsMenu()
        {
            ActivateItem(null);
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
