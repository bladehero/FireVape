using System.ComponentModel;

namespace FireVape.Interfaces.Data.Client
{
    [Description("OrderStatuses")]
    public interface IOrderStatus : IEntity
    {
        string Status { get; set; }
    }
}
