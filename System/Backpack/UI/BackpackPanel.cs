using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CatFM;
using UnityEngine.UI;

namespace CatFM.Backpack
{
    /// <summary>
    /// ����ϵͳUI
    /// </summary>
    public class BackpackPanel : BaseView
    {
        [SerializeField]
        private Image background;
        /// <summary>
        /// Ԫ�ز��б�
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
        /// ѡ��ĳ��Ԫ�ز�
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

