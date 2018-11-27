using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRemote;

namespace Server
{
    [Serializable]
    public class MailBox : MarshalByRefObject, IMailBox
    {
        private List<string> message = new List<string>();

        public void sendMsg(string msg)
        {
            message.Add(msg);
        }
        public List<string> receiveMsg()
        {
            return message;
        }

    }
}

