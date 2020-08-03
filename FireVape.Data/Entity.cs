using FireVape.Interfaces.Data;
using System;

namespace FireVape.Data
{
    public abstract class Entity : IEntity
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Modified { get; set; } = DateTime.Now;
    }
}
