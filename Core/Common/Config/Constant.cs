using System.Net.Mime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace CatFM
{
    /// <summary>
    /// 游戏配置
    /// </summary>
    public static class Constant
    {
        /// <summary>
        /// Input Manager Axes
        /// </summary>
        public static string Input_Horizontal = "Horizontal";
        public static string Input_Vertical = "Vertical";
        public static string Input_Mouse_X = "Mouse X";
        public static string Input_Mouse_Y = "Mouse Y";
        public static string Input_Jump = "Space";
        public static int Input_Mouse_Left;
        public static int Input_Mouse_Right;
        public static string Path_Res_Bgm;
        public static int SceneID_Loading;
        public static string Path_Res_Panels;
        public static string NextVersion;

        /// <summary>
        /// Layer
        /// </summary>
        public static readonly string Layer_Player = "Player";
        public static readonly string Layer_Ground = "Ground";


        /// <summary>
        /// net
        /// </summary>
        public static readonly string Login_Host_Url = "127.0.0.1";
        public static readonly int Port = 8000;
        public const int MaxReceiveBufferSize = 100;
        public const int MaxSendBufferSize = 100;
        public const int ReceiveBytesLength = 100;
        public const int SendBytesLength = 100;


    }

}