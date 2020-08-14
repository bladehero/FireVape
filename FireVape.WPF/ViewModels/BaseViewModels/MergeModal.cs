using Caliburn.Micro;
using FireVape.Interfaces.Data;
using System;

namespace FireVape.WPF.ViewModels.BaseViewModels
{
    public abstract class MergeModal<T> : Conductor<object> where T : class, IEntity
    {
        private T _element;

        public virtual T Element
        {
            get { return _element; }
            set { _element = value.Clone() as T ?? throw new NullReferenceException($"Element of `{nameof(T)}` cannot be nullable!"); }
        }

        public virtual bool Result { get; protected set; }
        public virtual void Save() => TryClose(Result = true);
        public virtual void Cancel() => TryClose();
    }
}