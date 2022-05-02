using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CatFM;
using UnityEngine.UI;

namespace CatFM.Backpack
{
    /// <summary>
    /// 背包系统UI
    /// </summary>
    public class BackpackPanel : BaseView
    {
        [SerializeField]
        private Image background;
        /// <summary>
        /// 元素槽列表
        /// </summary>
        private Slot[] slots;

        // Start is called before the first frame update
        void Awake()
        {
            background = transform.Find("Background").GetComponent<Image>();

            this.slots = transform.Find("Slots").GetComponentsInChildren<Slot>();
            int slotLen = this.slots.Length;
            for(int i = 0; i < slotLen; i++)
            {
                this.slots[i].onSelected += OnSelectedSlot;
            }
        }

        private void OnDestroy()
        {
            int slotLen = this.slots.Length;
            for (int i = 0; i < slotLen; i++)
            {
                this.slots[i].onSelected -= OnSelectedSlot;
            }
        }

        /// <summary>
        /// 选中某个元素槽
        /// </summary>
        /// <param name="slot"></param>
        private void OnSelectedSlot(Item item)
        {

        }

        public void OnStore(Item item)
        {

        }
    }

}

