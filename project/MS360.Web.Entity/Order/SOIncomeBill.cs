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
    public class SOIncomeBill
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
        /// 收款单类型，分SO和AO
        /// </summary>
        public SOIncomeType SOIncomeType { get; set; }


        /// <summary>
        /// 支付类型
        /// </summary>
        public string PayTypeID { get; set; }


        /// <summary>
        /// 总应收金额
        /// </summary>
        public decimal TotalPayAbleAmount { get; set; }


        /// <summary>
        /// 现金支付金额
        /// </summary>
        public decimal CashPayAmount { get; set; }


        /// <summary>
        /// 积分支付
        /// </summary>
        public decimal PointPayAmount { get; set; }


        /// <summary>
        /// 账户余额支付
        /// </summary>
        public decimal BalancePayAmount { get; set; }


        /// <summary>
        /// 礼品卡支付
        /// </summary>
        public decimal GiftCardPayAmount { get; set; }


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
        public SOIncomeBillStatus SOIncomeBillStatus { get; set; }


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
