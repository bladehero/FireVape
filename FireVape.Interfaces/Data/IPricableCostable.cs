namespace FireVape.Interfaces.Data
{
    public interface IPricableCostable : IPricable, ICostable
    {
        decimal Income { get; }
    }
}
