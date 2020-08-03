namespace FireVape.Interfaces.Data.Content.Products
{
    public interface IProductOption<T> : IEntity
    {
        IProductLine<T> ProductLine { get; set; }
        T Value { get; set; }
        decimal Price { get; }
    }
}
