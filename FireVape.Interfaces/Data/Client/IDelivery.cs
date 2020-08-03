namespace FireVape.Interfaces.Data.Client
{
    public interface IDelivery : IPricableCostable, IEntity
    {
        string Where { get; set; }
    }
}
