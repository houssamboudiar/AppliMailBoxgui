using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Server;
using ClientSender;
using ClientReceiver;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;
using IRemote;

namespace MessengerGUI
{
    public partial class MessengerGUI : Form
    {
        string address;
        string sendthis;
        SendMessages sm = new SendMessages();
        ReceiveMessage rm = new ReceiveMessage();
        List<string> Messages = new List<string>();
        //string Messages ;
        ServerControl sc = new ServerControl();
        public MessengerGUI()
        {
            InitializeComponent();
        }
        
        /*private static Boolean isSenderChInit = false;
        private static Boolean isReceiverChInit = false;
        private static Boolean isServerChInit = false;

        public void initSendChannel()
        {
            if (isSenderChInit)
            {
                Console.WriteLine("Sender It's already initialized !");
            }
            else
            {
                TcpChannel SendingChannel = new TcpChannel();
                ChannelServices.RegisterChannel(SendingChannel, false);
                isSenderChInit = true;
            }
        }

        public void initServerChannel(int port)
        {
            if (isServerChInit)
            {
                Console.WriteLine("Server It's already initialized !");
            }
            else
            {
                TcpChannel tcpChannel = new TcpChannel(port);
                ChannelServices.RegisterChannel(tcpChannel, false);
                isServerChInit = true;
            }
        }

        public void initReceiveChannel()
        {
            if (isReceiverChInit)
            {
                Console.WriteLine("Receiver It's already initialized !");
            }
            else
            {
                TcpChannel ReceivingChannel = new TcpChannel();
                ChannelServices.RegisterChannel(ReceivingChannel, false);
                isSenderChInit = true;
            }
        }*/


        private void button1_Click(object sender, EventArgs e)  // Sending button
        {
            if (textBox5.Text != "")
            {
                address = sendaddress.Text;
                sendthis = textBox5.Text;
                sm.SendingMessages(address, sendthis);/*
                
                 Implementing it here!
                 */
                this.textBox3.Invoke(new MethodInvoker(delegate () { textBox3.AppendText("Me : " + sendthis + "\n"); }));
            }
            else
            {
                this.textBox3.Invoke(new MethodInvoker(delegate () { textBox3.AppendText("You can't just send nothing !\n"); }));
            }
            textBox5.Text = "";
        }



        private void button2_Click_1(object sender, EventArgs e) // Receiving button
        {
            {
                address = sendaddress.Text;
                Messages = rm.ReceivingMessages(address);
                if (Messages != null)
                {
                    foreach (var message in Messages)
                    {
                        this.textBox3.Invoke(new MethodInvoker(delegate () { textBox3.AppendText("Sender : " + message + "\n"); }));
                    }
                }
                else
                {
                    Console.WriteLine("You sure anyone is talking to you !!");
                    this.textBox3.Invoke(new MethodInvoker(delegate () { textBox3.AppendText("Something went wrong \n"); }));
                }
            }
        }

        private void MessengerGUI_Load(object sender, EventArgs e)
        {

        }

        /*public void StartServer(int port)
        {
            try
            {
                initServerChannel(port);
                RemotingConfiguration.RegisterWellKnownServiceType(typeof(MailBox), "ObjMailBox", WellKnownObjectMode.Singleton);
                Console.WriteLine("Server Started On ==> localhost:" + port + " ...\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Server Initialization Error : " + ex.Message);
            }
        }

        public string ReceivingMessages(string address)
        {
            try
            {
                initReceiveChannel();
                string tcpaddress = "tcp://" + address + "/ObjMailBox";
                Console.WriteLine("Receiving Messages listening to : " + address);
                IMailBox mailbox = (IMailBox)Activator.GetObject(typeof(IMailBox) , tcpaddress);
                Console.WriteLine("See me bitch ! " + mailbox);
                if (mailbox == null)
                {
                    Console.WriteLine("Start your server\n!");
                    return null;
                }
                else
                {
                    Console.WriteLine("Receiving Connected !");
                    return mailbox.receiveMsg();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Client Main Exception" + ex.Message);
                return null;
            }
        }


        public void SendingMessages(string address, string Message)
        {
            try
            {
                initReceiveChannel();
                Console.WriteLine("Client : Channel Registered\n");
                string tcpaddress = "tcp://" + address + "/ObjMailBox";
                IMailBox mailbox = (IMailBox)Activator.GetObject(typeof(IMailBox), tcpaddress);
                if (mailbox == null)
                {
                    Console.WriteLine("Start your server\n!");
                }
                else
                {
                    Console.WriteLine("Connected !here you go");
                    mailbox.sendMsg(Message);
                    Console.WriteLine("gotcha :" + Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Client Main Exception " + ex.Message);
            }

        }*/


    }
}
