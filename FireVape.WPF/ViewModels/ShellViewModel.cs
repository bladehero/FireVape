using Caliburn.Micro;
using FireVape.Interfaces.Data.Repositories;
using System.Security.RightsManagement;

namespace FireVape.WPF.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private readonly IWindowManager _windowManager;
        private readonly IUnitOfWork _unitOfWork;

        public ShellViewModel(IWindowManager windowManager, IUnitOfWork unitOfWork)
        {
            _windowManager = windowManager;
            _unitOfWork = unitOfWork;
        }

        public async void SaveMenu()
        {
            await _unitOfWork.SaveAsync();
        }

        public async void ExitMenu()
        {
            if (!_unitOfWork.IsSaved)
            {
                var result = _windowManager.ShowDialog(new ExitModalViewModel());
                if (result.GetValueOrDefault())
                {
                    await _unitOfWork.DisposeAsync();
                }
            }
            TryClose();
        }

        public void FirmsMenu()
        {
            ActivateItem(new FirmsViewModel());
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
            ActivateItem(null);
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
