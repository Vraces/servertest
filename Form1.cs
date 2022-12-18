using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using SimpleTCP;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading;

namespace VoidRayServer
{
    
    public partial class Form1 : Form
    {

        public SimpleTcpServer voidRayServer;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

           
            TCP_Control form2 = new TCP_Control();

            statusBox.Text = form2.DoSomething(Text);

            form2.serverVoid(); 












        }
        public string TextBoxStatus
        {
            get { return statusBox.Text;}
            set { statusBox.Text = value;}
            

        }

        


        private void hostToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ipBox_TextChanged(object sender, EventArgs e)
        {




            ipBox.Text = ipBox.Text.Replace(",", ".");
            ipBox.SelectionStart = ipBox.Text.Length;
            ipBox.SelectionLength = 0;


        }

        private void lockIp_Click(object sender, EventArgs e)
        {
            ipBox.Enabled= false;
            portBox.Enabled= false;
            lockIp.Enabled= false;
            unlockBtn.Enabled= true;

        }

        private void unlockBtn_Click(object sender, EventArgs e)
        {
            ipBox.Enabled = true;
            lockIp.Enabled = true;
            portBox.Enabled = true;
            unlockBtn.Enabled= false;
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            string ipString = ipBox.Text.ToString(); 
            Connect.Enabled = false;
            terminate.Enabled = true;

            //long ipPippi = long.Parse(ipString);

            TCP_Control warpPrism = new TCP_Control();
            warpPrism.serverVoid(); 
            warpPrism.ServerOnline();

            // statusBox.Clear();

            bool serverStatus = false;
            string SS = serverStatus.ToString();

            statusBox.AppendText(SS); 

            serverStatus = warpPrism.IsServerOnline();
            if (serverStatus == true) {
                statusBox.AppendText("Prismatic core aligned!");
            } else if (serverStatus == false) {
                statusBox.AppendText("Server is still offline!"); 



            } else
                statusBox.Text = "My life for Aiur!";



            string SS2 = serverStatus.ToString();
            statusBox.AppendText(SS2);






        }


        public string IPAdress
        {
            get { return ipBox.Text; }

        } 
        public string ServerPort
        {
           get { return portBox.Text; }

        }
       

        private void terminate_Click(object sender, EventArgs e)
        {
            TCP_Control warpPrism = new TCP_Control();  

            warpPrism.ServerOffline();
           
            

            bool serverStatus = warpPrism.IsServerOnline();


            serverStatus = warpPrism.IsServerOnline();
            if (serverStatus == true)
            {
                statusBox.AppendText("Server shutdown failed!");
            }
            else if (serverStatus == false)
            {
                statusBox.AppendText("Server shutdown succeded!");



            }
            else
                statusBox.Text = "My life for Aiur!";


            terminate.Enabled= false;
            Connect.Enabled= true; 

        }

        private void statusBox_TextChanged(object sender, EventArgs e)
        {

        }

        public System.Windows.Forms.TextBox Status()
        {
            

            return statusBox;

        }
    }
}
