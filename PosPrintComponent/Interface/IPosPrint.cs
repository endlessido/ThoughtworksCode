using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PosPrintComponent.Interface
{
    /// <summary>
    /// 打印接口
    /// </summary>
    public interface IPosPrint
    {
        void PrintResult(string strJsonProducts);
    }
}
