using FireVape.Interfaces.Data.Content;

namespace FireVape.WPF.Models.ContentModel
{
    public class VolumeOption : Entity, IVolumeable
    {
        private int volume;
        private string unit;

        public int Volume
        {
            get => volume;
            set
            {
                volume = value;
                OnPropertyChanged(() => Volume);
                OnPropertyChanged(() => VolumeUnit);
            }
        }
        public string Unit
        {
            get => unit;
            set
            {
                unit = value;
                OnPropertyChanged(() => Unit);
                OnPropertyChanged(() => VolumeUnit);
            }
        }
        public string VolumeUnit => ToString();

        public override string ToString()
        {
            return $"{Volume} {Unit}";
        }
    }
}
