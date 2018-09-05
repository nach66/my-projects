using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace WcfMinesService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
        ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class GameService : IGameService
    {
        SortedDictionary<string, IGameServiceCallback> callbacks
            = new SortedDictionary<string, IGameServiceCallback>();
        List<string> availables = new List<string>();
        public void ClientConnected(string username)
        {
            try
            {
                /**   if (callbacks.ContainsKey(username))
                   {
                         throw new FaultException<UserExistsFault>(
                             new UserExistsFault
                             {
                                 Message = username + " already exists"
                             }
                   }*/

                IGameServiceCallback callback =
                    OperationContext.Current.GetCallbackChannel
                    <IGameServiceCallback>();
                callbacks.Add(username, callback);
                availables.Add(username);
                UpdateUsersList();
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        private void UpdateUsersList()
        {
            Thread updateListThread = new Thread(() =>
            {
                foreach (var callback in callbacks.Values)
                {
                    callback.UpdateClientsList(availables);
                }
            });
            updateListThread.Start();
        }

        public void ClientDisconnected(string username)
        {
            callbacks.Remove(username);
            availables.Remove(username);
            UpdateUsersList();
        }


        public void SendMessage(MessageInfo info)
        {
            string Details = info.Message;
            var WordsArray = Details.Split();
            if (WordsArray[0] == "removefromlist")
            {
                availables.Remove(WordsArray[1]);
                availables.Remove(WordsArray[2]);
                UpdateUsersList();

            }
            else if (WordsArray[0] == "addtolist")
            {
                availables.Add(WordsArray[1]);
                availables.Add(WordsArray[2]);
                UpdateUsersList();
            }
            else
            {
                Thread putMessageThread = new Thread(() =>
                {
                    foreach (var clientName in info.ToClients)
                        callbacks[clientName].PutMessage(info.Message, info.FromCLient);
                });
                putMessageThread.Start();
            }
               
            
           
               
            
            
        }

       
    }
}
