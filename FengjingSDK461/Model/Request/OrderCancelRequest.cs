using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengjingSDK461.Model.Request
{
    /// <summary>
    /// 取消订单
    /// </summary>
    public class OrderCancelRequest
    {
        public HeadRequest Head { get; set; }
        public OrderCancelBody Body { get; set; }
    }

    public class OrderCancelBody
    {
        public OrderCancelInfo OrderInfo { get; set; }
    }

    public class OrderCancelInfo
    {
        /// <summary>
        /// 订单Id
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 取消流水号，用于标记每一笔订单取消记录，由 OTA 定义
        /// </summary>
        public string Seq { get; set; }
        /// <summary>
        /// 原始订单总价
        /// </summary>
        public decimal OrderPrice { get; set; }
        /// <summary>
        /// 原始订单总票数
        /// </summary>
        public int OrderQuantity { get; set; }
        /// <summary>
        /// 取消原因
        /// </summary>
        public string reason { get; set; }
    }
}
