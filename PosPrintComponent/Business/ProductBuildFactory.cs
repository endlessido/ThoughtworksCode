using PosPrintComponent.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PosPrintComponent.Business
{

    /// <summary>
    /// 商品创建工厂
    /// </summary>
    public class ProductBuildFactory
    {
        /// <summary>
        /// 创建商品信息
        /// </summary>
        /// <param name="ISBN">条形码</param>
        /// <param name="strategy">商品活动策略</param>
        /// <returns>商品基类</returns>
        public static ProductBase CreateProductInfo(string ISBN,ProductStrategy strategy)
        {
           if( strategy.Gitfs.Exists(m=>m.ISBNS.Contains(ISBN)) )
           {
              var gift = strategy.Gitfs.Single(m => m.ISBNS.Contains(ISBN));
              return new GiftProduct { ISBN = ISBN, OverCondition = gift.Over,  GiveCondition = gift.Give};    
           }
           else if (strategy.Sales.Exists(m => m.ISBNS.Contains(ISBN)))
           {
               var sale = strategy.Sales.Single(m => m.ISBNS.Contains(ISBN));
               return new SaleProduct { ISBN = ISBN, SaleRate = sale.Rate };
           }
           else if (ISBN.Contains('-'))
           {
               int number;
               if (int.TryParse(ISBN.Split('-')[1], out number))
               {
                   return new WeighingProduct { ISBN = ISBN.Split('-')[0], Number = number };
               }
           }
           return new ProductBase { ISBN = ISBN };
        }
    }
}
