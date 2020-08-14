using Caliburn.Micro;
using FireVape.Interfaces;
using FireVape.Interfaces.Data.Content;
using FireVape.Interfaces.Data.Repositories;
using FireVape.WPF.ViewModels.BaseViewModels;

namespace FireVape.WPF.ViewModels
{
    public class FirmsViewModel : CrudViewModel<IFirm, Modal_MergeFirmViewModel>
    {
        public FirmsViewModel(IUnitOfWork unitOfWork,
                              IResourceService resourceService,
                              IWindowManager windowManager) : 
            base(unitOfWork, resourceService, windowManager)
        {
        }

        protected override IRepository<IFirm> Repository => UnitOfWork.Firms;
    }
}
