using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Ticket.Infrastructure.KouDaiLingQian.Request;

namespace Ticket.Infrastructure.KouDaiLingQian.Lib
{
    public class Helper
    {
        /// <summary>
        /// 生成签名，详见签名生成算法
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string MakeSign(string data, string key)
        {
            string str = data + "&key=" + key;
            //MD5加密
            var md5 = MD5.Create();
            var bs = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            var sb = new StringBuilder();
            foreach (byte b in bs)
            {
                sb.Append(b.ToString("x2"));
            }
            //所有字符转为小写
            return sb.ToString().ToUpper();
        }

        /// <summary>
        /// Base64加密，采用utf8编码方式加密
        /// </summary>
        /// <param name="source">待加密的明文</param>
        /// <returns></returns>
        public static string Base64Encode(string source)
        {
            string encode = string.Empty;
            byte[] bytes = Encoding.UTF8.GetBytes(source);
            try
            {
                encode = Convert.ToBase64String(bytes).Replace("+", "%2B");//注意加号（’+‘）的替换处理，否则由于加号经过Url传递后变成空格而得不到合法的Base64字符串;
            }
            catch
            {
                encode = source;
            }
            return encode;
        }

        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="result">待解密的密文</param>
        /// <returns>解密后的字符串</returns>
        public static string Base64Decode(string result)
        {
            result = result.Replace(" ", "+");
            string decode = string.Empty;
            byte[] bytes = Convert.FromBase64String(result);
            try
            {
                decode = Encoding.UTF8.GetString(bytes);
            }
            catch
            {
                decode = result;
            }
            return decode;
        }

        /// <summary>
        /// 生成时间戳，标准北京时间，时区为东八区，自1970年1月1日 0点0分0秒以来的秒数
        /// </summary>
        /// <returns>时间戳</returns>
        public static string GenerateTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        /// <summary>
        /// 生成随机数
        /// </summary>
        /// <param name="codeCount"></param>
        /// <returns></returns>
        public static string GenerateRandom(int codeCount)
        {
            string str = string.Empty;
            Random random = new Random();
            for (int i = 0; i < codeCount; i++)
            {
                int num = random.Next(0, 9);
                str = str + num.ToString();
            }
            return str;
        }
    }
}
