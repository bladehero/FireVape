using FireVape.Interfaces.Data.Content.Components;

namespace FireVape.WPF.Models.ContentModel.Components
{
    public class VolumeableComponent : Component, IVolumeableComponent
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

        public string VolumeUnit => $"{Volume} {Unit}";
    }
}
