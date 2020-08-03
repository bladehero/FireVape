using FireVape.Interfaces.Content.Components;
using FireVape.Interfaces.Content.Products;

namespace FireVape.Interfaces.Data.Content.Liquids
{
    public interface ILiquid : IVolumeableComponentForSale
    {
        IProductOption<IVolumeable> Option { get; set; }
    }
}
