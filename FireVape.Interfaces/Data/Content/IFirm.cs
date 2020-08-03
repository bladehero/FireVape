namespace FireVape.Interfaces.Data.Content
{
    public interface IFirm : IEntity
    {
        string Name { get; set; }
        string Country { get; set; }
    }
}
