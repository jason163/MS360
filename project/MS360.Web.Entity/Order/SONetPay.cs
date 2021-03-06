using MS360.Web.Entity.Common;
using MS360.Web.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
 

namespace MS360.Web.Entity.Order
{
    /// <summary>
    /// 
    /// </summary>
    public class SONetPay 
    {
        /// <summary>
        /// 系统编号
        /// </summary>
        public int SysNo { get; set; }


        /// <summary>
        /// 订单编号
        /// </summary>
        public int SOSysNo { get; set; }


        /// <summary>
        /// 支付类型
        /// </summary>
        public string PayTypeID { get; set; }


        /// <summary>
        /// 支付金额
        /// </summary>
        public decimal PayAmount { get; set; }


        /// <summary>
        /// 支付流水号
        /// </summary>
        public string BankTrackingNumber { get; set; }


        /// <summary>
        /// 付款来源
        /// </summary>
        public PaySource PaySource { get; set; }


        /// <summary>
        /// 货币Code
        /// </summary>
        public string CurrencyCode { get; set; }


        /// <summary>
        /// 状态，如果是款到发货，则收到银行回执时，写入就是已确认；如果是货到付款，则创建订单时，先写入一条待确认的支付记录，等收款时再更新为已确认。
        /// </summary>
        public SONetPayStatus SONetPayStatus { get; set; }


        /// <summary>
        /// 确认人编号
        /// </summary>
        public int? ConfirmUserSysNo { get; set; }


        /// <summary>
        /// 确认人
        /// </summary>
        public string ConfirmUserName { get; set; }


        /// <summary>
        /// 确认时间
        /// </summary>
        public DateTime? ConfirmDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime InDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int InUserSysNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string InUserName { get; set; }

    }
}
