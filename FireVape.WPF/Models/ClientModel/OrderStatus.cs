using FireVape.Interfaces.Data.Client;

namespace FireVape.WPF.Models.ClientModel
{
    public class OrderStatus : Entity, IOrderStatus
    {
        private string status;

        public string Status
        {
            get => status;
            set
            {
                status = value;
                OnPropertyChanged(() => Status);
            }
        }
    }
}
