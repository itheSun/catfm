using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Internal;

namespace CatFM
{
    /// <summary>
    /// MonoBehaviour事件控制器单例
    /// 提供Update、LateUpdate、FixedUpdate、协程接口
    /// </summary>
    public static class MonoController
    {
        private static MonoListener monoEvent = MonoListener.Instance;

        public static void AddUpdateListener(Action action)
        {
            monoEvent.AddUpdateListener(action);
        }

        public static void RemoveUpdateListener(Action action)
        {
            monoEvent.RemoveUpdateListener(action);
        }

        public static void AddFixedUpdateListener(Action action)
        {
            monoEvent.AddFixedUpdateListener(action);
        }

        public static void RemoveFixedUpdateListener(Action action)
        {
            monoEvent.RemoveFixedUpdateListener(action);
        }

        public static void AddLateUpdateListener(Action action)
        {
            monoEvent.AddLateUpdateListener(action);
        }

        public static void RemoveLateUpdateListener(Action action)
        {
            monoEvent.RemoveLateUpdateListener(action);
        }

        public static Coroutine StartCoroutine(string methodName)
        {
            return monoEvent.StartCoroutine(methodName);
        }

        public static Coroutine StartCoroutine(IEnumerator routine)
        {
            return monoEvent.StartCoroutine(routine);

        }

        public static Coroutine StartCoroutine(string methodName, [DefaultValue("null")] object value)
        {
            return monoEvent.StartCoroutine(methodName, value);
        }

        public static void StopAllCoroutines()
        {
            monoEvent.StopAllCoroutines();
        }

        public static void StopCoroutine(string methodName)
        {
            monoEvent.StopCoroutine(methodName);
        }

        public static void StopCoroutine(IEnumerator routine)
        {
            monoEvent.StartCoroutine(routine);
        }

        public static void StopCoroutine(Coroutine routine)
        {
            monoEvent.StopCoroutine(routine);
        }

    }


}