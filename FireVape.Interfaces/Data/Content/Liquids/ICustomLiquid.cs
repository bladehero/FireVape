using System.Collections.Generic;
using System.ComponentModel;

namespace FireVape.Interfaces.Data.Content.Liquids
{
    [Description("CustomLiquids")]
    public interface ICustomLiquid : ILiquid
    {
        IList<Components.IComponent> Components { get; set; }
    }
}
