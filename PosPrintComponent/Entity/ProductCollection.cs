using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PosPrintComponent.Entity
{
    /// <summary>
    /// 商品集合
    /// </summary>
    public class ProductCollection
    {
        public ProductCollection()
        {
            Products = new List<ProductBase>();
        }

        public List<ProductBase> Products { get; set; }
    }
}
