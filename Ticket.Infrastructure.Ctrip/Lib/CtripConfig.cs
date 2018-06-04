using System.Configuration;

namespace Ticket.Infrastructure.Ctrip.Lib
{
    /// <summary>
    /// 携程信息配置
    /// </summary>
    public class CtripConfig
    {
        //XIECHENG_HTTP_SERVER = https://ttdstp.ctrip.com/api/orderhandle.do
        //XIECHENG_VENDOR_ACCOUNTID = fba77363652466db
        //XIECHENG_VERSION = 2.0
        //XIECHENG_SIGNKEY = cbf193d7892d3426eec78f2eb76f6df0

        //#production
        //#XIECHENG_HTTP_SERVER=https://ttdstp.ctrip.com/api/orderhandle.do
        //#XIECHENG_VENDOR_ACCOUNTID=edff85de42832cdb
        //#XIECHENG_VERSION=2.0
        //#XIECHENG_SIGNKEY=e83a51936dd6d83f58b33c30c040ed84

        //#XIECHENG_HTTP_SERVER=http://piao.ctrip.com/thingstodo-vendor-vendorconnectservice/orderapi/orderhandler.ashx


        //=======【基本信息设置】=====================================
        /* 携程信息配置
        * AccountId：OTA分配给供应商的账户（必须配置）
        * Version：版本号（必须配置）
        * Key：密钥（必须配置）
        * Website：请求地址（必须配置）
        */
        /// <summary>
        /// 携程用户标识
        /// </summary>
        public static readonly string AccountId = ConfigurationManager.AppSettings["Ctrip:AccountId"];
        public static readonly string Version = ConfigurationManager.AppSettings["Ctrip:Version"];
        public static readonly string Key = ConfigurationManager.AppSettings["Ctrip:Key"];
        public static readonly string Website = ConfigurationManager.AppSettings["Ctrip:Website"];

        /// <summary>
        /// 供应商分配给携程用户标识
        /// </summary>
        public static readonly string MyAccountId = ConfigurationManager.AppSettings["TicketCtrip:UserId"];
    }
}
