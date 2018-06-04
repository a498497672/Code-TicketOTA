using System.Xml.Serialization;

namespace Ticket.Infrastructure.Ctrip.Request
{
    /// <summary>
    /// 请求参数
    /// </summary>
    [XmlRoot("request")]
    public class NoticeOrderConsumedRequest
    {
        public HeaderRequest header { get; set; }
        public NoticeOrderConsumedBody body { get; set; }
    }

    /// <summary>
    /// 消费通知接口
    /// </summary>
    [XmlRoot("body")]
    public class NoticeOrderConsumedBody
    {
        /// <summary>
        /// OTA订单号
        /// </summary>
        public string otaOrderId { get; set; }
        /// <summary>
        /// 供应商订单号
        /// </summary>
        public string vendorOrderId { get; set; }
        /// <summary>
        /// 实际使用日期”yyyy-MM-dd”
        /// </summary>
        public string useDate { get; set; }
        /// <summary>
        /// 订单产品总数量
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 使用数量
        /// </summary>
        public int useCount { get; set; }
        /// <summary>
        /// 取消数量
        /// </summary>
        public int cancelCount { get; set; }
    }
}
