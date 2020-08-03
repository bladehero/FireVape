using FireVape.Interfaces.Data.Content.Components;
using System.Collections.Generic;

namespace FireVape.Interfaces.Data.Content.Liquids
{
    public interface ICustomLiquid : ILiquid
    {
        IList<IComponent> Components { get; set; }
    }
}
