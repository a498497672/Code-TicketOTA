using System.Xml.Serialization;

namespace Ticket.Infrastructure.Ctrip.Request
{
    [XmlRoot("request")]
    public class QueryOrderRequest
    {
        public HeaderRequest header { get; set; }
        public QueryOrderBody body { get; set; }
    }

    [XmlRoot("body")]
    public class QueryOrderBody
    {
        /// <summary>
        /// OTA订单号
        /// </summary>
        public string otaOrderId { get; set; }
        /// <summary>
        /// 供应商订单号
        /// </summary>
        public string vendorOrderId { get; set; }
    }
}
