using MS360.Web.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS360.Web.Entity.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class SMSInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public int? SysNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CellNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CustomerSysNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SMSContent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? Priority { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? RetryCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? HandleTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SMSStatus? Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? InUserSysNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string InUserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SMSType? Type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CompanyCode { get; set; }
    }
}
