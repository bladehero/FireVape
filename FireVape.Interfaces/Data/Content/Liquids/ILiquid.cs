﻿using FireVape.Interfaces.Data.Content.Components;
using FireVape.Interfaces.Data.Content.Products;
using System.ComponentModel;

namespace FireVape.Interfaces.Data.Content.Liquids
{
    [Description("Liquids")]
    public interface ILiquid : IVolumeableComponentForSale, IEntity
    {
        IProductOption<IVolumeable> ProductOption { get; set; }
    }
}
