using FireVape.Interfaces.Data.Content.Components;
using System.Collections.Generic;

namespace FireVape.Interfaces.Data.Client
{
    public interface IDiscount<in T> where T : IComponent, IPricable
    {
        decimal Apply(IEnumerable<T> products);
    }
}
