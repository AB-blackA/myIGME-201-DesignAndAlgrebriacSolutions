using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Dyscord
{

    public delegate void UpdateConversationDelegate(string text);

    public partial class DyscordForm : Form
    {

        string targetUser ="";
        string targetIp ="";
        int targetPort;
        string myIp ="";
        int myPort = 2222; //default value
        Thread thread;
        Socket listener;

        public DyscordForm()
        {
            InitializeComponent();

            this.Show();
            SettingsForm settingsForm = new SettingsForm(this, myPort);
            settingsForm.ShowDialog();
            this.myPort = settingsForm.myPort;

            ThreadStart threadStart = new ThreadStart(Listen);
            thread = new Thread(threadStart);
            thread.Start();

            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            foreach( IPAddress ipAddress in ipHost.AddressList )
            {
                if( ipAddress.AddressFamily == AddressFamily.InterNetwork)
                {
                    this.myIp = ipAddress.ToString();
                    break;
                }
            }

            this.logInButton.Click += new EventHandler(LogInButton__Click);
            this.usersButton.Click += new EventHandler(UsersButton__Click);
            this.sendButton.Click += new EventHandler(SendButton__Click);
            this.exitButton.Click += new EventHandler(ExitButton__Click);
            this.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowser__DocumentCompleted);
        }

        private void ExitButton__Click(object sender, EventArgs e)
        {
            listener.Close();
            thread.Abort();

            Application.Exit();
        }

        private void SendButton__Click(object sender, EventArgs e)
        {
            if( this.targetIp.Length > 0)
            {
                IPAddress iPAddress = IPAddress.Parse(this.targetIp);
                IPEndPoint remoteEndPoint = new IPEndPoint(iPAddress, this.targetPort);

                Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                server.Connect(remoteEndPoint);
                Stream netStream = new NetworkStream(server);
                StreamWriter writer = new StreamWriter(netStream);

                string msg = userTextBox.Text + ": " + this.msgRichTextBox.Text;
                writer.Write(msg.ToCharArray(), 0 , msg.Length );

                writer.Close();
                netStream.Close();
                server.Close();

                this.convRichTextBox.Text += "> " + targetUser + ": " + this.msgRichTextBox.Text + "\n";

                this.msgRichTextBox.Clear();
            }
        }

        private void LogInButton__Click(object sender, EventArgs e)
        {
            if( this.userTextBox.TextLength > 0)
            {
                this.webBrowser1.Navigate("http://people.rit.edu/dxsigm/php/login.php?login=" + usersButton.Text + "&ip=" + myIp + ":" + myPort);
                webBrowser1.Visible = false;
                userTextBox.Enabled = false;
                logInButton.Enabled = false;
            }
        }

        private void UsersButton__Click(object sender, EventArgs e)
        {
            this.webBrowser1.Navigate("http://people.rit.edu/dxsigm/php/login.php?login=");
            this.webBrowser1.Visible = true;
            this.convRichTextBox.SendToBack();
        }

        private void WebBrowser__DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlElementCollection htmlElementCollection;
            htmlElementCollection = this.webBrowser1.Document.GetElementsByTagName("button");

            foreach(HtmlElement htmlElement in htmlElementCollection)
            {
                htmlElement.Click += new HtmlElementEventHandler(HtmlElement__Click);
            }
        }

        private void HtmlElement__Click(object sender, HtmlElementEventArgs e)
        {
            string title;
            string[] ipPort;

            HtmlElement htmlElement = (HtmlElement)sender;

            title = htmlElement.GetAttribute("title");

            ipPort = title.Split(':');
            this.targetIp = ipPort[0];
            this.targetPort = Int32.Parse(ipPort[1]);

            this.targetUser = htmlElement.GetAttribute("name");
            this.groupBox1.Text = "Conversing with " + this.targetUser;
            webBrowser1.Visible = false;
            webBrowser1.SendToBack();
        }

        public void UpdateConversation(string text)
        {
            this.convRichTextBox.Text = text + "\n";
        }

        public void Listen()
        {
            UpdateConversationDelegate updateConversationDelegate;
            updateConversationDelegate = new UpdateConversationDelegate(UpdateConversation);

            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, this.myPort);

            this.listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            listener.Bind(serverEndPoint);
            listener.Listen(300); //max no of connections

            while (true)
            {
                Socket client = listener.Accept();
                Stream netStream = new NetworkStream(client);
                StreamReader reader = new StreamReader(netStream);
                string result = reader.ReadToEnd();
                Invoke(updateConversationDelegate, result);
                reader.Close();
                netStream.Close();
                client.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
