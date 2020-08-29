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

namespace FireVape.Services.Data
{
    internal class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private static readonly object _lock = new object();
        private static readonly JsonSerializerSettings _serializationSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All,
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Formatting.Indented
        };
        private ObservableCollection<T> _elements;

        public static readonly T[] EmptyArray = new T[0];

        public bool IsSaved { get; private set; } = true;

        public const string Extension = "json";

        public string RepositoryName =>
            (typeof(T).GetCustomAttributes(false)
                      .FirstOrDefault(x => x is DescriptionAttribute) as DescriptionAttribute)?
                      .Description ?? typeof(T).FullName;
        public string RepositoryPath =>
            Path.Combine(UnitOfWork.FolderForRepositories, $"{RepositoryName}.{Extension}");

        private async Task Load()
        {
            if (_elements == null)
            {
                IEnumerable<T> source = null;
                if (File.Exists(RepositoryPath))
                {
                    var content = await File.ReadAllTextAsync(RepositoryPath);
                    source = JsonConvert.DeserializeObject<IEnumerable<T>>(content, _serializationSettings);
                }

                _elements = new ObservableCollection<T>(source ?? EmptyArray);
                _elements.CollectionChanged += Elements_CollectionChanged;
                IsSaved = true;
            }
        }

        public async Task<T> GetAsync(Guid guid)
        {
            await Load();
            return _elements.FirstOrDefault(x => x.Guid == guid);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            await Load();

            IEnumerable<T> result;
            if (predicate == null)
            {
                result = _elements.AsEnumerable();
            }
            else
            {
                result = _elements.Where(predicate.Compile());
            }
            return result;
        }

        public async Task<T> GetOneAsync(Expression<Func<T, bool>> predicate = null)
        {
            await Load();

            T result;
            if (predicate == null)
            {
                result = _elements.FirstOrDefault();
            }
            else
            {
                result = _elements.FirstOrDefault(predicate?.Compile());
            }
            return result;
        }

        public async Task<int> GetCountAsync(Expression<Func<T, bool>> predicate = null)
        {
            await Load();

            int result;
            if (predicate == null)
            {
                result = _elements.Count();
            }
            else
            {
                result = _elements.Count(predicate?.Compile());
            }
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
            if (!IsSaved)
            {
                var content = JsonConvert.SerializeObject(_elements, _serializationSettings);

                using var writer = new StreamWriter(RepositoryPath, false);
                await writer.WriteAsync(content);

                IsSaved = true;
            }
        }

        public async IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            await Load();
            foreach (var item in _elements)
            {
                yield return item;
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (!IsSaved)
            {
                await SaveAsync();
            }

            _elements = null;
        }

        private void Elements_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            IsSaved = false;
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
            if (sender is IEntity element)
            {
                element.Modified = DateTime.Now;
            }
            IsSaved = false;
        }
    }
}
