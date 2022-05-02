using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using CatFM.System;

namespace CatFM.Backpack
{
    /// <summary>
    /// 背包系统UI元素槽
    /// </summary>
    public class Slot : MonoBehaviour, IObserver
    {
        public Action<Item> onSelected;

        public Item Item { get; private set; }
        public bool IsEmpty { get; private set; }

        private Button slotBtn;
        private Text itemName;
        private Image itemImage;
        private Text itemAmount;

        private void Awake()
        {
            this.IsEmpty = true;

            this.slotBtn = GetComponent<Button>();
            this.itemName = transform.Find("ItemName").GetComponent<Text>();
            this.itemImage = transform.Find("ItemImage").GetComponent<Image>();
            this.itemAmount = transform.Find("ItemAmount").GetComponent<Text>();

            this.slotBtn.onClick.AddListener(() => { if (this.Item != null) onSelected.Invoke(this.Item); });
        }

        /// <summary>
        /// 填充物品
        /// </summary>
        /// <param name="item"></param>
        /// <param name="amount"></param>
        public void OnFill(Item item)
        {
            this.Item = item;
            this.itemName.text = item.Meta.Name;
            this.itemImage.sprite = ResMgr.Instance.Load<Sprite>(item.Meta.Sprite);
            this.itemAmount.text = item.Amount.ToString();
            this.IsEmpty = false;
            this.Item.Subscribe(this);
        }

        /// <summary>
        /// 更新物品数量
        /// </summary>
        /// <param name="count"></param>
        public void OnUpdate()
        {
            this.itemAmount.text = this.Item.Amount.ToString();
        }

        public void OnRemove()
        {
            if (this.Item != null) { this.Item = null; }
            this.IsEmpty = true;
            this.Item.UnSubscribe(this);
        }
    }
}
