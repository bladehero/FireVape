using FireVape.Interfaces.Data.Client;
using FireVape.Interfaces.Data.Content.Components;
using System;
using System.Collections.Generic;

namespace FireVape.WPF.Models.ClientModel
{
    public class Order : Entity, IOrder
    {
        private DateTime dateCompleted;
        private string comment;
        private IClient client;
        private IList<IComponentForSale> products;
        private IDiscount<IComponentForSale> discount;
        private IDelivery delivery;
        private IOrderStatus status;
        private decimal price;
        private decimal cost;

        public DateTime DateCompleted
        {
            get => dateCompleted;
            set
            {
                dateCompleted = value;
                OnPropertyChanged(() => DateCompleted);
            }
        }
        public string Comment
        {
            get => comment;
            set
            {
                comment = value;
                OnPropertyChanged(() => DateCompleted);
            }
        }
        public IClient Client
        {
            get => client;
            set
            {
                client = value;
                OnPropertyChanged(() => Client);
            }
        }
        public IList<IComponentForSale> Products
        {
            get => products;
            set
            {
                products = value;
                OnPropertyChanged(() => Products);
            }
        }
        public IDiscount<IComponentForSale> Discount
        {
            get => discount;
            set
            {
                discount = value;
                OnPropertyChanged(() => Discount);
            }
        }
        public IDelivery Delivery
        {
            get => delivery;
            set
            {
                delivery = value;
                OnPropertyChanged(() => Delivery);
            }
        }
        public IOrderStatus Status
        {
            get => status;
            set
            {
                status = value;
                OnPropertyChanged(() => Status);
            }
        }
        public decimal Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged(() => Price);
            }
        }
        public decimal Cost
        {
            get => cost;
            set
            {
                cost = value;
                OnPropertyChanged(() => Cost);
            }
        }

        public decimal Income => Price - Cost;
    }
}
