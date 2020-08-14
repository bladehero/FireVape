namespace FireVape.Interfaces
{
    public interface IResourceService
    {
        string ElementNaming { get; }
        string ElementsNaming { get; }
        string ExitMessage { get; }
        string FirmNaming { get; }
        string FirmsNaming { get; }
        string SaveBeforeExitMessage { get; }

        string DeleteConfirmation(string name = null);
    }
}