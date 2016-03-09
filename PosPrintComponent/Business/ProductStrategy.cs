using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PosPrintComponent.Business
{
    /// <summary>
    /// 商品策略配置信息
    /// </summary>
    public class ProductStrategy
    {
        public ProductStrategy()
        {
            Gitfs = new List<Gift>();
            Sales = new List<Sale>();
        }
        public List<Gift> Gitfs{get;set;}
        public List<Sale> Sales {get;set;}
    }

    /// <summary>
    /// 赠送策略
    /// </summary>
    public class Gift
    {
        public int Over{get;set;}
        public int Give {get;set;}
        public string ISBNS {get;set;}
    }
    
    /// <summary>
    /// 打折策略
    /// </summary>
    public class Sale
    {
        public double Rate { get; set; }
        public string ISBNS { get; set; }
    }
}
