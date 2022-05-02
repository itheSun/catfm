using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;


namespace CatFM
{
    /// <summary>
    /// MonoBehaviour事件监听器
    /// 监听Update、LateUpdate、FixedUpdate事件
    /// </summary>
    public class MonoListener : DntdMonoSingleton<MonoListener>
    {
        private event Action update;
        private event Action fixedUpdate;
        private event Action lateUpdate;

        private void Update()
        {
            if (update != null) update();
        }

        private void FixedUpdate()
        {
            if (fixedUpdate != null) fixedUpdate();
        }

        private void LateUpdate()
        {
            if (lateUpdate != null) lateUpdate();
        }

        public void AddUpdateListener(Action action)
        {
            update += action;
        }

        public void RemoveUpdateListener(Action action)
        {
            update -= action;
        }

        public void AddFixedUpdateListener(Action action)
        {
            fixedUpdate += action;
        }

        public void RemoveFixedUpdateListener(Action action)
        {
            fixedUpdate -= action;
        }

        public void AddLateUpdateListener(Action action)
        {
            lateUpdate += action;
        }

        public void RemoveLateUpdateListener(Action action)
        {
            lateUpdate -= action;
        }
    }


}