using Caliburn.Micro;

namespace FireVape.WPF.ViewModels
{
    public class Modal_ConfirmationViewModel : Screen
    {
        public bool? Result { get; private set; } = null;
        public string Message { get; set; }

        public Modal_ConfirmationViewModel(string message) => Message = message;

        public bool CancelIsVisible { get; set; } = true;
        public bool NoIsVisible { get; set; } = false;
        public bool YesIsVisible { get; set; } = true;

        public void Cancel() => TryClose();
        public void No() => TryClose(Result = false);
        public void Yes() => TryClose(Result = true);
    }
}
