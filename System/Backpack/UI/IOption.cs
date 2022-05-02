using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace CatFM
{
    /// <summary>
    /// 按钮
    /// </summary>
    [Serializable]
    public class IOption
    {
        [SerializeField]
        public string name;
        [SerializeField]
        public Sprite sprite;
    }
}
