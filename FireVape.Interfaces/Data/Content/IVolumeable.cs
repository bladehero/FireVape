namespace FireVape.Interfaces.Data.Content
{
    public interface IVolumeable : IEntity
    {
        int Volume { get; set; }
        string Unit { get; set; }

        string VolumeUnit { get; }
    }
}
