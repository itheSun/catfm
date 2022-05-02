using System;
using System.IO;
using System.Text;
using ProtoBuf;

namespace CatFM.Net
{
    public class ProBufSerializer<T>
    {
        private ProBufSerializer() { }

        /// <summary>
        /// 序列化对象得到字节
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] Serialize(T obj)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    Serializer.Serialize<T>(ms, obj);
                    byte[] buffer = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(buffer, 0, buffer.Length);
                    return buffer;
                }
            }
            catch (Exception e)
            {
                Bug.Throw(e.ToString());
                return null;
            }
        }

        /// <summary>
        /// 序列化对象得到字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeToString(T obj)
        {
            byte[] buffer = Serialize(obj);
            return Encoding.UTF8.GetString(buffer);
        }

        /// <summary>
        /// 反序列化字节得到对象
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static T Deserialize(byte[] msg)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Write(msg, 0, msg.Length);
                    ms.Position = 0;
                    T res = Serializer.Deserialize<T>(ms);
                    return res;
                }
            }
            catch (Exception e)
            {
                Bug.Throw(e.ToString());
                return default(T);
            }
        }

        /// <summary>
        /// 反序列化字符串得到
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T DeserializeFromString(string str)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(str);
            return Deserialize(buffer);
        }
    }

}
