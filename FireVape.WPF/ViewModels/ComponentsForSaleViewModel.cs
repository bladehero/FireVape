using Caliburn.Micro;
using FireVape.Interfaces;
using FireVape.Interfaces.Data.Content.Components;
using FireVape.Interfaces.Data.Repositories;
using FireVape.WPF.Helpers;
using FireVape.WPF.ViewModels.BaseViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace FireVape.WPF.ViewModels
{
    public class ComponentsForSaleViewModel : CrudViewModel<IComponentForSale, Modal_MergeComponentForSaleViewModel>
    {
        public ComponentsForSaleViewModel(IUnitOfWork unitOfWork,
                                          IResourceService resourceService,
                                          IWindowManager windowManager) :
            base(unitOfWork, resourceService, windowManager)
        {
        }

        protected override IRepository<IComponentForSale> Repository => UnitOfWork.ComponentForSales;

        public override async Task<Modal_MergeComponentForSaleViewModel> GetModalAsync(IComponentForSale element = null)
        {
            var firms = await UnitOfWork.Firms.GetAllAsync().AsBindableAsync();
            var firm = await UnitOfWork.Firms.GetAsync(element.Firm.Guid);
            element.Firm = firm;
            var modal = await base.GetModalAsync(element);
            modal.Firms = firms;
            return modal;
        }
    }
}
