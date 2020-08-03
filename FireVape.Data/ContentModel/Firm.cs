using FireVape.Interfaces.Data.Content;

namespace FireVape.Data.ContentModel
{
    public class Firm : IFirm
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
