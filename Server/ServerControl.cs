using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using IRemote;

namespace Server
{
    public class ServerControl
    {
        public void StartServer(int port)
        {
            try
            {
                TcpChannel tcpChannel = new TcpChannel(port);
                ChannelServices.RegisterChannel(tcpChannel, false);
                RemotingConfiguration.RegisterWellKnownServiceType(typeof(MailBox), "ObjMailBox", WellKnownObjectMode.SingleCall);
                Console.WriteLine("Server Started On ==> localhost:"+port+" ...\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Server Initialization Error : " + ex.Message);
            }
        }
    }
}
