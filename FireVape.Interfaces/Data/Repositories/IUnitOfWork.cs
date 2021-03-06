﻿using FireVape.Interfaces.Data.Client;
using FireVape.Interfaces.Data.Content;
using FireVape.Interfaces.Data.Content.Components;
using FireVape.Interfaces.Data.Content.Liquids;
using FireVape.Interfaces.Data.Content.Products;
using System;
using System.Collections.Generic;

namespace FireVape.Interfaces.Data.Repositories
{
    public interface IUnitOfWork : IAsyncDisposable, IAsyncSaveable
    {
        IRepository<IFirm> Firms { get; }
        IRepository<IComponent> Components { get; }
        IRepository<IComponentForSale> ComponentForSales { get; }
        IRepository<IProductLine<IVolumeable>> ProductLines { get; }
        IRepository<ILiquid> Liquids { get; }
        IRepository<ICustomLiquid> CustomLiquids { get; }
        IRepository<IClient> Clients { get; }
        IRepository<IOrder> Orders { get; }
        IRepository<IOrderStatus> OrderStatuses { get; }

        IEnumerable<IRepository<IEntity>> GetRepositories();
    }
}
