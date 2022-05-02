using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatFM.Backpack
{
    public class Inventory : Singleton<Inventory>
    {
        private Dictionary<ItemType, Dictionary<int, Item>> slotMap = new Dictionary<ItemType, Dictionary<int, Item>>();

        public int Capacity { get; private set; }

        public void Init()
        {

        }

        public void Expend(int size)
        {
            this.Capacity += size;
        }

        public void Store<T>(T item) where T : Item
        {
            if (!slotMap.ContainsKey(item.ItemType)) { return; }
            if (!slotMap[item.ItemType].ContainsKey(item.Meta.ID))
            {
                slotMap[item.ItemType].Add(item.Meta.ID, item);
            }
            slotMap[item.ItemType][item.Meta.ID].Store(item.Amount);
        }

        public bool Consume<T>(T item) where T : Item
        {
            if (!slotMap.ContainsKey(item.ItemType)) { return false; }
            if (!slotMap[item.ItemType].ContainsKey(item.Meta.ID)) { return false; }
            if (!slotMap[item.ItemType][item.Meta.ID].Consume(item.Amount)) return false;
            return true;
        }
    }
}
