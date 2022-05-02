using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using CatFM.System;

namespace CatFM.Backpack
{
    public enum ItemType
    {

    }

    public class Item : IObservable
    {
        public ItemType ItemType { get; set; }
        public Meta Meta { get; set; }
        public GameObject Pref { get; set; }
        public int Amount { get; set; }

        public Item(Meta meta, GameObject pref, int amount)
        {
            this.Meta = meta;
            this.Pref = pref;
            this.Amount = amount;
        }

        public void Store(int count)
        {
            this.Amount += count;
            Notify();
        }

        public bool Consume(int count)
        {
            if (this.Amount - count > 0)
            {
                this.Amount -= count;
                Notify();
                return true;
            }
            return false;
        }
    }
}
