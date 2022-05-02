using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatFM.System
{
    /// <summary>
    /// 观察者模式
    /// </summary>
    public abstract class IObservable
    {
        private List<IObserver> observers = new List<IObserver>();

        public void Subscribe(IObserver observer)
        {
            observers.Add(observer);
        }

        public void UnSubscribe(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            int count = observers.Count;
            for(int i=0;i<count; i++)
            {
                observers[i].OnUpdate();
            }
        }
    }
}
