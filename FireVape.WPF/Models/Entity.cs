using FireVape.Interfaces.Data;
using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace FireVape.WPF.Models
{
    public abstract class Entity : IEntity
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Modified { get; set; } = DateTime.Now;

        public event PropertyChangedEventHandler PropertyChanged;

        public override int GetHashCode() => Guid.GetHashCode();

        public object Clone() => MemberwiseClone();

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> expression)
        {
            var memberExpression = (MemberExpression)expression.Body;
            var member = memberExpression.Member;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(member.Name));
        }
    }
}
