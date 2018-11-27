using System;
using System.Collections.Generic;

namespace IRemote
{
    public interface IMailBox
    {
        void sendMsg(string msg);
        List<string> receiveMsg();
    }
}
