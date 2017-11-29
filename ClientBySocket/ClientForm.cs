﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientBySocket
{
    public partial class ClientForm : Form
    {
        SocketClientManager _scm = null;
        string ip = "192.168.1.8";
        int port = 1113;

        public ClientForm()
        {
            InitializeComponent();
            //GetLocalIp();
            ip = GetLocalIp();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitSocket();
        }

        public void OnReceiveMsg()
        {
            byte[] buffer = _scm.socketInfo.buffer;
            string msg = Encoding.ASCII.GetString(buffer).Replace("\0", "");
            if (string.Empty.Equals(msg)) return;
            if (txtMsg.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    txtMsg.Text += AppendReceiveMsg(msg);
                }));
            }
            else
            {
                txtMsg.Text += AppendReceiveMsg(msg);
            }
        }

        public void OnConnected()
        {
            if (txtMsg.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    txtMsg.Text += GetDateNow() + "  " + "连接服务器" + ip + " : " + port + "成功\r\n";
                    string ipClient = _scm._socket.LocalEndPoint.ToString().Split(':')[0];
                    string posrClient = _scm._socket.LocalEndPoint.ToString().Split(':')[1];
                    lblClientIps.Text = ipClient;
                    lblClientPorts.Text = posrClient;
                    lblRemoteIps.Text = ip;
                    lblRemotePorts.Text = port.ToString();
                    lblStatuss.Text = "正常";
                }));
            }
            else
            {
                txtMsg.Text += GetDateNow() + "  " + "连接服务器" + ip + " : " + port + "成功\r\n";
            }
        }

        public void OnFaildConnect()
        {
            if (txtMsg.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    txtMsg.Text += GetDateNow() + "  " + "连接服务器" + ip + " : " + port + " 失败\r\n";
                    lblStatuss.Text = "连接失败";
                }));
            }
            else
            {
                txtMsg.Text += GetDateNow() + "  " + "连接服务器" + ip + " : " + port + " 成功\r\n";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _scm.SendMsg(txtSend.Text);
            txtMsg.Text += AppendSendMsg(txtSend.Text);
            txtSend.Text = "";
        }

        public string AppendSendMsg(string msg)
        {
            return GetDateNow() + "  " + "[发送]  " + msg + "\r\n";
        }

        public string AppendReceiveMsg(string msg)
        {
            return GetDateNow() + "  " + "[接收]  " + msg + "\r\n";
        }

        public string GetDateNow()
        {
            return DateTime.Now.ToString("HH:mm:ss");
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
        private void InitSocket()
        {
            _scm = new SocketClientManager(ip, port);
            _scm.OnReceiveMsg += OnReceiveMsg;
            _scm.OnConnected += OnConnected;
            _scm.OnFaildConnect += OnFaildConnect;
            _scm.Start();
        }

        private void btnConnected_Click(object sender, EventArgs e)
        {
            InitSocket();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (!_scm._socket.Connected) return;
            _scm._isConnected = false;
            _scm.SendMsg("\0\0\0faild");
            _scm._socket.Shutdown(System.Net.Sockets.SocketShutdown.Both);
            _scm._socket.Close();
            lblClientIps.Text = "";
            lblClientPorts.Text = "";
            lblRemoteIps.Text = "";
            lblRemotePorts.Text = "";
            lblStatuss.Text = "未连接";
            txtMsg.Text += "连接已经断开\r\n";
        }

        private void buttonsend_Click(object sender, EventArgs e)
        {
            int i = _scm.SendFile(txtFileName.Text, 512, 1);
            if (i == 0)
            {
                MessageBox.Show(txtFileName.Text + "文件发送成功");
                //socketClient.Close(); 
            }
            else
            {
                MessageBox.Show(txtFileName.Text + "文件发送失败,i=" + i);
            }
        }

        private void buttonchoice_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtFileName.Text = ofd.FileName;
            }
        }
    }
}
