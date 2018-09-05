using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfMinesService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(IGameServiceCallback))]
    public interface IGameService
    {
        [OperationContract]
        void SendMessage(MessageInfo info);
        
        [OperationContract]
        [FaultContract(typeof(UserExistsFault))]
        void ClientConnected(string username);
        [OperationContract]
        void ClientDisconnected(string username);
    }

    public interface IGameServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void PutMessage(string message, string fromClient);

        [OperationContract(IsOneWay = true)]
        void UpdateClientsList(IEnumerable<string> clients);
    }

}
