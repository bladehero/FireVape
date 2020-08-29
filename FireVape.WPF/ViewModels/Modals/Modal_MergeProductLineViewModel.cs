using FireVape.Interfaces.Data.Content;
using FireVape.Interfaces.Data.Content.Products;
using FireVape.WPF.Models.ContentModel.Products;
using FireVape.WPF.ViewModels.BaseViewModels;

namespace FireVape.WPF.ViewModels
{
    public class Modal_MergeProductLineViewModel : MergeModal<IProductLine<IVolumeable>>
    {
        public Modal_MergeProductLineViewModel() => Element = new ProductLine();

        public void Add()
        {
            var option = new ProductOption();
            Element.Options.Add(option);
        }

        public void Delete(IProductOption<IVolumeable> option)
        {
            Element.Options.Remove(option);
        }
    }
}
