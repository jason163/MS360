using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS360.Web.Entity
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class LoginUser
    {
        /// <summary>
        /// 用户系统编号
        /// </summary>
        public int UserSysNo { get; set; }

        /// <summary>
        /// 登录名称
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// 显示名称
        /// </summary>        
        public string UserDisplayName { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public bool RememberLogin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime LoginDate { get { return DateTime.Parse(LoginDateText); } }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Timeout { get { return DateTime.Parse(TimeoutText); } }
        /// <summary>
        /// 
        /// </summary>
        public string TimeoutText { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LoginDateText { get; set; }
    }
}
