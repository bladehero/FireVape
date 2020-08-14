using FireVape.Interfaces.Data.Content;
using FireVape.Interfaces.Data.Content.Products;

namespace FireVape.WPF.Models.ContentModel.Products
{
    public class ProductOption : Entity, IProductOption<IVolumeable>
    {
        private decimal price;
        private IProductLine<IVolumeable> productLine;
        private IVolumeable value;

        public IProductLine<IVolumeable> ProductLine
        {
            get => productLine;
            set
            {
                productLine = value;
                OnPropertyChanged(() => ProductLine);
            }
        }
        public IVolumeable Value
        {
            get => value;
            set
            {
                this.value = value;
                OnPropertyChanged(() => Value);
            }
        }
        public decimal Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged(() => Price);
            }
        }
    }
}
