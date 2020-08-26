using FireVape.Interfaces.Data.Content.Components;
using FireVape.Interfaces.Data.Content.Liquids;
using System.Collections.Generic;
using System.Linq;

namespace FireVape.WPF.Models.ContentModel.Liquids
{
    public class CustomLiquid : Liquid, ICustomLiquid
    {
        private IList<IComponent> components;

        public override decimal? Cost 
        {
            get => Components?.Sum(x => x.Cost); 
            set { } 
        }

        public IList<IComponent> Components
        {
            get => components;
            set
            {
                components = value;
                OnPropertyChanged(() => Components);
                if (components?.Count > 0)
                {
                    foreach (var component in components)
                    {
                        component.PropertyChanged += (o, e) => OnPropertyChanged(() => Components);
                    }
                }
            }
        }
    }
}
