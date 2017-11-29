using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientBySocket
{
    public class SocketClientManager
    {
        public Socket _socket = null;
        public EndPoint endPoint = null;
        public SocketInfo socketInfo = null;
        public bool _isConnected = false;

        //public delegate void OnConnectedHandler();
        public event Action OnConnected;
        public event Action OnFaildConnect;
        //public delegate void OnReceiveMsgHandler();
        public event Action OnReceiveMsg;

        public SocketClientManager(string ip, int port)
        {
            IPAddress _ip = IPAddress.Parse(ip);
            endPoint = new IPEndPoint(_ip, port);
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Start()
        {
            _socket.BeginConnect(endPoint, ConnectedCallback, _socket);
            _isConnected = true;
            Thread socketClient = new Thread(SocketClientReceive);
            socketClient.IsBackground = true;
            socketClient.Start();
        }

        public void SocketClientReceive()
        {
            while (_isConnected)
            {
                SocketInfo info = new SocketInfo();
                try
                {
                    _socket.BeginReceive(info.buffer, 0, info.buffer.Length, SocketFlags.None, ReceiveCallback, info);
                }
                catch (SocketException ex)
                {
                    _isConnected = false;
                }

                Thread.Sleep(100);
            }
        }

        public void ReceiveCallback(IAsyncResult ar)
        {
            socketInfo = ar.AsyncState as SocketInfo;
            if (this.OnReceiveMsg != null) OnReceiveMsg();
        }

        public void ConnectedCallback(IAsyncResult ar)
        {
            Socket socket = ar.AsyncState as Socket;
            if (socket.Connected)
            {
                if (this.OnConnected != null) OnConnected();
            }
            else
            {
                if (this.OnFaildConnect != null) OnFaildConnect();
            }
        }

        public void SendMsg(string msg)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(msg);
            _socket.Send(buffer);
        }

        public class SocketInfo
        {
            public Socket socket = null;
            public byte[] buffer = null;

            public SocketInfo()
            {
                buffer = new byte[1024 * 4];
            }
        }


        public int SendFile(string fileName, int maxBufferLength, int outTime)
        {
            if (fileName == null || maxBufferLength <= 0)
            {
                throw new ArgumentException("待发送的文件名称为空或发送缓冲区的大小设置不正确.");
            }
            int flag = 0;
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                long fileLen = fs.Length;                        // 文件长度
                long leftLen = fileLen;                            // 未读取部分
                int readLen = 0;                                // 已读取部分
                byte[] buffer = null;

                if (fileLen <= maxBufferLength)
                {            /* 文件可以一次读取*/
                    buffer = new byte[fileLen];
                    readLen = fs.Read(buffer, 0, (int)fileLen);
                    flag = SendData(_socket, buffer, outTime);
                }
                else
                {
                    /* 循环读取文件,并发送 */

                    while (leftLen != 0)
                    {
                        if (leftLen < maxBufferLength)
                        {
                            buffer = new byte[leftLen];
                            readLen = fs.Read(buffer, 0, Convert.ToInt32(leftLen));
                        }
                        else
                        {
                            buffer = new byte[maxBufferLength];
                            readLen = fs.Read(buffer, 0, maxBufferLength);
                        }
                        if ((flag = SendData(_socket, buffer, outTime)) < 0)
                        {
                            break;
                        }
                        leftLen -= readLen;
                    }
                }
                fs.Flush();
                fs.Close();
            }
            catch (IOException e)
            {
                flag = -4;
            }
            return flag;
        }

        private int SendData(Socket socket, byte[] buffer, int outTime)
        {
            if (socket == null || socket.Connected == false)
            {
                throw new ArgumentException("参数socket 为null，或者未连接到远程计算机");
            }
            if (buffer == null || buffer.Length == 0)
            {
                throw new ArgumentException("参数buffer 为null ,或者长度为 0");
            }

            int flag = 0;
            try
            {
                int left = buffer.Length;
                int sndLen = 0;

                while (true)
                {
                    if ((socket.Poll(outTime * 100, SelectMode.SelectWrite) == true))
                    {        // 收集了足够多的传出数据后开始发送
                        sndLen = socket.Send(buffer, sndLen, left, SocketFlags.None);
                        left -= sndLen;
                        if (left == 0)
                        {                                        // 数据已经全部发送
                            flag = 0;
                            break;
                        }
                        else
                        {
                            if (sndLen > 0)
                            {                                    // 数据部分已经被发送
                                continue;
                            }
                            else
                            {                                                // 发送数据发生错误
                                flag = -2;
                                break;
                            }
                        }
                    }
                    else
                    {                                                        // 超时退出
                        flag = -1;
                        break;
                    }
                }
            }
            catch (SocketException e)
            {

                flag = -3;
            }
            return flag;
        }
    }
}
