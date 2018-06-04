using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Infrastructure.Ctrip.Core;
using Ticket.Infrastructure.Ctrip.Lib;
using Ticket.Infrastructure.Ctrip.Request;
using Ticket.Infrastructure.Ctrip.Response;

namespace Ticket.Infrastructure.Ctrip
{
    /// <summary>
    /// 携程
    /// </summary>
    public class CtripGateway
    {
        /// <summary>
        /// 验证请求数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Result<HeaderRequest> CheckHeader(string request)
        {
            return Api.CheckHeader(request);
        }

        public string ErrorResult(string code, string msg)
        {
            return Api.ErrorResult(code, msg);
        }

        public string ErrorResult(string code, string msg, VerifyOrderBodyRespose verifyOrderBodyRespose)
        {
            return Api.ErrorResult(code, msg, verifyOrderBodyRespose);
        }

        public string ErrorResult(string code, string msg, CreateOrderBodyRespose createOrderBodyRespose)
        {
            return Api.ErrorResult(code, msg, createOrderBodyRespose);
        }

        /// <summary>
        /// 验证下单验证请求数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Result<VerifyOrderBody> CheckVerifyOrder(string request)
        {
            return Api.CheckBodyData<VerifyOrderBody>(request);
        }

        /// <summary>
        /// 验证创建订单请求数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Result<CreateOrderBody> CheckCreateOrder(string request)
        {
            return Api.CheckBodyData<CreateOrderBody>(request);
        }

        /// <summary>
        /// 验证取消订单请求数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Result<CancelOrderBody> CheckCancelOrder(string request)
        {
            return Api.CheckBodyData<CancelOrderBody>(request);
        }

        /// <summary>
        /// 验证查询订单请求数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Result<QueryOrderBody> CheckQueryOrder(string request)
        {
            return Api.CheckBodyData<QueryOrderBody>(request);
        }

        /// <summary>
        /// 下单验证接口
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public string VerifyOrder(VerifyOrderBodyRespose response)
        {
            return Api.SuccessResult(response);
        }

        /// <summary>
        /// 创建订单接口
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public string CreateOrder(CreateOrderBodyRespose response)
        {
            return Api.SuccessResult(response);
        }

        /// <summary>
        /// 取消订单接口
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public string CancelOrder(CancelOrderBodyRespose response)
        {
            return Api.SuccessResult(response);
        }

        /// <summary>
        /// 查询订单接口
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public string QueryOrder(QueryOrderBodyResponse response)
        {
            return Api.SuccessResult(response);
        }

        /// <summary>
        /// 消费通知接口
        /// </summary>
        /// <param name="noticeOrderConsumedRequest"></param>
        /// <returns></returns>
        public bool NoticeOrderConsumed(NoticeOrderConsumedBody noticeOrderConsumedRequest)
        {
            return OrderConsumed.Run(noticeOrderConsumedRequest);
        }
    }
}
