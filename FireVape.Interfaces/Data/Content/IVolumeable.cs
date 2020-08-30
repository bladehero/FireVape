using System.ComponentModel;

namespace FireVape.Interfaces.Data.Content
{
    public interface IVolumeable : INotifyPropertyChanged
    {
        int Volume { get; set; }
    }
}
