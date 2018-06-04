using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Ticket.Infrastructure.Ctrip.Lib
{
    public class Helper
    {
        /// <summary>
        /// 反序列化XML字符串为指定类型
        /// </summary>
        public static object Deserialize(string Xml, Type ThisType)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(ThisType);
            object result;
            try
            {
                using (StringReader stringReader = new StringReader(Xml))
                {
                    result = xmlSerializer.Deserialize(stringReader);
                }
            }
            catch (Exception innerException)
            {
                bool flag = false;
                if (Xml != null)
                {
                    if (Xml.StartsWith(Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble())))
                    {
                        flag = true;
                    }
                }
                throw new ApplicationException(string.Format("Couldn't parse XML: '{0}'; Contains BOM: {1}; Type: {2}.",
                Xml, flag, ThisType.FullName), innerException);
            }
            return result;
        }

        /// <summary>
        /// 将自定义对象序列化为XML字符串
        /// </summary>
        /// <param name="myObject">自定义对象实体</param>
        /// <returns>序列化后的XML字符串</returns>
        public static string SerializeToXml<T>(T myObject)
        {
            if (myObject != null)
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));

                MemoryStream stream = new MemoryStream();
                XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8);
                writer.Formatting = Formatting.None;//缩进
                xs.Serialize(writer, myObject);

                stream.Position = 0;
                StringBuilder sb = new StringBuilder();
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        sb.Append(line);
                    }
                    reader.Close();
                }
                writer.Close();
                return sb.ToString();
            }
            return string.Empty;
        }

        /// <summary>
        /// 生成签名，详见签名生成算法
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="serviceName"></param>
        /// <param name="requestTime"></param>
        /// <param name="data"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        public static string MakeSign(string accountId, string serviceName, string requestTime, string data, string version)
        {
            string str = accountId + serviceName + requestTime + data + version + CtripConfig.Key;
            //MD5加密
            var md5 = MD5.Create();
            var bs = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            var sb = new StringBuilder();
            foreach (byte b in bs)
            {
                sb.Append(b.ToString("x2"));
            }
            //所有字符转为大写
            return sb.ToString().ToLower();
        }


        /// <summary>
        /// Base64加密，采用utf8编码方式加密
        /// </summary>
        /// <param name="source">待加密的明文</param>
        /// <returns>加密后的字符串</returns>
        public static string Base64Encode(string source)
        {
            return Base64Encode(Encoding.UTF8, source);
        }

        /// <summary>  
        /// 截取字符串中指定标签内的内容  
        /// </summary>  
        /// <param name="Content">需要截取的字符串</param>  
        /// <param name="start">开始标签</param>  
        /// <param name="end">结束标签</param>  
        /// <returns></returns>  
        public static string GetBodyStr(string Content, string start = "<body>", string end = "</body>")
        {
            var posStart = Content.IndexOf(start);
            var posEnd = Content.IndexOf(end);
            return Content.Substring(posStart, (posEnd - posStart + end.Length));
        }

        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="encodeType">加密采用的编码方式</param>
        /// <param name="source">待加密的明文</param>
        /// <returns></returns>
        public static string Base64Encode(Encoding encodeType, string source)
        {
            string encode = string.Empty;
            byte[] bytes = encodeType.GetBytes(source);
            try
            {
                encode = Convert.ToBase64String(bytes);
            }
            catch
            {
                encode = source;
            }
            return encode;
        }
    }
}
