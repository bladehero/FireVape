using FireVape.Interfaces.Data.Client;
using FireVape.Interfaces.Data.Content.Components;
using System;
using System.Collections.Generic;

namespace FireVape.Data.ClientModel
{
    public class Order : IOrder
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateCompleted { get; set; }
        public string Comment { get; set; }
        public IClient Client { get; set; }
        public IList<IComponentForSale> Products { get; set; }
        public IDiscount<IComponentForSale> Discount { get; set; }
        public IDelivery Delivery { get; set; }
        public IOrderStatus Status { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
    }
}
