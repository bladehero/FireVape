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

        public override async Task<Modal_MergeComponentViewModel> GetModalAsync()
        {
            var modal = await base.GetModalAsync();
            modal.Firms = await UnitOfWork.Firms.GetAllAsync().AsBindableAsync();
            return modal;
        }
    }
}
