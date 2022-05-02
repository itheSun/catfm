using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CatFM
{
    public class BaseView : MonoBehaviour
    {
        /// <summary>
        /// 是否可见
        /// </summary>
        private bool visible;
        /// <summary>
        /// 
        /// </summary>
        private bool interactive;

        public bool Visible { get => this.visible; protected set => this.visible = value; }
        public bool Interactive { get => this.interactive; protected set => this.interactive = value; }

        /// <summary>
        /// 显示面板
        /// </summary>
        public virtual void OnShow()
        {
            this.visible = true;
            this.gameObject.SetActive(true);
        }

        /// <summary>
        /// 显示面板
        /// </summary>
        public virtual void OnShow(Transform parent)
        {
            this.visible = true;
            this.gameObject.transform.parent = parent;
            this.gameObject.SetActive(true);
        }

        /// <summary>
        /// 隐藏面板
        /// </summary>
        public virtual void OnHide()
        {
            this.visible = false;
            this.gameObject.SetActive(false);
        }

        /// <summary>
        /// 激活面板
        /// </summary>
        public virtual void OnActive()
        {
            this.interactive = false;
            this.gameObject.SetActive(true);
        }

        /// <summary>
        /// 冻结面板
        /// </summary>
        public virtual void OnBlock()
        {
            this.interactive = false;
            this.gameObject.SetActive(true);
        }
    }

}