using Caliburn.Micro;
using FireVape.Interfaces.Data.Content;
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
        private BindableCollection<IFirm> firms;

        public string CostString
        {
            get => costString;
            set
            {
                try
                {
                    var cost = (decimal?)0;
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        cost = decimal.Parse(value, NumberStyles.Float, CultureInfo.InvariantCulture);
                    }
                    costString = value;
                    Element.Cost = cost;
                }
                catch (FormatException)
                {
                    System.Media.SystemSounds.Beep.Play();
                }
                NotifyOfPropertyChange(() => CostString);
            }
        }

        public override IComponent Element
        {
            get => base.Element;
            set
            {
                base.Element = value;
                costString = value.Cost?.ToString();

                NotifyOfPropertyChange(() => CostString);
            }
        }

        public BindableCollection<IFirm> Firms
        {
            get => firms;
            set
            {
                firms = value;
                NotifyOfPropertyChange(() => Firms);
            }
        }
    }
}
