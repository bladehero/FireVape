using FireVape.Interfaces.Data.Client;

namespace FireVape.WPF.Models.ClientModel
{
    public class Delivery : Entity, IDelivery
    {
        private string where;
        private decimal? price;
        private decimal? cost;

        public string Where
        {
            get => where;
            set
            {
                where = value;
                OnPropertyChanged(() => Where);
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
        public decimal? Cost
        {
            get => cost;
            set
            {
                cost = value;
                OnPropertyChanged(() => Cost);
            }
        }

        public decimal? Income => Price.GetValueOrDefault() - Cost.GetValueOrDefault();
    }
}
