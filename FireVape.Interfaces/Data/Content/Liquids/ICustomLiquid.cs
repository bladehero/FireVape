using System.Collections.Generic;
using System.ComponentModel;

namespace FireVape.Interfaces.Data.Content.Liquids
{
    public interface ICustomLiquid : ILiquid
    {
        IList<IComponent> Components { get; set; }
    }
}
