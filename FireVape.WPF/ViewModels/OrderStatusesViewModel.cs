using Caliburn.Micro;
using FireVape.Interfaces;
using FireVape.Interfaces.Data.Client;
using FireVape.Interfaces.Data.Repositories;
using FireVape.WPF.ViewModels.BaseViewModels;

namespace FireVape.WPF.ViewModels
{
    public class OrderStatusesViewModel : CrudViewModel<IOrderStatus, Modal_MergeOrderStatusViewModel>
    {
        public OrderStatusesViewModel(IUnitOfWork unitOfWork,
                              IResourceService resourceService,
                              IWindowManager windowManager) :
            base(unitOfWork, resourceService, windowManager)
        {
        }

        protected override IRepository<IOrderStatus> Repository => UnitOfWork.OrderStatuses;
    }
}
