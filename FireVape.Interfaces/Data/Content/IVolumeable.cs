using System.ComponentModel;

namespace FireVape.Interfaces.Data.Content
{
    public interface IVolumeable : IEntity
    {
        int Volume { get; set; }
        string Unit { get; set; }
    }
}
