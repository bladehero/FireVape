using FireVape.Interfaces.Data.Content;
using FireVape.WPF.Models.ContentModel;
using FireVape.WPF.ViewModels.BaseViewModels;

namespace FireVape.WPF.ViewModels
{
    public class Modal_MergeFirmViewModel : MergeModal<IFirm>
    {
        public Modal_MergeFirmViewModel() => Element = new Firm();
    }
}
