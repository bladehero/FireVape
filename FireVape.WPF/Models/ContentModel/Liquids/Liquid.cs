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
        private int volume;
        private decimal? price;
        private string unit;

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
        public decimal? Cost
        {
            get => cost;
            set
            {
                cost = value;
                OnPropertyChanged(() => Cost);
            }
        }
        public int Volume
        {
            get => volume;
            set
            {
                volume = value;
                OnPropertyChanged(() => Volume);
                OnPropertyChanged(() => VolumeUnit);
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
        public string Unit
        {
            get => unit;
            set
            {
                unit = value;
                OnPropertyChanged(() => Unit);
                OnPropertyChanged(() => VolumeUnit);
            }
        }

        public string VolumeUnit => $"{Volume} {Unit}";
    }
}
