using FireVape.Interfaces.Data.Client;

namespace FireVape.Data.ClientModel
{
    public class Delivery : Entity, IDelivery
    {
        public string Where { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
    }
}
