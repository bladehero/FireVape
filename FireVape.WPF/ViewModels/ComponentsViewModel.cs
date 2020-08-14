using Caliburn.Micro;
using FireVape.Interfaces;
using FireVape.Interfaces.Data.Content.Components;
using FireVape.Interfaces.Data.Repositories;
using FireVape.WPF.ViewModels.BaseViewModels;

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
    }
}
