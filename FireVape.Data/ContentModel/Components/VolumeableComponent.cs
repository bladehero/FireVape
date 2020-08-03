using FireVape.Interfaces.Data.Content;
using FireVape.Interfaces.Data.Content.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace FireVape.Data.ContentModel.Components
{
    public class VolumeableComponent : IVolumeableComponent
    {
        public string Name { get; set; }
        public IFirm Firm { get; set; }
        public decimal Cost { get; set; }
        public int Volume { get; set; }
    }
}
