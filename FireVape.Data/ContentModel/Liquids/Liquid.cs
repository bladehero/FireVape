using FireVape.Interfaces.Data.Content;
using FireVape.Interfaces.Data.Content.Liquids;
using FireVape.Interfaces.Data.Content.Products;

namespace FireVape.Data.ContentModel.Liquids
{
    public class Liquid : Entity, ILiquid
    {
        public IProductOption<IVolumeable> ProductOption { get; set; }
        public string Name { get; set; }
        public IFirm Firm { get; set; }
        public decimal Cost { get; set; }
        public int Volume { get; set; }
        public decimal Price { get; set; }
        public string Unit { get; set; }
    }
}
