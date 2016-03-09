using PosPrintComponent.Business;
using PosPrintComponent.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PosPrintComponent.Interface
{
    /// <summary>
    /// 打印接口实现
    /// </summary>
    public class PosPrintImplement : IPosPrint
    {
        public void PrintResult(string strJsonProducts)
        {
            var products = JsonConvertHelper.JsonDeserialize<string[]>(strJsonProducts);
            ProductsBusiness service = new ProductsBusiness();
            service.PrintResult(products);
        }
    }
}
