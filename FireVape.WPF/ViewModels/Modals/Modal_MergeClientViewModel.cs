using FireVape.Interfaces.Data.Client;
using FireVape.WPF.Models.ClientModel;
using FireVape.WPF.ViewModels.BaseViewModels;

namespace FireVape.WPF.ViewModels
{
    public class Modal_MergeClientViewModel : MergeModal<IClient>
    {
        public Modal_MergeClientViewModel() => Element = new Client();
    }
}
