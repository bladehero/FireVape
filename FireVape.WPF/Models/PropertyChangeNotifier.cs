using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace FireVape.WPF.Models
{
    public abstract class PropertyChangeNotifier : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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
