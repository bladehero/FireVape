using FireVape.Interfaces.Data.Client;

namespace FireVape.Data.ClientModel
{
    public class Client : Entity, IClient
    {
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
