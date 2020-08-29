using System.Collections.Generic;
using System.ComponentModel;

namespace FireVape.Interfaces.Data.Content.Products
{
    [Description("ProductLines")]
    public interface IProductLine<T> : IEntity
    {
        string Name { get; set; }
        IList<IProductOption<T>> Options { get; set; }
        string StringOptions { get; }
    }
}
