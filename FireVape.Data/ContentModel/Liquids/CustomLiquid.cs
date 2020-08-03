using FireVape.Interfaces.Data.Content;
using FireVape.Interfaces.Data.Content.Liquids;
using FireVape.Interfaces.Data.Content.Products;
using System.Collections.Generic;
using System.ComponentModel;

namespace FireVape.Data.ContentModel.Liquids
{
    public class CustomLiquid : ICustomLiquid
    {
        public IList<IComponent> Components { get; set; }
        public IProductOption<IVolumeable> ProductOption { get; set; }
        public string Name { get; set; }
        public IFirm Firm { get; set; }
        public decimal Cost { get; set; }
        public int Volume { get; set; }
        public decimal Price { get; set; }
        public string Unit { get; set; }
    }
}
