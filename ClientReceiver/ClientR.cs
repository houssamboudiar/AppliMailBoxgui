using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using IRemote;
using System.Runtime.Remoting.Activation;

namespace ClientReceiver
{
    public class ReceiveMessage
    {
        //////////////////////////////////////////////////////////////////////////////////
        public List<string> ReceivingMessages(string address)
        {
            try
            {
                TcpChannel ReceivingChannel = new TcpChannel();
                ChannelServices.RegisterChannel(ReceivingChannel, false);
                string tcpaddress = "tcp://"+address+"/ObjMailBox";
                Console.WriteLine("Receiving Messages listening to : " + address);
                IMailBox mailbox = (IMailBox)Activator.GetObject(typeof(IMailBox), tcpaddress);
                IFactory mb;
                //mb.getNewMailBox();
                //IMailBox mailbox = Activator.CreateInstance(typeof(IMailBox), null, new Object[] { new UrlAttribute("tcp://++"/ObjMailBox") }) as IMailBox;
                if (mailbox == null)
                {
                    Console.WriteLine("Start your server\n!");
                    return null;
                }
                else
                {
                    Console.WriteLine("Receiving Connected !");
                    List<string> msgtmp = mailbox.receiveMsg();
                    ChannelServices.UnregisterChannel(ReceivingChannel);
                    return msgtmp;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Client Main Exception" + ex.Message);
                return null;
            }
            
        }

        //////////////////////////////////////////////////////////////////////////////////
    }
    class ClientR
    {
        static void Main(string[] args)
        {
            ReceiveMessage rm = new ReceiveMessage();
            rm.ReceivingMessages("localhost:1234");
            Console.ReadLine();
        }
    }
}
