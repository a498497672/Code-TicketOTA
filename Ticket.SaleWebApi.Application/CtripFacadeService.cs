using FengjingSDK461.Core;
using FengjingSDK461.Enum;
using FengjingSDK461.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Infrastructure.Ctrip;
using Ticket.Infrastructure.Ctrip.Lib;
using Ticket.Infrastructure.Ctrip.Request;
using Ticket.Infrastructure.Ctrip.Response;

namespace Ticket.SaleWebApi.Application
{
    /// <summary>
    /// 携程
    /// </summary>
    public class CtripFacadeService
    {
        private readonly CtripGateway _ctripGateway;
        private readonly TicketGateway _ticketGateway;
        public CtripFacadeService(
            CtripGateway ctripGateway)
        {
            _ctripGateway = ctripGateway;
            _ticketGateway = new TicketGateway(OtaType.Ctrip);
        }

        public string Handler(string request)
        {
            var requestHeaderData = _ctripGateway.CheckHeader(request);
            if (!requestHeaderData.Status)
            {
                return requestHeaderData.Response;
            }
            var response = string.Empty;
            switch (requestHeaderData.Data.serviceName)
            {
                case "VerifyOrder":
                    response = VerifyOrder(request);
                    break;
                case "CreateOrder":
                    response = CreateOrder(request);
                    break;
                case "CancelOrder":
                    response = CancelOrder(request);
                    break;
                case "QueryOrder":
                    response = QueryOrder(request);
                    break;
            }
            return response;
        }

        /// <summary>
        /// 下单验证
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string VerifyOrder(string request)
        {
            var requestBody = _ctripGateway.CheckVerifyOrder(request);
            var data = requestBody.Data;
            int productId = 0;
            decimal price = data.price.HasValue ? data.price.Value : 0;
            if (!int.TryParse(data.productId, out productId))
            {
                return _ctripGateway.ErrorResult(ResultCode.CreateOrderForProductNotExist, "产品Id不存在/错误");
            }
            var response = _ticketGateway.VerifyOrder(new OrderSingleCreateRequest
            {
                Body = new OrderSingleCreateBody
                {
                    OrderInfo = new OrderSingleInfo
                    {
                        OrderOtaId = "",
                        OrderPayStatus = 1,
                        OrderPrice = price * data.count,
                        OrderQuantity = data.count,
                        Ticket = new ProductItem
                        {
                            ProductId = productId,
                            Quantity = data.count,
                            ProductName = "",
                            SellPrice = price
                        },
                        VisitDate = data.useDate,
                        ContactPerson = new ContactPerson
                        {
                            BuyName = data.contactName,
                            Name = data.contactName,
                            Mobile = data.contactMobile,
                            CardType = data.contactIdCardType == "1" ? "ID_CARD" : "",
                            CardNo = data.contactIdCardType == "1" ? data.contactIdCardNo : ""
                        }
                    }
                }
            });
            if (response.Head.Code == "000000")
            {
                var responseBody = new VerifyOrderBodyRespose
                {
                    inventory = response.Body.Inventory
                };
                return _ctripGateway.VerifyOrder(responseBody);
            }
            else if (response.Head.Code == "113019")
            {
                return _ctripGateway.ErrorResult(ResultCode.CreateOrderForProductDownline, response.Head.Describe);
            }
            else if (response.Head.Code == "113026")
            {
                var responseBody = new VerifyOrderBodyRespose
                {
                    inventory = response.Body.Inventory
                };
                return _ctripGateway.ErrorResult(ResultCode.CreateOrderForLowStocks, response.Head.Describe, responseBody);
            }
            else if (response.Head.Code == "113021")
            {
                return _ctripGateway.ErrorResult(ResultCode.SystemError, "系统出错");
            }
            return _ctripGateway.ErrorResult(ResultCode.CreateOrderForParameterIllegality, response.Head.Describe);
        }
        /// <summary>
        /// 下单验证
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string CreateOrder(string request)
        {
            var requestBody = _ctripGateway.CheckCreateOrder(request);
            var data = requestBody.Data;
            int productId = 0;
            decimal price = data.price.HasValue ? data.price.Value : 0;
            if (!int.TryParse(data.productId, out productId))
            {
                return _ctripGateway.ErrorResult(ResultCode.CreateOrderForProductNotExist, "产品Id不存在/错误");
            }
            if (data.payMode != "1")
            {
                return _ctripGateway.ErrorResult(ResultCode.CreateOrderForParameterIllegality, "付款方式必须网站预付");
            }
            var response = _ticketGateway.SingleCreateOrder(new OrderSingleCreateRequest
            {
                Body = new OrderSingleCreateBody
                {
                    OrderInfo = new OrderSingleInfo
                    {
                        OrderOtaId = data.otaOrderId,
                        OrderPayStatus = 1,
                        OrderPrice = price * data.count,
                        OrderQuantity = data.count,
                        Ticket = new ProductItem
                        {
                            ProductId = productId,
                            Quantity = data.count,
                            ProductName = data.otaProductName,
                            SellPrice = price
                        },
                        VisitDate = data.useDate,
                        ContactPerson = new ContactPerson
                        {
                            BuyName = data.contactName,
                            Name = data.contactName,
                            Mobile = data.contactMobile,
                            CardType = data.contactIdCardType == "1" ? "ID_CARD" : "",
                            CardNo = data.contactIdCardType == "1" ? data.contactIdCardNo : ""
                        }
                    }
                }
            });
            if (response.Head.Code == "000000")
            {
                var responseBody = new CreateOrderBodyRespose
                {
                    otaOrderId = response.Body.OtaOrderId,
                    vendorOrderId = response.Body.OrderId,
                    smsCodeType = 2,
                    smsCode = response.Body.Code,
                    smsDataStream = "",
                    inventory = response.Body.Inventory
                };
                return _ctripGateway.CreateOrder(responseBody);
            }
            else if (response.Head.Code == "113019")
            {
                return _ctripGateway.ErrorResult(ResultCode.CreateOrderForProductDownline, response.Head.Describe);
            }
            else if (response.Head.Code == "113026")
            {
                var responseBody = new CreateOrderBodyRespose
                {
                    inventory = response.Body.Inventory
                };
                return _ctripGateway.ErrorResult(ResultCode.CreateOrderForLowStocks, response.Head.Describe, responseBody);
            }
            else if (response.Head.Code == "113021")
            {
                return _ctripGateway.ErrorResult(ResultCode.SystemError, "系统出错");
            }
            return _ctripGateway.ErrorResult(ResultCode.CreateOrderForParameterIllegality, response.Head.Describe);
        }
        /// <summary>
        /// 取消接口
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        public string CancelOrder(string request)
        {
            var requestBody = _ctripGateway.CheckCancelOrder(request);
            var data = requestBody.Data;
            var response = _ticketGateway.CancelOrder(new OrderCancelRequest
            {
                Body = new OrderCancelBody
                {
                    OrderInfo = new OrderCancelInfo
                    {
                        OrderId = data.vendorOrderId,
                        OrderPrice = 0,
                        OrderQuantity = data.cancelCount,
                        reason = "",
                        Seq = data.sequenceId
                    }
                }
            });
            if (response.Head.Code == "000000")
            {
                var responseBody = new CancelOrderBodyRespose
                {
                    orderStatus = "3",
                    cancelCount = data.cancelCount,
                    charge = 0,
                    auditDuration = 0
                };
                return _ctripGateway.CancelOrder(responseBody);
            }
            else if (response.Head.Code == "114007")
            {
                return _ctripGateway.ErrorResult(ResultCode.CancelOrderForNotCount, "取消数量不正确,同时不支持部分取消");
            }
            else if (response.Head.Code == "114004")
            {
                return _ctripGateway.ErrorResult(ResultCode.CancelOrderNumberNotExist, response.Head.Describe);
            }
            else if (response.Head.Code == "114009" || response.Head.Code == "114013")
            {
                return _ctripGateway.ErrorResult(ResultCode.CancelOrderForConsume, response.Head.Describe);
            }
            else if (response.Head.Code == "114010")
            {
                return _ctripGateway.ErrorResult(ResultCode.CancelOrderForCancel, response.Head.Describe);
            }
            else if (response.Head.Code == "114011")
            {
                return _ctripGateway.ErrorResult(ResultCode.CancelOrderForExpired, response.Head.Describe);
            }
            else if (response.Head.Code == "114012")
            {
                return _ctripGateway.ErrorResult(ResultCode.SystemError, response.Head.Describe);
            }
            return _ctripGateway.ErrorResult(ResultCode.CancelOrderForError, response.Head.Describe);
        }
        /// <summary>
        /// 查询接口
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        public string QueryOrder(string request)
        {
            var requestBody = _ctripGateway.CheckQueryOrder(request);
            var data = requestBody.Data;
            var response = _ticketGateway.QueryOrder(new OrderQuery
            {
                OrderId = data.vendorOrderId
            });
            if (response.Head.Code == "000000")
            {
                var info = response.Body.OrderInfo.EticketInfo.FirstOrDefault();
                var responseBody = new QueryOrderBodyResponse
                {
                    otaOrderId = data.otaOrderId,
                    vendorOrderId = data.vendorOrderId,
                    count = info.EticketQuantity,
                    amount = info.MarketPrice * info.EticketQuantity,
                    useCount = 0,
                    cancelCount = 0
                };
                if (info.OrderStatus == (int)TicketOrderStatus.Success)
                {
                    responseBody.orderStatus = "1";
                }
                else if (info.OrderStatus == (int)TicketOrderStatus.Canncel)
                {
                    responseBody.orderStatus = "3";
                    responseBody.cancelCount = info.EticketQuantity;
                }
                else if (info.OrderStatus == (int)TicketOrderStatus.Consume)
                {
                    responseBody.orderStatus = "5";
                    if (info.UseQuantity != info.EticketQuantity)
                    {
                        responseBody.orderStatus = "6";
                    }
                    responseBody.useCount = info.UseQuantity;
                }
                return _ctripGateway.QueryOrder(responseBody);
            }
            else if (response.Head.Code == "115002")
            {
                return _ctripGateway.ErrorResult(ResultCode.QueryOrderNumberNotExist, response.Head.Describe);
            }
            return _ctripGateway.ErrorResult(ResultCode.SystemError, response.Head.Describe);
        }
    }
}
