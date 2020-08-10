using System.ComponentModel;

namespace FireVape.Interfaces.Data.Content
{
    [Description("Firms")]
    public interface IFirm : IEntity
    {
        string Name { get; set; }
        string Country { get; set; }
    }
}
