using System;
using System.Collections;
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
    public class GameLoop : DntdMonoSingleton<GameLoop>
    {
        private event Action onUpdate;
        private event Action onFixedUpdate;
        private event Action onLateUpdate;

        private SceneStateController sceneStateController = new SceneStateController();

        private void Start()
        {
            this.sceneStateController.SetState(new IndexState(this.sceneStateController), "");
        }

        private void Update()
        {
            if (onUpdate != null) onUpdate();
            this.sceneStateController.StateUpdate();
        }

        private void FixedUpdate()
        {
            if (onFixedUpdate != null) onFixedUpdate();
        }

        private void LateUpdate()
        {
            if (onLateUpdate != null) onLateUpdate();
        }

        public void AddUpdateListener(Action action)
        {
            onUpdate += action;
        }
        public void AddFixedUpdateListener(Action action)
        {
            onFixedUpdate += action;
        }

        public void AddLateUpdateListener(Action action)
        {
            onLateUpdate += action;
        }

        public void RemoveUpdateListener(Action action)
        {
            onUpdate -= action;
        }

        public void RemoveFixedUpdateListener(Action action)
        {
            onFixedUpdate -= action;
        }

        public void RemoveLateUpdateListener(Action action)
        {
            onLateUpdate -= action;
        }

        public new Coroutine StartCoroutine(IEnumerator routine)
        {
            return base.StartCoroutine(routine);
        }

        public new void StopCoroutine(IEnumerator routine)
        {
            base.StopCoroutine(routine);
        }

        public new void StopAllCoroutines()
        {
            base.StopAllCoroutines();
        }
    }


}