using PosPrintComponent.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PosPrintComponent.Business
{
    /// <summary>
    /// 商品比较器 重写Equals方法 按照商品的条形码来判断是否为同一个商品
    /// </summary>
    public class ProductComparer : IEqualityComparer<ProductBase>
    {
        public bool Equals(ProductBase x, ProductBase y)
        {
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;
            if (Object.ReferenceEquals(x, y))
                return true;
            return x.ISBN.Equals(y.ISBN);
        }

        public int GetHashCode(ProductBase obj)
        {
            if (Object.ReferenceEquals(obj, null)) return 0;
            return obj.ISBN == null ? 0 : obj.ISBN.GetHashCode();
        }
    }
}
