using FireVape.Interfaces.Data.Content;

namespace FireVape.WPF.Models.ContentModel
{
    public class VolumeOption : Entity, IVolumeable
    {
        private int volume;

        public int Volume
        {
            get => volume;
            set
            {
                volume = value;
                OnPropertyChanged(() => Volume);
            }
        }

        public override string ToString()
        {
            return $"{Volume}мл.";
        }
    }
}
