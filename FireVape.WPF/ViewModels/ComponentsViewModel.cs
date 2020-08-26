using Caliburn.Micro;
using FireVape.Interfaces;
using FireVape.Interfaces.Data.Content.Components;
using FireVape.Interfaces.Data.Repositories;
using FireVape.WPF.ViewModels.BaseViewModels;
using System.Threading.Tasks;
using FireVape.WPF.Helpers;

namespace FireVape.WPF.ViewModels
{
    public class ComponentsViewModel : CrudViewModel<IComponent,  Modal_MergeComponentViewModel>
    {
        public ComponentsViewModel(IUnitOfWork unitOfWork, 
                                   IResourceService resourceService,
                                   IWindowManager windowManager) : 
            base(unitOfWork, resourceService, windowManager)
        {
        }

        protected override IRepository<IComponent> Repository => UnitOfWork.Components;

        public override async Task<Modal_MergeComponentViewModel> GetModalAsync(IComponent element = null)
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
