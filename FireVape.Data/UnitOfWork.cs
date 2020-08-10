using FireVape.Interfaces.Data.Client;
using FireVape.Interfaces.Data.Content;
using FireVape.Interfaces.Data.Content.Components;
using FireVape.Interfaces.Data.Content.Liquids;
using FireVape.Interfaces.Data.Content.Products;
using FireVape.Interfaces.Data.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using IComponent = FireVape.Interfaces.Data.Content.Components.IComponent;

namespace FireVape.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public const string FolderForRepositories = "Repositories";

        public UnitOfWork()
        {
            Directory.CreateDirectory(FolderForRepositories);
        }

        public IRepository<IFirm> Firms { get; } = new Repository<IFirm>();
        public IRepository<IComponent> Components { get; } = new Repository<IComponent>();
        public IRepository<IComponentForSale> ComponentForSales { get; } = new Repository<IComponentForSale>();
        public IRepository<IVolumeableComponent> VolumeableComponents { get; } = new Repository<IVolumeableComponent>();
        public IRepository<IVolumeableComponentForSale> VolumeableComponentForSales { get; } = new Repository<IVolumeableComponentForSale>();
        public IRepository<IProductLine<IVolumeable>> ProductLines { get; } = new Repository<IProductLine<IVolumeable>>();
        public IRepository<IProductOption<IVolumeable>> ProductOptions { get; } = new Repository<IProductOption<IVolumeable>>();
        public IRepository<ILiquid> Liquids { get; } = new Repository<ILiquid>();
        public IRepository<ICustomLiquid> CustomLiquids { get; } = new Repository<ICustomLiquid>();
        public IRepository<IClient> Clients { get; } = new Repository<IClient>();
        public IRepository<IOrder> Orders { get; } = new Repository<IOrder>();
        public IRepository<IOrderStatus> OrderStatuses { get; } = new Repository<IOrderStatus>();

        [IgnoreDataMember]
        public bool IsSaved
        {
            get
            {
                var saveables = GetPropertiesWithType<IAsyncSaveable>();
                return saveables.All(x => x.IsSaved);
            }
        }

        public async Task SaveAsync()
        {
            var saveables = GetPropertiesWithType<IAsyncSaveable>();
            var tasks = new List<Task>();
            foreach (var saveable in saveables)
            {
                tasks.Add(saveable.SaveAsync());
            }
            await Task.WhenAll(tasks);
        }

        public async ValueTask DisposeAsync()
        {
            var disposables = GetPropertiesWithType<IAsyncDisposable>();
            var tasks = new List<Task>();
            foreach (var disposable in disposables)
            {
                tasks.Add(disposable.DisposeAsync().AsTask());
            }
            await Task.WhenAll(tasks);
        }

        private IEnumerable<T> GetPropertiesWithType<T>()
        {
            foreach (var property in GetType().GetProperties())
            {
                if (property.GetCustomAttribute<IgnoreDataMemberAttribute>() == null)
                {
                    var obj = property.GetValue(this);
                    if (obj is T typed)
                    {
                        yield return typed;
                    }
                }
            }
        }
    }
}
