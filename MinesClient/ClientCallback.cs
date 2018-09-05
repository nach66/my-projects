using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using MinesClient.ServiceReference1;

namespace MinesClient
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ClientCallback : IGameServiceCallback
    {
        public delegate void PutMessageDelegate(string m, string fc);
        public event PutMessageDelegate putMessage;
        public void PutMessage(string message, string fromClient)
        {
            putMessage(message, fromClient);
        }
        public delegate void UpdateClientsDelegate(List<string> clients);
        public event UpdateClientsDelegate updateClients;
        public void UpdateClientsList(List<string> clients)
        {
            updateClients(clients);
        }

    }
}
