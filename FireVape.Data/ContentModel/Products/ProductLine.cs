using FireVape.Interfaces.Data.Content;
using FireVape.Interfaces.Data.Content.Products;
using System.Collections.Generic;

namespace FireVape.Data.ContentModel.Products
{
    public class ProductLine : Entity, IProductLine<IVolumeable>
    {
        public string Name { get; set; }
        public IList<IProductOption<IVolumeable>> Options { get; set; }
    }
}
