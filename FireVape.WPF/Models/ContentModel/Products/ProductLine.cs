using Caliburn.Micro;
using FireVape.Interfaces.Data.Content;
using FireVape.Interfaces.Data.Content.Products;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace FireVape.WPF.Models.ContentModel.Products
{
    public class ProductLine : Entity, IProductLine<IVolumeable>
    {
        private string name;
        private BindableCollection<IProductOption<IVolumeable>> options;

        public ProductLine()
        {
            Options = new BindableCollection<IProductOption<IVolumeable>>();
        }

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(() => Name);
            }
        }
        public IList<IProductOption<IVolumeable>> Options
        {
            get => options;
            set
            {
                options = new BindableCollection<IProductOption<IVolumeable>>(value);
                OnPropertyChanged(() => Options);
                OnPropertyChanged(() => StringOptions);
                if (options != null )
                {
                    if (options.Count > 0)
                    {
                        foreach (var option in options)
                        {
                            option.PropertyChanged += Option_PropertyChanged;
                        }
                    }
                    options.CollectionChanged += Options_CollectionChanged;
                }
            }
        }

        private void Option_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnPropertyChanged(() => Options);
            OnPropertyChanged(() => StringOptions);
        }

        private void Options_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (INotifyPropertyChanged item in e.OldItems)
                    item.PropertyChanged -= Option_PropertyChanged;
            }
            if (e.NewItems != null)
            {
                foreach (INotifyPropertyChanged item in e.NewItems)
                    item.PropertyChanged += Option_PropertyChanged;
            }
            OnPropertyChanged(() => Options);
            OnPropertyChanged(() => StringOptions);
        }

        public string StringOptions => Options?.Count > 0 
            ? string.Join(", ", Options.Select(x => $"{x.Value} ({x.Price}₴)")) 
            : "—";
    }
}
