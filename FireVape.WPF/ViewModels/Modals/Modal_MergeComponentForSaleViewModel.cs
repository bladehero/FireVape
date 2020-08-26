using Caliburn.Micro;
using FireVape.Interfaces.Data.Content;
using FireVape.Interfaces.Data.Content.Components;
using FireVape.WPF.Models.ContentModel.Components;
using FireVape.WPF.ViewModels.BaseViewModels;
using System;
using System.Globalization;

namespace FireVape.WPF.ViewModels
{
    public class Modal_MergeComponentForSaleViewModel : MergeModal<IComponentForSale>
    {
        public Modal_MergeComponentForSaleViewModel() => Element = new ComponentForSale();

        private string costString;
        private string priceString;
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

        public string PriceString
        {
            get => priceString;
            set
            {
                try
                {
                    var price = (decimal?)0;
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        price = decimal.Parse(value, NumberStyles.Float, CultureInfo.InvariantCulture);
                    }
                    priceString = value;
                    Element.Price = price;
                }
                catch (FormatException)
                {
                    System.Media.SystemSounds.Beep.Play();
                }
                NotifyOfPropertyChange(() => PriceString);
            }
        }

        public override IComponentForSale Element
        {
            get => base.Element;
            set
            {
                base.Element = value;
                costString = value.Cost?.ToString();
                priceString = value.Price?.ToString();

                NotifyOfPropertyChange(() => CostString);
                NotifyOfPropertyChange(() => PriceString);
                NotifyOfPropertyChange(() => Element);
            }
        }

        public BindableCollection<IFirm> Firms
        {
            get => firms;
            set
            {
                firms = value;
                NotifyOfPropertyChange(() => Firms);
                NotifyOfPropertyChange(() => Element);
            }
        }
    }
}
