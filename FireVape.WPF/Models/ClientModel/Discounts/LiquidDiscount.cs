using FireVape.Interfaces.Data.Client;
using FireVape.Interfaces.Data.Content.Liquids;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FireVape.WPF.Models.ClientModel.Discounts
{
    public class LiquidDiscount : IDiscount<ILiquid>
    {
        private int _minimumCount;
        public int MinimumCountToTrigger
        {
            get { return _minimumCount; }
            set
            {
                if (value == byte.MinValue)
                {
                    throw new ArgumentOutOfRangeException("value", value, "The count of pattern in item's discount should be greater than 0");
                }
                _minimumCount = value;
            }
        }

        public bool IsSingleProductLine { get; set; }

        public decimal Apply(IEnumerable<ILiquid> liquids)
        {
            var freeLiquids = new List<ILiquid>();
            if (IsSingleProductLine)
            {
                var groups = liquids.OrderBy(x => x.Price)
                                     .GroupBy(x => x.ProductOption.ProductLine.Name);
                foreach (var group in groups)
                {
                    var pattern = group.Count() / MinimumCountToTrigger;
                    freeLiquids.AddRange(group.Take(pattern));
                }
            }
            else
            {
                var pattern = liquids.Count() / MinimumCountToTrigger;
                var lowerPrice = liquids.OrderBy(x => x.Price).Take(pattern);
                freeLiquids.AddRange(lowerPrice);
            }

            freeLiquids.ForEach(x => { x.Price = 0; });

            return liquids.Sum(x => x.Price.GetValueOrDefault());
        }
    }
}
