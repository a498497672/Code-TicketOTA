using System.Xml.Serialization;

namespace Ticket.Infrastructure.Ctrip.Request
{
    [XmlRoot("request")]
    public class CancelOrderRequest
    {
        public HeaderRequest header { get; set; }
        public CancelOrderBody body { get; set; }
    }

    [XmlRoot("body")]
    public class CancelOrderBody
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
        /// 取消批次流水号
        /// </summary>
        public string sequenceId { get; set; }
        /// <summary>
        /// 取消时候必须验证取消数量
        /// </summary>
        public int cancelCount { get; set; }
    }
}
