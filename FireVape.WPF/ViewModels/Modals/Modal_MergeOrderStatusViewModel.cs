using FireVape.Interfaces.Data.Client;
using FireVape.WPF.Models.ClientModel;
using FireVape.WPF.ViewModels.BaseViewModels;

namespace FireVape.WPF.ViewModels
{
    public class Modal_MergeOrderStatusViewModel : MergeModal<IOrderStatus>
    {
        public Modal_MergeOrderStatusViewModel() => Element = new OrderStatus();
    }
}
