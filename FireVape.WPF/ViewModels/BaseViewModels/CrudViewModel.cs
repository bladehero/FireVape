using Caliburn.Micro;
using FireVape.Interfaces;
using FireVape.Interfaces.Data;
using FireVape.Interfaces.Data.Repositories;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
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
        protected abstract IRepository<T> Repository { get; }

        public CrudViewModel(IUnitOfWork unitOfWork,
                             IResourceService resourceService,
                             IWindowManager windowManager) : 
            base(unitOfWork, resourceService, windowManager)
        {

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


        private BindableCollection<T> _elements;

        public BindableCollection<T> Elements
        {
            get => _elements;
            set
            {
                _elements = value;
                NotifyOfPropertyChange(() => Elements);
            }
        }

        public List<T> Selected { get; private set; } = new List<T>();

        public bool CanDelete => Selected?.Count > 0;
        public bool CanUpdate => Selected?.Count > 0;
        public bool CanSave => !Repository.IsSaved;

        public virtual string ElementsNaming => ResourceService.ElementsNaming;

        public void Delete()
        {
            var modal = new Modal_ConfirmationViewModel(ResourceService.DeleteConfirmation(ElementsNaming));
            WindowManager.ShowDialog(modal);
            if (modal.Result.GetValueOrDefault())
            {
                Elements.RemoveRange(Selected);
            }
        }
        public void Update()
        {
            var element = Selected.FirstOrDefault();

            var modal = new M()
            {
                Element = element
            };
            WindowManager.ShowDialog(modal);

            if (modal.Result)
            {
                var index = Elements.IndexOf(element);
                Elements[index] = modal.Element;
            }
        }
        public void Create()
        {
            var modal = new M();
            WindowManager.ShowDialog(modal);
            if (modal.Result)
            {
                Elements.Add(modal.Element);
            }
        }
        public async void Save()
        {
            await UnitOfWork.SaveAsync();
            NotifyOfPropertyChange(() => CanSave);
        }

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
    }
}
