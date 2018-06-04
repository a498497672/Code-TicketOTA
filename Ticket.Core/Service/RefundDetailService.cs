using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Core.Repository;
using Ticket.SqlSugar.Models;

namespace Ticket.Core.Service
{
    /// <summary>
    /// 退款
    /// </summary>
    public class RefundDetailService
    {
        private readonly RefundDetailRepository _refundDetailRepository;
        public RefundDetailService(RefundDetailRepository refundDetailRepository)
        {
            _refundDetailRepository = refundDetailRepository;
        }

        /// <summary>
        /// 添加退款记录
        /// </summary>
        /// <param name="tbl_OrderDetail"></param>
        public Tbl_RefundDetail Add(Tbl_OrderDetail tbl_OrderDetail)
        {
            Tbl_RefundDetail tbl_RefundDetail = new Tbl_RefundDetail
            {
                OrderNo = tbl_OrderDetail.OrderNo,
                EnterpriseId = tbl_OrderDetail.EnterpriseId,
                ScenicId = tbl_OrderDetail.ScenicId,
                SellerId = tbl_OrderDetail.SellerId,
                SellerType = tbl_OrderDetail.SellerType,
                TicketSource = tbl_OrderDetail.TicketSource,
                TicketCategory = tbl_OrderDetail.TicketCategory,
                UsedQuantity = tbl_OrderDetail.UsedQuantity,
                TicketId = tbl_OrderDetail.TicketId,
                TicketName = tbl_OrderDetail.TicketName,
                Quantity = tbl_OrderDetail.Quantity,
                Price = tbl_OrderDetail.Price,
                BarCode = tbl_OrderDetail.BarCode,
                Stub = tbl_OrderDetail.Stub,
                CertificateNO = tbl_OrderDetail.CertificateNO,
                WindowId = tbl_OrderDetail.WindowId,
                IDCard = tbl_OrderDetail.IDCard,
                Linkman = tbl_OrderDetail.Linkman,
                Mobile = tbl_OrderDetail.Mobile,
                RefundStatus = 0,//退款状态
                RefundQuantity = tbl_OrderDetail.Quantity,
                RefundFee = 0,
                RefundTotalAmount = (tbl_OrderDetail.Price * tbl_OrderDetail.Quantity),
                RefundSummary = "",
                OrderTime = tbl_OrderDetail.CreateTime,
                ValidityDateStart = tbl_OrderDetail.ValidityDateStart,
                ValidityDateEnd = tbl_OrderDetail.ValidityDateEnd,
                PrintCount = tbl_OrderDetail.PrintCount,
                Qrcode = tbl_OrderDetail.QRcode,
                QrcodeUrl = tbl_OrderDetail.QRcodeUrl,
                OrderDetailId = tbl_OrderDetail.OrderDetailId,

                CreateTime = DateTime.Now,
                CreateUserId = 0
            };
            _refundDetailRepository.Add(tbl_RefundDetail);
            return tbl_RefundDetail;
        }
    }
}
