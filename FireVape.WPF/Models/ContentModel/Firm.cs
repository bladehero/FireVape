using FireVape.Interfaces.Data.Content;

namespace FireVape.WPF.Models.ContentModel
{
    public class Firm : Entity, IFirm
    {
        private string name;
        private string country;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(() => Name);
                OnPropertyChanged(() => FullName);
            }
        }
        public string Country
        {
            get => country;
            set
            {
                country = value;
                OnPropertyChanged(() => Country);
                OnPropertyChanged(() => FullName);
            }
        }

        public string FullName => $"{Name} ({Country})";
    }
}
