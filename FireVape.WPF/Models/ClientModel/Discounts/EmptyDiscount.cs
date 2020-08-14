using FireVape.Interfaces.Data.Client;
using FireVape.Interfaces.Data.Content.Components;
using System.Collections.Generic;
using System.Linq;

namespace FireVape.WPF.Models.ClientModel.Discounts
{
    public class EmptyDiscount : IDiscount<IComponentForSale>
    {
        public decimal Apply(IEnumerable<IComponentForSale> products) => products.Sum(x => x.Price.GetValueOrDefault());
    }
}
