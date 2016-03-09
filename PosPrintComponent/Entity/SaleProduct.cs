using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PosPrintComponent.Entity
{
    /// <summary>
    /// 打折商品
    /// </summary>
    public class SaleProduct : ProductBase
    {
        /// <summary>
        /// 折扣率
        /// </summary>
        public double SaleRate { get; set; }

        /// <summary>
        /// 总价
        /// </summary>
        public override double TotalPrice
        {
            get
            {
                return base.TotalPrice * SaleRate;
            }
        }

        /// <summary>
        /// 节省金额
        /// </summary>
        /// <returns></returns>
        public override double GetSaveMoney()
        {
            return base.TotalPrice - this.TotalPrice;
        }

        /// <summary>
        /// 输出结果
        /// </summary>
        /// <returns></returns>
        public override string PrintResult()
        {
            return string.Format("名称：{0}, 数量:{1}{2}, 单价:{3}(元)，小计:{4}(元), 节省{5}(元)",
                Name, Number, Unit, UnitPrice, this.TotalPrice, GetSaveMoney());
        }
    }
}
