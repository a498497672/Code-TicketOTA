using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Infrastructure.KouDaiLingQian.Response
{
    class MicroOrderResponse
    {
        /// <summary>
        /// 结果码
        /// </summary>
        public string returnCode { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        public string returnMessage { get; set; }
        /// <summary>
        /// 商户系统内部的订单号,32 个字符内、可包含字母, 确保在商户系统唯一
        /// </summary>
        public string outTradeNo { get; set; }
        /// <summary>
        /// 口袋零钱系统订单号
        /// </summary>
        public string outChannelNo { get; set; }
        /// <summary>
        /// 签名，详见本文档签名说明
        /// </summary>
        public string sign { get; set; }
    }
}
