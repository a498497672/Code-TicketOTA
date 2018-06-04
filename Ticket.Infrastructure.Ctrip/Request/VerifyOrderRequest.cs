using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ticket.Infrastructure.Ctrip.Request
{
    [XmlRoot("request")]
    public class VerifyOrderRequest
    {
        public HeaderRequest header { get; set; }
        public VerifyOrderBody body { get; set; }
    }

    [XmlRoot("body")]
    public class VerifyOrderBody
    {
        /// <summary>
        /// 产品Id
        /// </summary>
        public string productId { get; set; }
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
    }

    public class PassengerInfo
    {
        /// <summary>
        /// 出行人姓名，需要支持中/英文
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 出行人手机号
        /// </summary>
        public string mobile { get; set; }
        /// <summary>
        /// 出行人证件类型，默认身份证，具体定义参见附录4.2
        /// </summary>
        public string cardType { get; set; }
        /// <summary>
        /// 出行人证件号，可空，实名制产品必传
        /// </summary>
        public string cardNo { get; set; }
        /// <summary>
        /// 出行人生日，格式：“yyyy-MM-dd”
        /// </summary>
        public string birthDate { get; set; }
        /// <summary>
        /// 出行人性别，M男F女
        /// </summary>
        public string gender { get; set; }
    }
}
