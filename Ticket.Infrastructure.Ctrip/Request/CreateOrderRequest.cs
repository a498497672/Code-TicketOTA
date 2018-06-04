using System.Collections.Generic;
using System.Xml.Serialization;

namespace Ticket.Infrastructure.Ctrip.Request
{
    [XmlRoot("request")]
    public class CreateOrderRequest
    {
        public HeaderRequest header { get; set; }
        public CreateOrderBody body { get; set; }
    }

    [XmlRoot("body")]
    public class CreateOrderBody
    {
        /// <summary>
        /// OTA订单号
        /// </summary>
        public string otaOrderId { get; set; }
        /// <summary>
        /// 产品Id
        /// </summary>
        public string productId { get; set; }
        /// <summary>
        /// OTA产品名称
        /// </summary>
        public string otaProductName { get; set; }
        /// <summary>
        /// 卖价
        /// </summary>
        public decimal? price { get; set; }
        /// <summary>
        /// 订单总数量
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 联系人（取件人）姓名，需要支持中/英文
        /// </summary>
        public string contactName { get; set; }
        /// <summary>
        /// 联系人（取件人）手机号
        /// </summary>
        public string contactMobile { get; set; }
        /// <summary>
        /// 联系人（取件人）证件类型，默认身份证
        /// </summary>
        public string contactIdCardType { get; set; }
        /// <summary>
        /// 联系人（取件人）证件号，实名制产品必传
        /// </summary>
        public string contactIdCardNo { get; set; }
        /// <summary>
        /// 联系人（取件人）箱地址
        /// </summary>
        public string contactEmail { get; set; }
        /// <summary>
        /// 实名制
        /// </summary>
        public PassengerInfo passengerInfos { get; set; }
        /// <summary>
        /// 游玩（使用）开始时间，格式：“yyyy-MM-dd”
        /// </summary>
        public string useDate { get; set; }
        /// <summary>
        /// 游玩（使用）结束时间，格式：“yyyy-MM-dd”  非必传，默认当天有效，非空即该天使用有效截止日期
        /// </summary>
        public string useEndDate { get; set; }
        /// <summary>
        /// 付款方式：网站预付=1 景区现付=2
        /// </summary>
        public string payMode { get; set; }
        /// <summary>
        /// 备注信息
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// 拓展字段，产品的其他属性
        /// </summary>
        public ExtendInfo extendInfo { get; set; }
    }

    public class ExtendInfo
    {
        /// <summary>
        /// 押金/保证金额
        /// </summary>
        public string deposit { get; set; }
        /// <summary>
        /// 押金/保证金类型 网站预付=1 景区现付=2
        /// </summary>
        public decimal? depositMode { get; set; }
        /// <summary>
        /// 配送方式：1自提2供应商配送
        /// </summary>
        public string deliveryType { get; set; }
        /// <summary>
        /// 配送地址节点
        /// </summary>
        public DeliveryMessages deliveryMessages { get; set; }
    }

    /// <summary>
    /// 配送地址节点
    /// </summary>
    public class DeliveryMessages
    {
        /// <summary>
        /// 配送地址节点
        /// </summary>
        public List<DeliveryMessage> deliveryMessage { get; set; }
    }
    /// <summary>
    /// 配送地址节点
    /// </summary>
    public class DeliveryMessage
    {
        /// <summary>
        /// 省/直辖市
        /// </summary>
        public string province { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 县/区
        /// </summary>
        public string district { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string address { get; set; }
    }
}
