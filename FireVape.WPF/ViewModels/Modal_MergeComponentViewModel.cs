using FireVape.Interfaces.Data.Content.Components;
using FireVape.WPF.Models.ContentModel.Components;
using FireVape.WPF.ViewModels.BaseViewModels;
using System;
using System.Globalization;

namespace FireVape.WPF.ViewModels
{
    public class Modal_MergeComponentViewModel : MergeModal<IComponent>
    {
        public Modal_MergeComponentViewModel() => Element = new Component();

        private string costString;
        public string CostString
        {
            get => costString;
            set
            {
                try
                {
                    var cost = decimal.Parse(value, NumberStyles.Float, CultureInfo.InvariantCulture);
                    costString = value;
                    Element.Cost = cost;
                }
                catch (FormatException)
                {
                    costString = null;
                    Element.Cost = null;
                }
            }
        }
    }
}
