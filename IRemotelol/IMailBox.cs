using System;
using System.Collections.Generic;

namespace IRemote
{
    public interface IMailBox
    {
        /*void sendMsg(Message msg);
        List<Message> receiveMsg();*/
        void sendMsg(string msg);
        string receiveMsg();
    }
    /*public class Message
    {
        string Msg;

        public Message(string Msg)
        {
            this.Msg = Msg;
        }

        public string getMsg()
        {
            return Msg;
        }
        public void setMsg(string msg)
        {
            Msg = msg;
        }*/
}
}
