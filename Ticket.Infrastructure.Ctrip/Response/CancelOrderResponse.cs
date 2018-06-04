using System.Xml.Serialization;

namespace Ticket.Infrastructure.Ctrip.Response
{
    [XmlRoot("response")]
    public class CancelOrderResponse
    {
        public HeaderResponse header { get; set; }
        public CancelOrderBodyRespose body { get; set; }
    }

    public class CancelOrderBodyRespose
    {
        /// <summary>
        /// 实际取消数量
        /// </summary>
        public int cancelCount { get; set; }
        /// <summary>
        /// 退款的手续费，如没有则为0
        /// </summary>
        public decimal charge { get; set; }
        /// <summary>
        /// 申请取消成功 2
        /// 取消（审核）成功 3
        /// 取消（审核）失败 4
        /// 注意：orderStatus为2或3时resultCode均返回0000
        /// </summary>
        public string orderStatus { get; set; }
        /// <summary>
        /// 最长审核的时间，以小时为单位
        /// </summary>
        public int auditDuration { get; set; }
    }
}
