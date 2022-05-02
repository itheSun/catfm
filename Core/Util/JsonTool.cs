﻿using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace CatFM
{
    public class JsonTool
    {
        private string filePath;

        private string data;
        public string Data { get => data; }


        public JsonTool(string path)
        {
            if (!File.Exists(path))
                Bug.Throw(string.Format("file path {0} is not exist", path));
            this.filePath = path;
            using (StreamReader streamReader = new StreamReader(filePath, Encoding.UTF8))
            {
                this.data = streamReader.ReadToEnd();
            }
        }

        /// <summary>
        /// 写入json
        /// </summary>
        /// <param name="json"></param>
        /// <param name="pos"></param>
        public void Write(string json, int pos = 0)
        {
            if (!File.Exists(this.filePath))
                return;
            using (FileStream fileStream = new FileStream(this.filePath, FileMode.Open, FileAccess.Write))
            {
                fileStream.Position = pos;
                byte[] bytes = Encoding.Default.GetBytes(json);
                fileStream.Write(bytes, 0, bytes.Length);
            }
        }


        public static Dictionary<T1, T2> ToMap<T1, T2>(string jsonText)
        {
            Dictionary<T1, T2> map = JsonConvert.DeserializeObject<Dictionary<T1, T2>>(jsonText);
            return map;
        }

        public static string ToJson<T1, T2>(Dictionary<T1, T2> keyMap)
        {
            string json = JsonConvert.SerializeObject(keyMap);
            return json;
        }
    }


}