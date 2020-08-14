using System.ComponentModel;

namespace FireVape.Interfaces.Data.Content.Products
{
    [Description("ProductOptions")]
    public interface IProductOption<T> : IEntity
    {
        IProductLine<T> ProductLine { get; set; }
        T Value { get; set; }
        decimal Price { get; set; }
    }
}
