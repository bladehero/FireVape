using System.ComponentModel;

namespace FireVape.Interfaces.Attributes
{
    public class VolumeDescriptionAttribute : DescriptionAttribute
    {
        public int Coefficient { get; protected set; }

        public VolumeDescriptionAttribute() : base()
        {

        }
        public VolumeDescriptionAttribute(string description) : base(description)
        {

        }
        public VolumeDescriptionAttribute(string description, int coefficient) : this(description)
        {
            Coefficient = coefficient;
        }
    }
}
