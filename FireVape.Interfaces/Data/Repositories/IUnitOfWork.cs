using FireVape.Interfaces.Client;
using FireVape.Interfaces.Content;
using FireVape.Interfaces.Content.Components;
using FireVape.Interfaces.Content.Liquids;
using FireVape.Interfaces.Content.Products;

namespace FireVape.Interfaces.Data.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<IFirm> Firms { get; }
        IRepository<IComponent> Components { get; }
        IRepository<IComponentForSale> ComponentForSales { get; }
        IRepository<IVolumeableComponent> VolumeableComponents { get; }
        IRepository<IVolumeableComponentForSale> VolumeableComponentForSales { get; }
        IRepository<IProductLine<IVolumeable>> ProductLines { get; }
        IRepository<IProductOption<IVolumeable>> ProductOptions { get; }
        IRepository<ILiquid> Liquids { get; }
        IRepository<ICustomLiquid> CustomLiquids { get; }
        IRepository<IClient> Clients { get; }
        IRepository<IOrder> Orders { get; }
        IRepository<IOrderStatus> OrderStatuses { get; }
    }
}
