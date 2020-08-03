﻿using FireVape.Interfaces.Data.Content.Components;
using System;
using System.Collections.Generic;

namespace FireVape.Interfaces.Data.Client
{
    public interface IOrder : IPricableCostable
    {
        DateTime DateCreated { get; set; }
        DateTime DateCompleted { get; set; }
        string Comment { get; set; }
        IClient Client { get; set; }
        IList<IComponentForSale> Products { get; set; }
        IDiscount<IComponentForSale> Discount { set; }
        IDelivery Delivery { get; set; }
        IOrderStatus Status { get; set; }
    }
}