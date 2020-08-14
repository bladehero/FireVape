using Caliburn.Micro;
using FireVape.Interfaces;
using FireVape.Interfaces.Data.Repositories;

namespace FireVape.WPF.ViewModels.BaseViewModels
{
    public class BaseUnitViewModel : Conductor<object>
    {
        protected IUnitOfWork UnitOfWork { get; private set; }
        protected IResourceService ResourceService { get; private set; }
        protected IWindowManager WindowManager { get; private set; }

        public BaseUnitViewModel(IUnitOfWork unitOfWork, IResourceService resourceService, IWindowManager windowManager)
        {
            UnitOfWork = unitOfWork;
            ResourceService = resourceService;
            WindowManager = windowManager;
        }
    }
}
