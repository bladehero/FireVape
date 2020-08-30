using FireVape.Interfaces.Data;
using System;

namespace FireVape.WPF.Models
{
    public abstract class Entity : PropertyChangeNotifier, IEntity
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool CanEdit { get; set; } = true;
        public bool CanDelete { get; set; } = true;

        public override int GetHashCode() => Guid.GetHashCode();

        public object Clone() => MemberwiseClone();
    }
}
