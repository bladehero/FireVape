using System.Collections.Generic;

namespace FireVape.Interfaces.Data.Content.Products
{
    public interface IProductLine<T>
    {
        string Name { get; set; }
        IList<IProductOption<T>> Options { get; set; }
    }
}
