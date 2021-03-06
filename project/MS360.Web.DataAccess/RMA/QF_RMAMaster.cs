using MS.Application.EntityBasic;
using MS.Enum;
using MS360.Web.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MS360.Web.Entity
{
    public class QF_RMAMaster  : QueryFilter
    {

        /// <summary>
        /// 订单编号
        /// </summary>
        public int? SOSysNo { get; set; }


        /// <summary>
        /// 顾客系统编号
        /// </summary>
        public int? CustomerSysNo { get; set; }


    }

	public class QR_RMAMaster
    {

        /// <summary>
        /// 系统编号，也即是采购单ID
        /// </summary>
        public int? SysNo { get; set; }


        /// <summary>
        /// 订单编号
        /// </summary>
        public int? SOSysNo { get; set; }


        /// <summary>
        /// 顾客系统编号
        /// </summary>
        public int? CustomerSysNo { get; set; }


        /// <summary>
        /// 售后类型，退款，换货
        /// </summary>
        public RMAType? RMAType { get; set; }


         /// <summary>
         /// 售后类型，退款，换货显示信息
         /// </summary>
         public String RMATypeStr { get { return EnumHelper.GetDescription(RMAType); }}

        /// <summary>
        /// 售后状态，对于退货，以退款完成为结束；对于换货，以重新发货为结束。
        /// </summary>
        public RMAStatus? RMAStatus { get; set; }


         /// <summary>
         /// 售后状态，对于退货，以退款完成为结束；对于换货，以重新发货为结束。显示信息
         /// </summary>
         public String RMAStatusStr { get { return EnumHelper.GetDescription(RMAStatus); }}

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
         /// 退款方式，0=银行转账，需要输入银行等相关信息，1=网管直退，根据订单PayTypeID进行转账显示信息
         /// </summary>
         public String RefundTypeStr { get { return EnumHelper.GetDescription(RefundType); }}

        /// <summary>
        /// 退货快递类型
        /// </summary>
        public string ReturnShipTypeID { get; set; }


        /// <summary>
        /// 退货快递单号
        /// </summary>
        public string ReturnShipTrackingNumber { get; set; }


    }
}

