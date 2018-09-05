using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfMinesService
{
    [DataContract]
    public class MessageInfo
    {
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string FromCLient { get; set; }
        [DataMember]
        public List<string> ToClients { get; set; }
    }
}
