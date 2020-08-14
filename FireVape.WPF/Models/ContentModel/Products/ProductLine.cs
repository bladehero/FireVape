using FireVape.Interfaces.Data.Content;
using FireVape.Interfaces.Data.Content.Products;
using System.Collections.Generic;

namespace FireVape.WPF.Models.ContentModel.Products
{
    public class ProductLine : Entity, IProductLine<IVolumeable>
    {
        private string name;
        private IList<IProductOption<IVolumeable>> options;

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
                options = value;
                OnPropertyChanged(() => Options);
            }
        }
    }
}
