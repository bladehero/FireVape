using FireVape.Interfaces.Data;
using FireVape.Interfaces.Data.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace FireVape.Data
{
    public class Repository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private static readonly object _lock = new object();
        private ObservableCollection<T> _elements;
        private TextWriter _writer;

        public bool IsSaved { get; private set; }

        public const string FolderForRepositories = "Repositories";
        public const string Extension = "json";

        public string RepositoryName => 
            typeof(T).FullName;
        public string RepositoryPath => 
            Path.Combine(FolderForRepositories, $"{RepositoryName}.{Extension}");

        public Repository()
        {
            _writer = new StreamWriter(RepositoryPath, false);
        }

        private async Task Load()
        {
            if (_elements != null)
            {
                var content = await File.ReadAllTextAsync(RepositoryPath);
                var source = JsonConvert.DeserializeObject<IEnumerable<T>>(content);

                _elements = new ObservableCollection<T>(source);
                _elements.CollectionChanged += Elements_CollectionChanged;
                IsSaved = true;
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (!IsSaved)
            {
                await SaveAsync();
            }

            _elements = null;
            await _writer.DisposeAsync();
        }

        public async Task<T> GetAsync(Guid guid)
        {
            await Load();
            return _elements.FirstOrDefault(x => x.Guid == guid);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            await Load();
            return _elements.Where(predicate?.Compile());
        }

        public async Task<T> GetOneAsync(Expression<Func<T, bool>> predicate = null)
        {
            await Load();
            return _elements.FirstOrDefault(predicate?.Compile());
        }

        public async Task<int> GetCountAsync(Expression<Func<T, bool>> predicate = null)
        {
            await Load();
            return _elements.Count(predicate?.Compile());
        }

        public async Task InsertAsync(T entity)
        {
            await Load();

            lock (_lock)
            {
                _elements.Add(entity);
            }
        }

        public async Task UpdateAsync(T entity)
        {
            await Load();
            lock (_lock)
            {
                var index = _elements.IndexOf(entity);
                if (index < 0)
                {
                    var old = _elements.FirstOrDefault(x => x.Guid == entity.Guid);
                    index = _elements.IndexOf(old);
                }

                if (index >= 0)
                {
                    _elements[index] = entity;
                }
            }
        }

        public async Task DeleteAsync(Guid guid)
        {
            await Load();
            lock (_lock)
            {
                var element = _elements.FirstOrDefault(x => x.Guid == guid);
                _elements.Remove(element);
            }
        }

        public async Task SaveAsync()
        {
            var content = JsonConvert.SerializeObject(_elements);
            await _writer.WriteAsync(content);
            IsSaved = true;
        }

        public async IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            await Load();
            foreach (var item in _elements)
            {
                yield return item;
            }
        }

        private void Elements_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
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
        }

        private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            IsSaved = false;
        }
    }
}
