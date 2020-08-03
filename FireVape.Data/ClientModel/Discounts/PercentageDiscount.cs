using FireVape.Interfaces.Data.Client;
using FireVape.Interfaces.Data.Content.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FireVape.Data.ClientModel.Discounts
{
    public class PercentageDiscount : IDiscount<IComponentForSale>
    {
        private decimal _value;

        public decimal Value
        {
            get { return _value; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("value", value, "The percentage discount can be in range of 0 to 100");
                }

                _value = value;
            }
        }

        public decimal Apply(IEnumerable<IComponentForSale> products)
        {
            var sum = products.Sum(x => x.Price);
            var discount = (100 - Value) / 100;
            return discount * sum;
        }
    }
}
