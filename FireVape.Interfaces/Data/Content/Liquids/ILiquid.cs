using FireVape.Interfaces.Data.Content.Components;
using FireVape.Interfaces.Data.Content.Products;

namespace FireVape.Interfaces.Data.Content.Liquids
{
    public interface ILiquid : IVolumeableComponentForSale
    {
        IProductOption<IVolumeable> ProductOption { get; set; }
    }
}
