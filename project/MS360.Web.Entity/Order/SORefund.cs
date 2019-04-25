using MS360.Web.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS360.Web.Entity.Order
{
    /// <summary>
    /// 
    /// </summary>
    public class SORefund
    {
        /// <summary>
        /// 退款单单号
        /// </summary>
        public int SysNo { get; set; }

        /// <summary>
        /// 支付类型
        /// </summary>
        public string PayTypeID { get; set; }

        /// <summary>
        /// 单据编号
        /// SO.AO:订单编号 RO:RMA编号
        /// </summary>
        public int BillNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SOIncomeType SOIncomeType { get; set; }


        /// <summary>
        /// 订单编号
        /// </summary>
        public int SOSysNo { get; set; }

        /// <summary>
        /// 退款金额
        /// </summary>
        /// <example>
        /// 退款金额的单位是分。
        /// 如果退款金额 103.21 元,那么退款金额就是10321
        /// </example>
        public decimal CashPayAmount { get; set; }

        /// <summary>
        /// 退款流水号
        /// </summary>
        public string ExternalKey { get; set; }

        /// <summary>
        ///  退款单状态
        /// </summary>
        public SOIncomeBillStatus SOIncomeBillStatus { get; set; }
    }
}
