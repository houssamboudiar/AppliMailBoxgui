using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using IRemote;

namespace Server
{
    class ServerMain
    {
        
        static void Main(string[] args)
        {
            ServerControl sc = new ServerControl();
            sc.StartServer(1234);
            Console.ReadLine();
        }
    }
}
