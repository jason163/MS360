using MS360.Web.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS360.Web.Entity.Home
{
    /// <summary>
    /// 
    /// </summary>
    public class CellPhoneConfirmTemp
    {
        /// <summary>
        /// 
        /// </summary>
        public int SysNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CustomerSysNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CellPhone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public VerifyType? VerifyType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string VerifyCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ExpireTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? VerifyTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string VerifyIP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ClientType? ClientSource { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public VerifyStatus? Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? InDate { get; set; }
    }
}
