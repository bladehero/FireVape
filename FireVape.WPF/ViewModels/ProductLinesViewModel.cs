using Caliburn.Micro;
using FireVape.Interfaces;
using FireVape.Interfaces.Data.Content;
using FireVape.Interfaces.Data.Content.Products;
using FireVape.Interfaces.Data.Repositories;
using FireVape.WPF.ViewModels.BaseViewModels;

namespace FireVape.WPF.ViewModels
{
    public class ProductLinesViewModel : CrudViewModel<IProductLine<IVolumeable>, Modal_MergeProductLineViewModel>
    {
        public ProductLinesViewModel(IUnitOfWork unitOfWork,
                                      IResourceService resourceService,
                                      IWindowManager windowManager) :
            base(unitOfWork, resourceService, windowManager)
        {
        }

        protected override IRepository<IProductLine<IVolumeable>> Repository => UnitOfWork.ProductLines;
    }
}
