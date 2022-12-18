using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using SimpleTCP;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO.Ports;

namespace VoidRayServer
{
    internal class TCP_Control
    {

        //Server Config


        public SimpleTcpServer voidRayServer = new SimpleTcpServer();
        
      
        public void serverVoid()
        {


            voidRayServer.Delimiter = 0x13;//enter?
            voidRayServer.StringEncoder = Encoding.UTF8;
            voidRayServer.DataReceived += Server_Datareceived;


        }

      

        private void Server_Datareceived(object sender, SimpleTCP.Message e)
        {
            Form1 form1 = new Form1();
            TextBox statusBox = new TextBox();
            statusBox = form1.Status();

            if (form1.IsHandleCreated)
            {
                statusBox.Invoke((MethodInvoker)delegate ()
                {
                    statusBox.Text += e.MessageString;
                    e.ReplyLine(string.Format("You said:", e.MessageString));

                });
            }
                
        
        }

       

        public bool IsServerOnline()
        {
            if (voidRayServer.IsStarted)
            {
                return true; 
            }else

            return false; 

        }

        public void ServerOnline()
        {
            Form1 warpGate1 = new Form1();

            string ipAdress = warpGate1.IPAdress;
            string port = warpGate1.ServerPort;

            
            IPAddress ip = IPAddress.Parse(ipAdress);

            voidRayServer.Start(ip, Convert.ToInt32(port));
            warpGate1.TextBoxStatus += "hey"; 

            

        }

        public void ServerOffline()
        {

            voidRayServer.Stop();

        }

      




        public string DoSomething(string pText)
        {
            return "";

        }


    }






}
