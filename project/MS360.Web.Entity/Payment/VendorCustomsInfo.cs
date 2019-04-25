using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MS360.Web.Entity
{
    /// <summary>
    /// 关务对接相关信息
    /// </summary>
    public class VendorCustomsInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public int SysNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int MerchantSysNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CBTMerchantCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CBTMerchantName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CBTSRC_NCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CBTREC_NCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EasiPaySecretKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ReceiveCurrencyCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ShipCurrencyCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PayCurrencyCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CBTSODeclareSecretKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CBTProductDeclareSecretKey { get; set; }
    }
}
