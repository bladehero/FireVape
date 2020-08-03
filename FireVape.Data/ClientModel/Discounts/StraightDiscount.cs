using FireVape.Interfaces.Data.Client;
using FireVape.Interfaces.Data.Content.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FireVape.Data.ClientModel.Discounts
{
    public class StraightDiscount : IDiscount<IComponentForSale>
    {
        private decimal _value;

        public decimal Value
        {
            get { return _value; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", value, "The straight discount should be greater than 0");
                }
                _value = value;
            }
        }

        public decimal Apply(IEnumerable<IComponentForSale> products)
        {
            var sum = products.Sum(x => x.Price);
            return sum > Value ? sum - Value : byte.MinValue;
        }
    }
}
