using Caliburn.Micro;
using FireVape.Interfaces;
using FireVape.Interfaces.Data.Client;
using FireVape.Interfaces.Data.Repositories;
using FireVape.WPF.ViewModels.BaseViewModels;

namespace FireVape.WPF.ViewModels
{
    public class ClientsViewModel : CrudViewModel<IClient, Modal_MergeClientViewModel>
    {
        public ClientsViewModel(IUnitOfWork unitOfWork,
                                IResourceService resourceService,
                                IWindowManager windowManager) :
            base(unitOfWork, resourceService, windowManager)
        {
        }

        protected override IRepository<IClient> Repository => UnitOfWork.Clients;
    }
}
