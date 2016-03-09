using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

namespace PosPrintComponent.Tools
{
    /// <summary>
    /// XML工具类
    /// </summary>
    public class XMLHelper
    {
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="resourcePath">资源路径</param>
        /// <returns>对象</returns>
        public static T Deserialize<T>(string resourcePath)
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcePath);
            XmlSerializer xmlSerialize = new XmlSerializer(typeof(T));
            return (T)xmlSerialize.Deserialize(stream);
        }
    }
}
