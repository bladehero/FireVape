using System.ComponentModel;

namespace FireVape.Interfaces.Data.Client
{
    [Description("Clients")]
    public interface IClient : IEntity
    {
        string Name { get; set; }
        string Phone { get; set; }
        string FullName { get; }
    }
}
