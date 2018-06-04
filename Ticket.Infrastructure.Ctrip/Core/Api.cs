using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Infrastructure.Ctrip.Lib;
using Ticket.Infrastructure.Ctrip.Request;
using Ticket.Infrastructure.Ctrip.Response;

namespace Ticket.Infrastructure.Ctrip.Core
{
    public class Api
    {
        /// <summary>
        /// 验证数据是否被篡改(签名等)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static Result<HeaderRequest> CheckHeader(string request)
        {
            var requestData = CheckHeaderFormat(request);
            if (requestData == null)
            {
                return Result<HeaderRequest>.FailResult(ErrorResult(ResultCode.XmlParsingFailure, "XML解析失败"));
            }
            if (requestData.accountId != CtripConfig.MyAccountId)
            {
                return Result<HeaderRequest>.FailResult(ErrorResult(ResultCode.IncorrectAccountInformation, "OTA账户信息不正确"));
            }
            var isSign = CheckSign(request, requestData);
            if (!isSign)
            {
                return Result<HeaderRequest>.FailResult(ErrorResult(ResultCode.SignatureError, "签名错误"));
            }

            return Result<HeaderRequest>.SuccessResult(requestData);
        }

        /// <summary>
        /// 验证数据结构
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public static Result<T> CheckBodyData<T>(string request)
        {
            var requestBody = Helper.GetBodyStr(request);
            var requestBodyData = (T)Helper.Deserialize(requestBody, typeof(T));
            if (requestBodyData == null)
            {
                return Result<T>.FailResult(ErrorResult(ResultCode.XmlParsingFailure, "XML解析失败"));
            }
            return Result<T>.SuccessResult(requestBodyData);
        }

        /// <summary>
        /// 验证Header格式是否正确
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static HeaderRequest CheckHeaderFormat(string request)
        {
            try
            {
                var header = Helper.GetBodyStr(request, "<header>", "</header>");
                var headerRequest = (HeaderRequest)Helper.Deserialize(header, typeof(HeaderRequest));
                return headerRequest;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static bool CheckSign(string request, HeaderRequest header)
        {
            var body = Helper.GetBodyStr(request);
            var data = Helper.Base64Encode(body);
            var sign = Helper.MakeSign(header.accountId, header.serviceName, header.requestTime, data, header.version);
            if (sign == header.sign.ToLower())
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 错误返回
        /// </summary>
        /// <param name="resultCode"></param>
        /// <param name="resultMessage"></param>
        /// <returns></returns>
        public static string ErrorResult(string resultCode, string resultMessage)
        {
            var publicRespose = new PublicResponse
            {
                header = new HeaderResponse
                {
                    resultCode = resultCode,
                    resultMessage = resultMessage
                }
            };
            return Helper.SerializeToXml(publicRespose);
        }

        /// <summary>
        /// 错误返回
        /// </summary>
        /// <param name="resultCode"></param>
        /// <param name="resultMessage"></param>
        /// <returns></returns>
        public static string ErrorResult(string resultCode, string resultMessage, VerifyOrderBodyRespose verifyOrderBodyRespose)
        {
            var publicRespose = new VerifyOrderResponse
            {
                header = new HeaderResponse
                {
                    resultCode = resultCode,
                    resultMessage = resultMessage
                },
                body = verifyOrderBodyRespose
            };
            return Helper.SerializeToXml(publicRespose);
        }
        
        /// <summary>
        /// 错误返回
        /// </summary>
        /// <param name="resultCode"></param>
        /// <param name="resultMessage"></param>
        /// <returns></returns>
        public static string ErrorResult(string resultCode, string resultMessage, CreateOrderBodyRespose verifyOrderBodyRespose)
        {
            var publicRespose = new CreateOrderResponse
            {
                header = new HeaderResponse
                {
                    resultCode = resultCode,
                    resultMessage = resultMessage
                },
                body = verifyOrderBodyRespose
            };
            return Helper.SerializeToXml(publicRespose);
        }

        /// <summary>
        /// 成功返回
        /// </summary>
        /// <param name="responseBody"></param>
        /// <returns></returns>
        public static string SuccessResult(VerifyOrderBodyRespose responseBody)
        {
            var responseData = new VerifyOrderResponse
            {
                header = new HeaderResponse
                {
                    resultCode = ResultCode.Success,
                    resultMessage = "成功"
                },
                body = responseBody
            };
            return Helper.SerializeToXml(responseData);
        }

        /// <summary>
        /// 成功返回
        /// </summary>
        /// <param name="responseBody"></param>
        /// <returns></returns>
        public static string SuccessResult(CreateOrderBodyRespose responseBody)
        {
            var responseData = new CreateOrderResponse
            {
                header = new HeaderResponse
                {
                    resultCode = ResultCode.Success,
                    resultMessage = "成功"
                },
                body = responseBody
            };
            return Helper.SerializeToXml(responseData);
        }

        /// <summary>
        /// 成功返回
        /// </summary>
        /// <param name="responseBody"></param>
        /// <returns></returns>
        public static string SuccessResult(CancelOrderBodyRespose responseBody)
        {
            var responseData = new CancelOrderResponse
            {
                header = new HeaderResponse
                {
                    resultCode = ResultCode.Success,
                    resultMessage = "成功"
                },
                body = responseBody
            };
            return Helper.SerializeToXml(responseData);
        }

        /// <summary>
        /// 成功返回
        /// </summary>
        /// <param name="responseBody"></param>
        /// <returns></returns>
        public static string SuccessResult(QueryOrderBodyResponse responseBody)
        {
            var responseData = new QueryOrderResponse
            {
                header = new HeaderResponse
                {
                    resultCode = ResultCode.Success,
                    resultMessage = "成功"
                },
                body = responseBody
            };
            return Helper.SerializeToXml(responseData);
        }
    }
}
