using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CatFM.Net
{
    public class TCPNet : Singleton<TCPNet>
    {
        /// <summary>
        /// 本机套接字
        /// </summary>
        private Socket socket;
        /// <summary>
        /// 服务器主机ip
        /// </summary>
        private string host;
        /// <summary>
        /// 服务器端口号
        /// </summary>
        private int port;

        public Socket Socket { get => socket; }
        public string Host { get => host; }
        public int Port { get => port; }

        /// <summary>
        /// 连接服务器接口
        /// </summary>
        public void Connect()
        {
            this.host = Constant.Login_Host_Url;
            this.port = Constant.Port;
            ConnectToServer(Host, port);
        }

        /// <summary>
        /// 创建Socket，开始连接
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        private void ConnectToServer(string host, int port)
        {
            try
            {
                IPAddress ip = IPAddress.Parse(host);
                IPEndPoint iPEndPoint = new IPEndPoint(ip, port);
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.BeginConnect(iPEndPoint, new AsyncCallback(ConnectCallBack), socket);
            }
            catch (Exception ex)
            {
                Bug.Throw(ex.Message);
            }
        }

        /// <summary>
        /// 异步连接回调
        /// </summary>
        /// <param name="ar"></param>
        private void ConnectCallBack(IAsyncResult ar)
        {
            try
            {
                socket.EndConnect(ar);
            }
            catch (Exception e)
            {
                Bug.Throw(e.Message);
            }
            bool response = socket.Connected;
            if (response)
            {
                SuccessToConnect();
            }
            else
            {
                FailToConnect();
            }
        }

        /// <summary>
        /// 连接成功回调
        /// </summary>
        private void SuccessToConnect()
        {
            Bug.Log("connect successful");
            Thread tReceiveMsg = new Thread(ReceiveMsg);
            tReceiveMsg.Start();
        }

        /// <summary>
        /// 连接失败回调
        /// </summary>
        private void FailToConnect()
        {
            Bug.Log("connect fail");
        }

        /// <summary>
        /// 接收消息
        /// </summary>
        public void ReceiveMsg()
        {
            if (socket == null)
            {
                return;
            }
            while (true)
            {
                if (!socket.Connected)
                {
                    break;
                }
                byte[] buffer = new byte[1024];
                var len = socket.Receive(buffer);
                if (len == 0)
                {
                    break;
                }
                string str = Encoding.UTF8.GetString(buffer, 0, len);
                //if (receiveMsgAction != null)
                //{
                //    receiveMsgAction(str);
                //}
            }
        }

        /// <summary>
        /// 断开连接
        /// </summary>
        public void CloseConnect()
        {
            if (socket == null)
            {
                return;
            }
            if (!socket.Connected)
            {
                return;
            }
            socket.Shutdown(SocketShutdown.Both);
        }
    }
}