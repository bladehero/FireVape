using System;
using System.ComponentModel;

namespace FireVape.Interfaces.Data
{
    public interface IEntity : INotifyPropertyChanged, ICloneable
    {
        Guid Guid { get; set; }
        DateTime Created { get; set; }
        DateTime Modified { get; set; }
    }
}
