using FireVape.Interfaces.Data.Client;

namespace FireVape.WPF.Models.ClientModel
{
    public class Client : Entity, IClient
    {
        private string name;
        private string phone;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(() => Name);
            }
        }
        public string Phone
        {
            get => phone;
            set
            {
                phone = value;
                OnPropertyChanged(() => Phone);
            }
        }
        public string FullName => $"{Name} {Phone}";

    }
}
