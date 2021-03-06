using MS360.Web.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;


namespace MS360.Web.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class RMAMaster
    {

        /// <summary>
        /// 系统编号，也即是采购单ID
        /// </summary>
        public int SysNo { get; set; }


        /// <summary>
        /// 订单编号
        /// </summary>
        public int SOSysNo { get; set; }


        /// <summary>
        /// 顾客系统编号
        /// </summary>
        public int CustomerSysNo { get; set; }


        /// <summary>
        /// 售后类型，退款，换货
        /// </summary>
        public RMAType RMAType { get; set; }


        /// <summary>
        /// 售后状态，对于退货，以退款完成为结束；对于换货，以重新发货为结束。
        /// </summary>
        public RMAStatus RMAStatus { get; set; }


        /// <summary>
        /// 联系人，售后Customer方的联系人
        /// </summary>
        public string RMAContract { get; set; }


        /// <summary>
        /// 联系电话，售后Customer方的联系电话
        /// </summary>
        public string RMAPhone { get; set; }


        /// <summary>
        /// 顾客留言
        /// </summary>
        public string CustomerNote { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Pics { get; set; }


        /// <summary>
        /// 客服备注
        /// </summary>
        public string CSNote { get; set; }


        /// <summary>
        /// 货币Code
        /// </summary>
        public string RefoundCurrencyCode { get; set; }


        /// <summary>
        /// 退款方式，0=银行转账，需要输入银行等相关信息，1=网管直退，根据订单PayTypeID进行转账
        /// </summary>
        public RefundType? RefundType { get; set; }


        /// <summary>
        /// 退货快递类型
        /// </summary>
        public string ReturnShipTypeID { get; set; }


        /// <summary>
        /// 退货快递单号
        /// </summary>
        public string ReturnShipTrackingNumber { get; set; }

        /// <summary>
        /// 商品
        /// </summary>
        public List<RMAItem> Items { get; set; }

        /// <summary>
        /// 退换货类型
        /// </summary>
        //public string RMATypeText { get { return RMAType.GetDescription(); } }

        /// <summary>
        /// 售后状态
        /// </summary>
        //public string RMAStatusText { get { return RMAStatus.GetDescription(); } }


        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? InDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string InDateText { get { return InDate.HasValue ? InDate.Value.ToString() : ""; } }

        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime? AuditDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AuditDateText { get { return AuditDate.HasValue ? AuditDate.Value.ToString() : ""; } }

        /// <summary>
        /// 收货日期
        /// </summary>
        public DateTime? CollectDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CollectDateText { get { return CollectDate.HasValue ? CollectDate.Value.ToString() : ""; } }
        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// 退款中记录的时间
        /// </summary>
        public DateTime? RefundTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RefundTimeText { get { return RefundTime.HasValue ? RefundTime.Value.ToString() : ""; } }

        /// <summary>
        /// 退款日期
        /// </summary>
        public DateTime? RefundDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RefundDateText { get { return RefundDate.HasValue ? RefundDate.Value.ToString() : ""; } }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? EditDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EditDateText { get { return EditDate.HasValue ? EditDate.Value.ToString() : ""; } }
        /// <summary>
        /// 
        /// </summary>
        public List<string> Pictures { get; set; }

    }
}
