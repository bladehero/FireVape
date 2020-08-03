namespace FireVape.Interfaces.Data.Content.Products
{
    public interface IProductOption<T>
    {
        IProductLine<T> ProductLine { get; set; }
        T Value { get; set; }
        decimal Price { get; }
    }
}
