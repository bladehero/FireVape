using FireVape.Interfaces.Data.Content;
using FireVape.Interfaces.Data.Content.Products;

namespace FireVape.Data.ContentModel.Products
{
    public class ProductOption : IProductOption<IVolumeable>
    {
        public IProductLine<IVolumeable> ProductLine { get; set; }
        public IVolumeable Value { get; set; }
        public decimal Price { get; }
    }
}
