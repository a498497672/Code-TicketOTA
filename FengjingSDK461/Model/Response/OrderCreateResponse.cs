using System.Collections.Generic;

namespace FengjingSDK461.Model.Response
{
    /// <summary>
    /// 订单创建结果返回
    /// </summary>
    public class OrderCreateResponse
    {
        public HeadResponse Head { get; set; }
        public OrderCreateInfo Body { get; set; }
    }

    public class OrderCreateInfo
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public string OrderStatus { get; set; }
    }
}
