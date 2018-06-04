using System.Xml.Serialization;

namespace Ticket.Infrastructure.Ctrip.Response
{
    [XmlRoot("response")]
    public class QueryOrderResponse
    {
        public HeaderResponse header { get; set; }
        public QueryOrderBodyResponse body { get; set; }
    }

    public class QueryOrderBodyResponse
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
        /// 实际订单状态
        /// 新订单 1
        /// 申请取消成功 2
        /// 取消（审核）成功 3
        /// 取消（审核）失败 4
        /// 已入园5
        /// 部分取消6
        /// 部分入园7
        /// 已取件8
        /// 已还件9
        /// </summary>
        public string orderStatus { get; set; }
        /// <summary>
        /// 订单总金额
        /// </summary>
        public decimal amount { get; set; }
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
