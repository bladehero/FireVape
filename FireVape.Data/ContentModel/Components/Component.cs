using FireVape.Interfaces.Data.Content;
using FireVape.Interfaces.Data.Content.Components;

namespace FireVape.Data.ContentModel.Components
{
    public class Component : IComponent
    {
        public string Name { get; set; }
        public IFirm Firm { get; set; }
        public decimal Cost { get; set; }
    }
}
