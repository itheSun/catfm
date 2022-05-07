using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace CatFM.Net
{
    public enum NetProto
    {
        Http,
        Tcp,
        //Tcp,
    }

    public class MsgSender : Singleton<MsgSender>
    {
        private static Queue<KeyValuePair<NetProto, byte[]>> waitQueue = new Queue<KeyValuePair<NetProto, byte[]>>();

        private bool isSendCompleted = true;

        public bool IsSendCompleted { get => isSendCompleted; private set => isSendCompleted = value; }

        public MsgSender()
        {
            GameLoop.AddUpdateListener(OnUpdate);
        }

        ~MsgSender()
        {
            GameLoop.RemoveUpdateListener(OnUpdate);
        }

        private void OnUpdate()
        {
            if (IsSendCompleted)
            {
                // Dictionary<NetProto, byte[]> msg = waitQueue.Dequeue();

                if (waitQueue.Count > 0)
                {

                    // HttpController.Instance.UnityRequest(msg);
                }
                // if (tcpQueue.Count > 0)
                // {
                //     TcpMsg msg = waitQueue.Dequeue();
                //     SendMsg<Msg>(msg);
                // }
                IsSendCompleted = false;
            }
        }

        /// <summary>
        /// 消息进队列
        /// </summary>
        /// <param name="netType"></param>
        /// <param name="msg"></param>
        public void Push<T>(NetProto netType, T msg)
        {
            switch (netType)
            {
                case NetProto.Http:
                    // byte[] buffer
                    // waitQueue.Enqueue();
                    break;
                case NetProto.Tcp:
                    // tcpQueue.Enqueue(msg as TcpMsg);
                    break;
            }
        }

        private void SendMsg<T>(T msg)
        {
            if (null == TCPNet.Instance.Socket)
            {
                return;
            }
            if (false == TCPNet.Instance.Socket.Connected)
            {
                return;
            }

            byte[] buffer = ProBufSerializer<T>.Serialize(msg);

            TCPNet.Instance.Socket.BeginSend(buffer, 0, Constant.SendBytesLength, SocketFlags.None, new
                AsyncCallback(SendCallBack), TCPNet.Instance.Socket);
        }

        private void SendCallBack(IAsyncResult ar)
        {
            try
            {
                TCPNet.Instance.Socket.EndSend(ar);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
            isSendCompleted = true;
        }
    }

}