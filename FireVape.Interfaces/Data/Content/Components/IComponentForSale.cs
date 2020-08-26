using System.ComponentModel;

namespace FireVape.Interfaces.Data.Content.Components
{
    [Description("ComponentForSales")]
    public interface IComponentForSale : IComponent, IPricableCostable
    {
    }
}
