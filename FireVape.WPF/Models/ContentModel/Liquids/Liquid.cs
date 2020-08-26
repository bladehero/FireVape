using FireVape.Interfaces.Data.Content;
using FireVape.Interfaces.Data.Content.Liquids;
using FireVape.Interfaces.Data.Content.Products;

namespace FireVape.WPF.Models.ContentModel.Liquids
{
    public class Liquid : Entity, ILiquid
    {
        private IProductOption<IVolumeable> productOption;
        private string name;
        private IFirm firm;
        private decimal? cost;
        private decimal? price;

        public IProductOption<IVolumeable> ProductOption
        {
            get => productOption;
            set
            {
                productOption = value;
                OnPropertyChanged(() => ProductOption);
            }
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
        public IFirm Firm
        {
            get => firm;
            set
            {
                firm = value;
                OnPropertyChanged(() => Firm);
            }
        }
        public virtual decimal? Cost
        {
            get => cost;
            set
            {
                cost = value;
                OnPropertyChanged(() => Cost);
            }
        }
        public decimal? Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged(() => Price);
            }
        }

        public decimal? Income =>
            Price.HasValue && Cost.HasValue
            ? (decimal?)(Price.Value - Cost.Value)
            : null;
    }
}
