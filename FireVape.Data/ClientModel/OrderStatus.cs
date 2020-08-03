using FireVape.Interfaces.Data.Client;

namespace FireVape.Data.ClientModel
{
    public class OrderStatus : IOrderStatus
    {
        public string Status { get; set; }
    }
}
