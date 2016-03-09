using PosPrintComponent.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;
using PosPrintComponent.Tools;

namespace PosPrintComponent.Business
{
    /// <summary>
    /// 商品业务类
    /// </summary>
    public class ProductsBusiness
    {
        private const string PRODUCT_DICTIONARY_XMLPATH = "PosPrintComponent.ProductDictionary.xml";
        private const string STRATEGY_XMLPATH = "PosPrintComponent.ProductStrategy.xml";

        public ProductsBusiness()
        {
            this.ProductCollection = new ProductCollection();
            this.ProductStrategy = new ProductStrategy();
            InitStrategy();
        }

        public ProductCollection ProductCollection { get; set; }

        private ProductStrategy ProductStrategy { get; set; }

        /// <summary>
        /// 反序列化商品信息
        /// </summary>
        /// <returns>是否成功</returns>
        protected virtual bool DeserializeProduct()
        {
            try
            {
                var productDictionary = XMLHelper.Deserialize<ProductCollection>(PRODUCT_DICTIONARY_XMLPATH);
                foreach (var item in ProductCollection.Products)
                {
                    var xmlProduct = productDictionary.Products.Where(m => m.ISBN.Equals(item.ISBN)).SingleOrDefault();
                    item.Name = xmlProduct.Name;
                    item.Unit = xmlProduct.Unit;
                    item.UnitPrice = xmlProduct.UnitPrice;
                }
                return true;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message+" 请检查XML配置文件");
                return false;
            }
            
        }

        /// <summary>
        /// 初始化商品策略
        /// </summary>
        protected virtual void InitStrategy()
        {
            try
            {
                this.ProductStrategy = XMLHelper.Deserialize<ProductStrategy>(STRATEGY_XMLPATH);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// 获取总计
        /// </summary>
        /// <returns>总计金额</returns>
        public double GetTotalPrice()
        {
            return ProductCollection.Products.Sum(m => m.TotalPrice);
        }

        /// <summary>
        /// 构造商品对象
        /// </summary>
        /// <param name="ISBNArray">条形码数组</param>
        public bool BuildProductInfo(string[] ISBNArray)
        {
            try
            {
                foreach (var ISBN in ISBNArray)
                {
                    this.ProductCollection.Products.Add(ProductBuildFactory.CreateProductInfo(ISBN, this.ProductStrategy));
                }

                if (!DeserializeProduct()) return false; 

                foreach (var item in ProductCollection.Products)
                {
                    if (!(item is WeighingProduct))
                    {
                        item.Number = ProductCollection.Products.Count(m => m.ISBN.Equals(item.ISBN));
                    }
                }
                this.ProductCollection.Products = this.ProductCollection.Products.Distinct(new ProductComparer()).ToList();
                return true;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
                return false;
            }
        }

        public bool CheckData(string[] ISBNArray)
        {
            foreach (var item in ISBNArray)
            {
                if (!item.StartsWith("ITEM"))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 打印小票结果
        /// </summary>
        /// <param name="ISBNArray">条形码数组</param>
        public virtual void PrintResult(string[] ISBNArray)
        {
            if (!CheckData(ISBNArray))
            {
                Console.WriteLine("数据格式不正确，请检查");
                return;
            }
            
            if (!BuildProductInfo(ISBNArray)) return;
            Console.WriteLine("***<没钱赚小店>购物清单***");
            double saveMoney = 0; 
            List<GiftProduct> giftProducts = new List<GiftProduct>();

            /* 循环计算是否存在赠送商品 */
            foreach (var item in ProductCollection.Products)
            {
                Console.WriteLine(item.PrintResult());
                if (item is GiftProduct)
                {
                    giftProducts.Add((GiftProduct)item);
                }
                saveMoney += item.GetSaveMoney();
            }

            /* 如果存在赠送商品输出打印结果 */
            if (giftProducts.Count > 0)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine("买二赠一商品：");
                foreach (var item in giftProducts)
                {
                    Console.WriteLine(string.Format("名称：{0}, 数量{1}{2}",item.Name,item.GiveTotal,item.Unit));
                }
            }
            Console.WriteLine("--------------");
            Console.WriteLine(string.Format("总计：{0}元", GetTotalPrice()));

            /* 输出节省金额 */
            if(saveMoney >0)
            {
                Console.WriteLine(string.Format("节省：{0}元", saveMoney)); 
            } 
            Console.WriteLine("**************");
        }
    }

  

}
