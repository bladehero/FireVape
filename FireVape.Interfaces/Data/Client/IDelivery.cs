namespace FireVape.Interfaces.Data.Client
{
    public interface IDelivery : IPricableCostable
    {
        string Where { get; set; }
    }
}
