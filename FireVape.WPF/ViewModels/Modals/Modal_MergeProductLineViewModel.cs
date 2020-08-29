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
            Element.Options.Add(new ProductOption());
        }

        public override void TryClose(bool? dialogResult = null)
        {
            // Reset values to override exception of non-updated values;
            Element.Options = Element.Options;
            base.TryClose(dialogResult);
        }
    }
}
