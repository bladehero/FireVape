using FireVape.Interfaces.Data.Content.Components;

namespace FireVape.WPF.Models.ContentModel.Components
{
    public class ComponentForSale : Component, IComponentForSale
    {
        private decimal? price;

        public override decimal? Cost 
        { 
            get => base.Cost;
            set
            {
                base.Cost = value;
                OnPropertyChanged(() => Income);
            }
        }

        public decimal? Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged(() => Price);
                OnPropertyChanged(() => Income);
            }
        }

        public decimal? Income => 
            Price.HasValue && Cost.HasValue 
            ? (decimal?)(Price.Value - Cost.Value) 
            : null;
    }
}
