using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Infrastructure.KouDaiLingQian.Request
{
    public class MicroOrderRequest
    {
        /// <summary>
        /// 版本号 1.0.0
        /// </summary>
        public string version { get; set; }
        /// <summary>
        /// 请求时间 时间格式： yyyyMMddHHmmss
        /// </summary>
        public string reqtime { get; set; }
        /// <summary>
        /// 随机数 不小于 4 位的随机数
        /// </summary>
        public string rancode { get; set; }
        /// <summary>
        /// 签名结果 
        /// </summary>
        public string sign { get; set; }
        /// <summary>
        /// OTHER
        /// </summary>
        public string terminalType { get; set; }
        /// <summary>
        /// 与 snNo 二选一。平台商户号，由平台分配
        /// </summary>
        public string merchantNo { get; set; }
        /// <summary>
        /// 与 merchantNo 二选一。已绑定商户的支付设备编号
        /// </summary>
        public string snNo { get; set; }
        /// <summary>
        /// 收银员编号
        /// </summary>
        public string casherNo { get; set; }
        /// <summary>
        /// 外部接入系统订单号,32 个字符内、可包含字母, 确保在外部系统唯一
        /// </summary>
        public string outTradeNo { get; set; }
        /// <summary>
        /// 支付金额，单位：元，保留小数点后两位
        /// </summary>
        public string amount { get; set; }
        /// <summary>
        ///  商户系统下单时间，格式为yyyyMMddHHmmss
        /// </summary>
        public string orderTime { get; set; }
        /// <summary>
        /// 请求来源系统编号
        /// </summary>
        public string systemCode { get; set; }
        /// <summary>
        /// 用户条形码编号
        /// </summary>
        public string authCode { get; set; }
        /// <summary>
        /// 附加数据，在查询 API 和支付通知中原样返回，该字段主要用于商户携带订单的自定义数据
        /// </summary>
        public string description { get; set; }
        
    }
}
