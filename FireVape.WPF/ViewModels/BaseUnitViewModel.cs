using Caliburn.Micro;
using FireVape.Interfaces.Data.Repositories;

namespace FireVape.WPF.ViewModels
{
    public class BaseUnitViewModel : Screen
    {
        protected IUnitOfWork UnitOfWork { get; private set; }

        public BaseUnitViewModel(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
