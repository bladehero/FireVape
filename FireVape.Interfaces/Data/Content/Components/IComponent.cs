namespace FireVape.Interfaces.Data.Content.Components
{
    public interface IComponent : ICostable, IEntity
    {
        string Name { get; set; }
        IFirm Firm { get; set; }
    }
}
