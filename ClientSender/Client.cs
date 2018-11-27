using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using IRemote;

namespace ClientSender
{
    public class SendMessages
    {
        public void SendingMessages(string address , string Message)
        {
            try
            {
                TcpChannel SendingChannel = new TcpChannel();
                ChannelServices.RegisterChannel(SendingChannel, false);
                Console.WriteLine("Client : Channel Registered\n");
                string tcpaddress = "tcp://"+address+"/ObjMailBox";
                IMailBox mailbox = (IMailBox)Activator.GetObject(typeof(IMailBox), tcpaddress);
                if (mailbox == null)
                {
                    Console.WriteLine("Start your server\n!");
                }
                else
                {
                    Console.WriteLine("Connected !here you go");
                    mailbox.sendMsg(Message);
                    Console.WriteLine("Got your message sound and clear !" + Message);
                    ChannelServices.UnregisterChannel(SendingChannel);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Client Main Exception " + ex.Message);
            }

        }

    }
    class Client
    {
        static void Main(string[] args)
        {
            SendMessages sm = new SendMessages();
            sm.SendingMessages("localhost:1234" , "Still Working on it !");
            Console.ReadLine();
        }
    }
}
