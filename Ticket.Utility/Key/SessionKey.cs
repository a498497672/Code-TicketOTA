using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Utility.Key
{
    public class SessionKey
    {
        /// <summary>
        /// 内部系统SESSION
        /// </summary>
        public const string ManagerUserInfo = "ManagerUserInfo";

        /// <summary>
        /// 票务系统登录验证码
        /// </summary>
        public const string ManagerUserLoginCode = "ManagerUserLoginCode";
        /// <summary>
        /// 票务系统登录的cookie
        /// </summary>
        public const string ManagerUserLoginCookie = "ManagerUserLoginCookie";

        /// <summary>
        /// 内部系统COOKIE加密解密秘钥
        /// </summary>
        public const string ManagerUserLoginCookieKey = "fengjing";

        public const string CloudUserInfo = "Session_Cloud_UserInfo";
    }
}
