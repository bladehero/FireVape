using FireVape.Interfaces.Data.Content.Components;

namespace FireVape.WPF.Models.ContentModel.Components
{
    public class ComponentForSale : Component, IComponentForSale
    {
        private decimal? price;

        public decimal? Price
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
