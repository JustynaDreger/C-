using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace server
{
    public partial class Form1 : Form
    {
        Server server;
        Thread thread;
        string path= AppDomain.CurrentDomain.BaseDirectory;
        int port;
        public Form1()
        {
            //server = new Server(8000,"");
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (thread == null)
            {
                thread = new Thread(() =>
                {
                    server = new Server(port, path);
                    server.StartServer();
                });
                thread.Start();
            }
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            if (thread.ThreadState == ThreadState.Running || thread != null)
            {
                server.StopServer();
                thread.Abort();
                thread = null;
            }
        }

        private void port_TextChanged(object sender, EventArgs e)
        {
            port = int.Parse(port_textbox.Text);
        }

        private void path_TextChanged(object sender, EventArgs e)
        {
            path = path_textbox.Text;
        }
    }
}
