using FireVape.Interfaces.Data.Client;

namespace FireVape.Data.ClientModel
{
    public class OrderStatus : Entity, IOrderStatus
    {
        public string Status { get; set; }
    }
}
