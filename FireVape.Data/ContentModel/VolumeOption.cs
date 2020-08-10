using FireVape.Interfaces.Data.Content;

namespace FireVape.Data.ContentModel
{
    public class VolumeOption : Entity, IVolumeable
    {
        public int Volume { get; set; }
        public string Unit { get; set; }

        public override string ToString()
        {
            return $"{Volume} {Unit}";
        }
    }
}
