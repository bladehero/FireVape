using Caliburn.Micro;
using FireVape.Interfaces.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FireVape.WPF.ViewModels
{
    public class FirmsViewModel : BaseUnitViewModel
    {
        public FirmsViewModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
