using System.ComponentModel;

namespace FireVape.Interfaces.Data.Content.Components
{
    [Description("Components")]
    public interface IComponent : ICostable, IEntity
    {
        string Name { get; set; }
        IFirm Firm { get; set; }
    }
}
