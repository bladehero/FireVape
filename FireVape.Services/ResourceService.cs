using FireVape.Interfaces;
using System.Resources;
using System.Text.RegularExpressions;

namespace FireVape.Services
{
    public class ResourceService : IResourceService
    {
        private readonly ResourceManager _resourceManager;
        private readonly Regex _regex = new Regex("{{(.*?)}}");

        public ResourceService(ResourceManager resourceManager) => _resourceManager = resourceManager;

        public string DeleteConfirmation(string name = null) =>
            _regex.Replace(_resourceManager.GetString("DeleteConfirmation") ?? string.Empty,
                           name ?? ElementsNaming?.ToLower() ?? string.Empty);

        #region Messages
        public string ExitMessage => _resourceManager.GetString("ExitMessage");
        public string SaveBeforeExitMessage => _resourceManager.GetString("SaveBeforeExitMessage");
        #endregion

        #region Namings
        public string ElementNaming => _resourceManager.GetString("ElementNaming");
        public string ElementsNaming => _resourceManager.GetString("ElementsNaming");
        public string FirmNaming => _resourceManager.GetString("FirmNaming");
        public string FirmsNaming => _resourceManager.GetString("FirmsNaming");
        #endregion
    }
}
