using Caliburn.Micro;
using FireVape.Interfaces;
using FireVape.Interfaces.Data;
using FireVape.Interfaces.Data.Repositories;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FireVape.WPF.ViewModels.BaseViewModels
{
    /// <summary>
    /// Base class of CRUD's ViewModel
    /// </summary>
    /// <typeparam name="T">Type of stored entity</typeparam>
    /// <typeparam name="M">Type of modal to create or update entity</typeparam>
    public abstract class CrudViewModel<T, M> : BaseUnitViewModel
        where T : class, IEntity
        where M : MergeModal<T>, new()
    {
        private BindableCollection<T> _elements;

        public CrudViewModel(IUnitOfWork unitOfWork,
                             IResourceService resourceService,
                             IWindowManager windowManager) :
            base(unitOfWork, resourceService, windowManager)
        {

            Selected = new List<T>();
            Task.Run(async () =>
            {
                var elements = await Repository.GetAllAsync();
                Elements = new BindableCollection<T>(elements);
                Elements.CollectionChanged += Elements_CollectionChanged;
                foreach (var element in Elements)
                {
                    element.PropertyChanged += Item_PropertyChanged;
                }
            });
        }

        public BindableCollection<T> Elements
        {
            get => _elements;
            set
            {
                _elements = value;
                NotifyOfPropertyChange(() => Elements);
            }
        }

        #region Getters
        public virtual async Task<M> GetModalAsync()
        {
            return new M()
            {
                UnitOfWork = UnitOfWork,
                ResourceService = ResourceService,
                WindowManager = WindowManager
            };
        }
        public virtual async Task<M> GetModalAsync(T element)
        {
            var modal = await GetModalAsync();
            modal.Element = element;
            return modal;
        }
        protected abstract IRepository<T> Repository { get; }
        public List<T> Selected { get; }
        public virtual string ElementsNaming => ResourceService.ElementsNaming;
        #endregion

        #region Enablings
        public bool CanDelete => Selected?.Count > 0;
        public bool CanUpdate => Selected?.Count > 0;
        public bool CanSave => !Repository.IsSaved;
        #endregion

        #region Actions
        public virtual void Delete()
        {
            var modal = new Modal_ConfirmationViewModel(ResourceService.DeleteConfirmation(ElementsNaming));
            WindowManager.ShowDialog(modal);
            if (modal.Result.GetValueOrDefault())
            {
                Elements.RemoveRange(Selected);
            }
        }
        public virtual async void Update()
        {
            var element = Selected.FirstOrDefault();

            var modal = await GetModalAsync(element);
            WindowManager.ShowDialog(modal);

            if (modal.Result)
            {
                var index = Elements.IndexOf(element);
                Elements[index] = modal.Element;
            }
        }
        public virtual async void Create()
        {
            var modal = await GetModalAsync();
            WindowManager.ShowDialog(modal);
            if (modal.Result)
            {
                Elements.Add(modal.Element);
            }
        }
        public async virtual void Save()
        {
            await UnitOfWork.SaveAsync();
            NotifyOfPropertyChange(() => CanSave);
        }
        #endregion

        #region EventHandlers
        public void SelectedChangeEvent(SelectionChangedEventArgs e)
        {
            foreach (T item in e.AddedItems)
            {
                Selected.Add(item);
            }

            foreach (T item in e.RemovedItems)
            {
                Selected.Remove(item);
            }

            NotifyOfPropertyChange(() => CanDelete);
            NotifyOfPropertyChange(() => CanUpdate);
        }
        private async void Elements_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var tasks = (IList<Task>)null;
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    tasks = new List<Task>(e.NewItems.Count);
                    foreach (T item in e.NewItems)
                    {
                        var task = Repository.InsertAsync(item);
                        tasks.Add(task);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    tasks = new List<Task>(e.OldItems.Count);
                    foreach (T item in e.OldItems)
                    {
                        var task = Repository.DeleteAsync(item.Guid);
                        tasks.Add(task);
                    }
                    break;
            }

            if (e.OldItems != null)
            {
                foreach (INotifyPropertyChanged item in e.OldItems)
                    item.PropertyChanged -= Item_PropertyChanged;
            }
            if (e.NewItems != null)
            {
                foreach (INotifyPropertyChanged item in e.NewItems)
                    item.PropertyChanged += Item_PropertyChanged;
            }

            if (tasks?.Count > 0)
            {
                await Task.WhenAll(tasks);
            }
            NotifyOfPropertyChange(() => CanSave);
        }
        private async void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender is T element)
            {
                await Repository.UpdateAsync(element);
            }
            NotifyOfPropertyChange(() => CanSave);
        }
        #endregion
    }
}
