using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerBySocket
{
    public partial class ServerForm : Form
    {
        SocketManager _sm = null;
        string ip = "192.168.1.8";
        int port = 1113;

        public ServerForm()
        {
            InitializeComponent();
            ip = GetLocalIp();
        }
        private string GetLocalIp()
        {
            string name = Dns.GetHostName();
            IPAddress[] ipadrlist = Dns.GetHostAddresses(name);

            foreach (IPAddress ipa in ipadrlist)
            {
                if (ipa.AddressFamily == AddressFamily.InterNetwork)
                    return ipa.ToString();
            }
            return "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _sm = new SocketManager(ip, port);
            _sm.OnReceiveMsg += OnReceiveMsg;
            _sm.OnConnected += OnConnected;
            _sm.OnDisConnected += OnDisConnected;
            _sm.Start();
            init();
        }

        void init()
        {
            txtMsg.Text += GetDateNow() + "  服务器启动成功！\r\n";
            lblIp.Text = ip;
            lblPort.Text = port.ToString();
            lblStatus.Text = "正常启动";
        }

        public void OnReceiveMsg(string ip)
        {
            byte[] buffer = _sm._listSocketInfo[ip].msgBuffer;

            string fileSavePath = @"..\..\files";//获得用户保存文件的路径
            if (!Directory.Exists(fileSavePath))
            {
                Directory.CreateDirectory(fileSavePath);
            }
            string fileName = fileSavePath + "\\" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".zip";
            //创建文件流，然后让文件流来根据路径创建一个文件
            FileStream fs = new FileStream(fileName, FileMode.Create);

            string msg = Encoding.ASCII.GetString(buffer).Replace("\0", "");
            if (txtMsg.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    txtMsg.Text += AppendReceiveMsg(msg, ip);
                }));
            }
            else
            {
                txtMsg.Text += AppendReceiveMsg(msg, ip);
            }
        }

        public void OnConnected(string clientIP)
        {
            string ipstr = clientIP.Split(':')[0];
            string portstr = clientIP.Split(':')[1];
            if (txtMsg.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    txtMsg.Text += clientIP + "已连接至本机\r\n";
                    object obj = new { Value = clientIP, Text = clientIP };
                    cbClient.Items.Add(obj);
                    cbClient.DisplayMember = "Value";
                    cbClient.ValueMember = "Text";
                    cbClient.SelectedItem = obj;
                }));
            }
            else
            {
                txtMsg.Text += clientIP + "已连接至本机\r\n";
            }
        }

        public void OnDisConnected(string clientIp)
        {
            if (txtMsg.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    txtMsg.Text += clientIp + "已经断开连接！\r\n";
                    object obj = new { Value = clientIp, Text = clientIp };
                    cbClient.Items.Remove(obj);
                }));
            }
            else
            {
                txtMsg.Text += clientIp + "已经断开连接！\r\n";
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!_sm._listSocketInfo.Keys.Contains(cbClient.Text)) return;
            _sm.SendMsg(txtSend.Text, cbClient.Text);
            txtMsg.Text += AppendSendMsg(txtSend.Text, cbClient.Text);
            txtSend.Text = "";
        }

        public string AppendSendMsg(string msg, string ipClient)
        {
            return GetDateNow() + "  " + "[发送" + ipClient + "]  " + msg + "\r\n\r\n";
        }

        public string AppendReceiveMsg(string msg, string ipClient)
        {
            return GetDateNow() + "  " + "[接收" + ipClient + "]  " + msg + "\r\n\r\n";
        }

        public string GetDateNow()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _sm.Stop();
        }
    }
}
