using System;
using Ticket.Infrastructure.Ctrip.Lib;
using Ticket.Infrastructure.Ctrip.Request;
using Ticket.Infrastructure.Ctrip.Response;

namespace Ticket.Infrastructure.Ctrip.Core
{
    /// <summary>
    /// 消费通知接口
    /// 业务说明 供应商在游客取件（票）、还件时候调用该接口。
    /// 注：该接口仅接受最终核单的结果。若因网络超时或其他原因导致没有收到OTA处理结果响应，
    /// 请用相同报文 body 体请求。
    /// </summary>
    public class OrderConsumed
    {
        /// <summary>
        /// 消费通知接口
        /// </summary>
        /// <param name="noticeOrderConsumedRequest"></param>
        /// <returns></returns>
        public static bool Run(NoticeOrderConsumedBody noticeOrderConsumedBody)
        {
            var request = new NoticeOrderConsumedRequest
            {
                header = new HeaderRequest
                {
                    accountId = CtripConfig.AccountId,
                    serviceName = "NoticeOrderConsumed",
                    requestTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    version = CtripConfig.Version
                },
                body = noticeOrderConsumedBody
            };
            var xml = Helper.SerializeToXml(request);
            var body = Helper.GetBodyStr(xml);
            var data = Helper.Base64Encode(body);
            var sign = Helper.MakeSign(request.header.accountId, request.header.serviceName, request.header.requestTime, data, request.header.version);
            request.header.sign = sign;
            var dataXml = Helper.SerializeToXml(request);
            var contnt = HttpService.Post(dataXml, CtripConfig.Website);
            if (!string.IsNullOrEmpty(contnt))
            {
                var response = (PublicResponse)Helper.Deserialize(contnt, typeof(PublicResponse));
                if (response != null && response.header.resultCode == ResultCode.Success)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
