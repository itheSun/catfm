//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Net;
//using System.Net.Sockets;
//using System.Text;
//using System.Threading;
//using UnityEngine;

//public interface IClient
//{
//    void CloseConnect();
//    void ReceiveMsg();
//    void SendMsg();
//}


//public class UDPNet : MonoSingleton<UDPNet>, IClient
//{
//    public Socket socket;

//    private IPEndPoint iPEndPoint;
//    private const int waitConnectTime = 5000;

//    public void Connect()
//    {

//        ConnectServer(AppConf.Host, AppConf.Port);
//    }

//    private IPEndPoint CreateEndPoint(string host, int port)
//    {

//        return iPEndPoint;
//    }

//    private void ConnectServer(string host, int port)
//    {
//        IPAddress ip = IPAddress.Parse(host);
//        IPEndPoint iPEndPoint = new IPEndPoint(ip, port);
//        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Udp);
//        if (socket == null)
//        {
//            return;
//        }
//        socket.BeginConnect(iPEndPoint, new AsyncCallback(ConnectCallBack), socket);
//    }

//    private void ConnectCallBack(IAsyncResult ar)
//    {
//        try
//        {
//            socket.EndConnect(ar);
//        }
//        catch (Exception e)
//        {
//            Debug.Log(e.Message);
//        }
//        bool response = socket.Connected;
//        if (response)
//        {
//            SuccessToConnect();
//        }
//        else
//        {
//            FailToConnect();
//        }
//    }

//    private void SuccessToConnect()
//    {
//        Debug.Log("connect successful");
//        MsgCenter.Call(MsgDefine.Net_Connect_Success);

//        Thread tReceiveMsg = new Thread(ReceiveMsg);
//        tReceiveMsg.Start();
//    }

//    private void FailToConnect()
//    {
//        Debug.Log("connect fail");
//        MsgCenter.Call(MsgDefine.Net_Connect_Failure);
//    }

//    public void ReceiveMsg()
//    {
//        if (socket == null)
//        {
//            return;
//        }
//        while (true)
//        {
//            if (!socket.Connected)
//            {
//                if (breakConnectAction != null) breakConnectAction();
//                break;
//            }
//            byte[] buffer = new byte[1024];
//            var len = socket.Receive(buffer);
//            if (len == 0)
//            {
//                break;
//            }
//            string str = Encoding.UTF8.GetString(buffer, 0, len);
//            if (receiveMsgAction != null)
//            {
//                receiveMsgAction(str);
//            }
//        }
//    }

//    public void CloseConnect()
//    {
//        if (socket == null)
//        {
//            return;
//        }
//        if (!socket.Connected)
//        {
//            return;
//        }
//        socket.Shutdown(SocketShutdown.Both);
//    }

//    public void SendMsg()
//    {
//        throw new NotImplementedException();
//    }
//}