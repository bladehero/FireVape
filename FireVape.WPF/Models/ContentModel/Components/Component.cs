using FireVape.Interfaces.Data.Content;
using FireVape.Interfaces.Data.Content.Components;

namespace FireVape.WPF.Models.ContentModel.Components
{
    public class Component : Entity, IComponent
    {
        private string name;
        private IFirm firm;
        private decimal cost;

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
        public decimal Cost
        {
            get => cost;
            set
            {
                cost = value;
                OnPropertyChanged(() => Cost);
            }
        }
    }
}
