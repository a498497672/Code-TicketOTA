using System.Xml.Serialization;

namespace Ticket.Infrastructure.Ctrip.Response
{
    [XmlRoot("response")]
    public class CreateOrderResponse
    {
        public HeaderResponse header { get; set; }
        public CreateOrderBodyRespose body { get; set; }
    }

    public class CreateOrderBodyRespose
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
        /// 凭证短信发送方式
        /// 0、供应商发 
        /// 1、OTA发普通短信（凭身份证/手机号/订单单号等）
        /// 2、OTA发凭证短信
        /// 3、OTA发二维码短信(含凭证码)
        /// 4、OTA发二维码短信（二维码根据数据流生成）
        /// </summary>
        public int smsCodeType { get; set; }
        /// <summary>
        /// 短信凭证码
        /// smsCodeType为2或3时必返回值
        /// smsCodeType为3返回值为辅助码, 可生成二维码消费
        /// </summary>
        public string smsCode { get; set; }
        /// <summary>
        /// smsCodeType为3时，返回二维码图片数据流
        /// </summary>
        public string smsDataStream { get; set; }
        /// <summary>
        /// 剩余库存，当resultCode=1003库存不足时，需要反馈剩余库存的数量，无剩余库存返回0
        /// </summary>
        public int inventory { get; set; }
    }
}
