using FireVape.Interfaces.Data.Content;
using FireVape.Interfaces.Data.Content.Components;

namespace FireVape.Data.ContentModel.Components
{
    public class VolumeableComponent : Entity, IVolumeableComponent
    {
        public string Name { get; set; }
        public IFirm Firm { get; set; }
        public decimal Cost { get; set; }
        public int Volume { get; set; }
        public string Unit { get; set; }
    }
}
