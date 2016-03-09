using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PosPrintComponent.Entity
{
    /// <summary>
    /// 商品基类
    /// </summary>
    public class ProductBase
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 购买总数
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public double UnitPrice { get; set; }
        /// <summary>
        /// 条形码
        /// </summary>
        public string ISBN { get; set; }

        /// <summary>
        /// 总金额
        /// </summary>
        public virtual double TotalPrice
        {
            get { return UnitPrice * Number; }
        }

        /// <summary>
        /// 获取节省金额
        /// </summary>
        /// <returns></returns>
        public virtual double GetSaveMoney()
        {
            return 0;
        }

        /// <summary>
        /// 输出结果
        /// </summary>
        /// <returns></returns>
        public virtual string PrintResult()
        {
            return string.Format("名称：{0}, 数量:{1}{2}, 单价:{3}(元)，小计:{4}(元)", 
                Name, Number, Unit, UnitPrice, TotalPrice);
        }
    }
}
