using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace PosPrintComponent.Tools
{
    /// <summary>
    /// Json 工具类
    /// </summary>
    public class JsonConvertHelper
    {
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="strJson">json串</param>
        /// <returns>对象</returns>
        public static T JsonDeserialize<T>(string strJson)
        {
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(strJson)))
            {

                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T));
                return (T)jsonSerializer.ReadObject(stream);
            }

        }

    }
}
