namespace FireVape.Interfaces.Data.Client
{
    public interface IDiscount
    {
        decimal GetSellingPrice(decimal discount);
    }
}
