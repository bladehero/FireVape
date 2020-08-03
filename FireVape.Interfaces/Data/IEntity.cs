using System;

namespace FireVape.Interfaces.Data
{
    public interface IEntity
    {
        Guid Guid { get; set; }
        DateTime Created { get; set; }
        DateTime Modified { get; set; }
    }
}
