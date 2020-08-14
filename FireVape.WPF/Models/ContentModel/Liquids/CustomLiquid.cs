using FireVape.Interfaces.Data.Content.Components;
using FireVape.Interfaces.Data.Content.Liquids;
using System.Collections.Generic;

namespace FireVape.WPF.Models.ContentModel.Liquids
{
    public class CustomLiquid : Liquid, ICustomLiquid
    {
        private IList<IComponent> components;

        public IList<IComponent> Components
        {
            get => components;
            set
            {
                components = value;
                OnPropertyChanged(() => Components);
            }
        }
    }
}
