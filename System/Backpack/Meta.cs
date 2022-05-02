using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatFM.Backpack
{
    /// <summary>
    /// 所有元素的基类
    /// </summary>
    public class Meta
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Size { get; set; }
        public int OriginalPrice { get; set; }
        public int PresentPrice { get; set; }
        public string Sprite { get; set; }

        public Meta(int id, string name, string description, int size, int originalPrice, int presentPrice, string sprite)
        {
            this.ID = id;
            this.Name = name;
            this.Description = description;
            this.Size = size;
            this.OriginalPrice = originalPrice;
            this.PresentPrice = presentPrice;
            this.Sprite = sprite;
        }
    }
}
