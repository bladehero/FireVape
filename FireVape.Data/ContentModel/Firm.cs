using FireVape.Interfaces.Data.Content;

namespace FireVape.Data.ContentModel
{
    public class Firm : Entity, IFirm
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
