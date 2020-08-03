namespace FireVape.Interfaces.Data.Client
{
    public interface IClient : IEntity
    {
        string Name { get; set; }
        string Phone { get; set; }
    }
}
