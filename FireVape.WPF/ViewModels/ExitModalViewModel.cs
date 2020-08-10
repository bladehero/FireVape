using Caliburn.Micro;

namespace FireVape.WPF.ViewModels
{
    public class ExitModalViewModel : Screen
    {
        public void NoButton()
        {
            TryClose(false);
        }

        public void YesButton()
        {
            TryClose(true);
        }
    }
}
