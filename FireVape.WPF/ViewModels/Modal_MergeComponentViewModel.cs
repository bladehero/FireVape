using FireVape.Interfaces.Data.Content.Components;
using FireVape.WPF.Models.ContentModel.Components;
using FireVape.WPF.ViewModels.BaseViewModels;

namespace FireVape.WPF.ViewModels
{
    public class Modal_MergeComponentViewModel : MergeModal<IComponent>
    {
        public Modal_MergeComponentViewModel() => Element = new Component();
    }
}
