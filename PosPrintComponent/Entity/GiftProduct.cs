using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PosPrintComponent.Entity
{
    /// <summary>
    /// 赠送商品
    /// </summary>
    public class GiftProduct:ProductBase
    {
        /// <summary>
        /// 赠送条件
        /// </summary>
        public int OverCondition { get; set; }

        /// <summary>
        /// 赠送个数
        /// </summary>
        public int GiveCondition { get; set; }

        /// <summary>
        /// 赠送总数
        /// </summary>
        public int GiveTotal 
        {
            get {
                try
                {
                    return (Number / OverCondition) * GiveCondition; 
                }
                catch(DivideByZeroException exp)
                {
                    return 0;
                }
                
            }
        }

        /// <summary>
        /// 获取节省金额
        /// </summary>
        /// <returns>节省金额</returns>
        public override double GetSaveMoney()
        {
            return this.GiveTotal * UnitPrice;
        }

        public override string PrintResult()
        {
            return string.Format("名称：{0}, 数量:{1}{2}, 单价:{3}(元)，小计:{4}(元)",
                Name, Number+GiveTotal, Unit, UnitPrice, this.TotalPrice);
        }
    }
}
