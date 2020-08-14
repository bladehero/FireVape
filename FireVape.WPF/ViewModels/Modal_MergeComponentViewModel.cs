using Caliburn.Micro;
using FireVape.Interfaces.Data.Content;
using FireVape.Interfaces.Data.Content.Components;
using FireVape.WPF.Models.ContentModel.Components;
using FireVape.WPF.ViewModels.BaseViewModels;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace FireVape.WPF.ViewModels
{
    public class Modal_MergeComponentViewModel : MergeModal<IComponent>
    {
        public Modal_MergeComponentViewModel()
        {
            Element = new Component();
            Task.Run(async () =>
            {
                var firms = await UnitOfWork.Firms.GetAllAsync();
                Firms = new BindableCollection<IFirm>(firms);
                NotifyOfPropertyChange(() => Firms);
            });
        }

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
                    System.Media.SystemSounds.Beep.Play();
                }
            }
        }

        public BindableCollection<IFirm> Firms { get; set; }
    }
}
