
using MS.Application.EntityBasic;
using MS.Enum;
using MS360.Web.Enums;
using System;

namespace MS360.Web.Entity
{
    /// <summary>
    /// 充值
    /// </summary>
    public class QF_Recharge : QueryFilter
    {

        /// <summary>
        /// 系统编号
        /// </summary>
        public int SysNo { get; set; }


        /// <summary>
        /// 顾客系统编号
        /// </summary>
        public int CustomerSysNo { get; set; }
    }
    /// <summary>
    /// 充值
    /// </summary>
    public class QR_Recharge
    {
        /// <summary>
        /// 系统编号
        /// </summary>
        public int SysNo { get; set; }


        /// <summary>
        /// 顾客系统编号
        /// </summary>
        public int CustomerSysNo { get; set; }


        /// <summary>
        /// 充值金额
        /// </summary>
        public decimal RechargeAmount { get; set; }


        /// <summary>
        /// 支付方式
        /// </summary>
        public string PayTypeID { get; set; }

        /// <summary>
        /// 支付方式
        /// </summary>
        public string PayTypeName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RechargeSource? RechargeSource { get; set; }


        /// <summary>
        /// 充值状态
        /// </summary>
        public RechargeStatus? RechargeStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String RechargeStatusStr { get { return EnumHelper.GetDescription(RechargeStatus); } }

        /// <summary>
        /// 支付公司流水号
        /// </summary>
        public string SerialNumber { get; set; }


        /// <summary>
        /// 操作类型
        /// </summary>
        public RequestType? RechargeAction { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String RechargeActionStr { get { return EnumHelper.GetDescription(RechargeAction); } }


        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// 充值日期
        /// </summary>
        public DateTime InDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string InDateStr
        {
            get
            {
                return InDate.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int InUserSysNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CompanyCode { get; set; }

    }

    /// <summary>
    /// 消费
    /// </summary>
    public class QF_Consum : QueryFilter
    {
        /// <summary>
        /// 系统编号
        /// </summary>
        public int SysNo { get; set; }


        /// <summary>
        /// 顾客系统编号
        /// </summary>
        public int CustomerSysNo { get; set; }
    }
    /// <summary>
    /// 消费
    /// </summary>
    public class QR_Consum
    {
        /// <summary>
        /// 系统编号
        /// </summary>
        public int SysNo { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public int OrderSysNo { get; set; }
        /// <summary>
        /// 商品编号
        /// </summary>
        public int ProductSysNo { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 商品总服务次数
        /// </summary>
        public int UseTime { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public NursingDiaryStatus NursingDiaryStatus { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string NursingDiaryStatusStr { get { return EnumHelper.GetDescription(NursingDiaryStatus); } }

        /// <summary>
        /// 本次消费次数
        /// </summary>
        public int UsedQuantity { get; set; }
        /// <summary>
        /// 剩余次数
        /// </summary>
        public int Remainder { get; set; }

        /// <summary>
        /// 总共已经消费次数
        /// </summary>
        public int TotalUsedQuantity { get; set; }

        /// <summary>
        /// 护理日期
        /// </summary>
        public DateTime NursingDate { get; set; }
        /// <summary>
        /// 护理日期
        /// </summary>
        public string NursingDateStr { get { return NursingDate.ToString("yyyy-MM-dd HH:mm:ss"); } }

        /// <summary>
        /// 护理顾客评分
        /// </summary>
        public int NursingDiaryRate { get; set; }
    }
    /// <summary>
    /// 消费记录
    /// </summary>
    public class NursingDiaryItem { 

        /// <summary>
        /// 系统编号
        /// </summary>
        public int SysNo { get; set; }


        /// <summary>
        /// 护理日志编号
        /// </summary>
        public int NursingDiarySysNo { get; set; }


        /// <summary>
        /// 商品编号
        /// </summary>
        public int ProductSysNo { get; set; }


        /// <summary>
        /// 商品ID
        /// </summary>
        public string ProductID { get; set; }


        /// <summary>
        /// 已消费次数
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// 护理状态
        /// </summary>
        public NursingDiaryStatus NursingDiaryStatus{ get; set; }


    }
    /// <summary>
    /// 预约记录
    /// </summary>
    public class QF_ReservationRecords : QueryFilter
    {
        /// <summary>
        /// 系统编号
        /// </summary>
        public int SysNo { get; set; }


        /// <summary>
        /// 顾客系统编号
        /// </summary>
        public int CustomerSysNo { get; set; }
    }
    /// <summary>
    /// 预约记录
    /// </summary>
    public class QR_ReservationRecords
    {
        /// <summary>
        /// 系统编号
        /// </summary>
        public int SysNo { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public int OrderSysNo { get; set; }
        /// <summary>
        /// 商品编号
        /// </summary>
        public int ProductSysNo { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public NursingDiaryStatus ReservationStatus { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string ReservationStatusStr { get { return EnumHelper.GetDescription(ReservationStatus); } }

        /// <summary>
        /// 编号
        /// </summary>
        public int InUserSysNo { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        public Source Source { get; set; }

        /// <summary>
        /// 护理日期
        /// </summary>
        public DateTime ReservationDate { get; set; }
        /// <summary>
        /// 护理日期
        /// </summary>
        public string ReservationDateStr { get { return ReservationDate.ToString("yyyy-MM-dd HH:mm"); } }
        /// <summary>
        /// 客户编号
        /// </summary>
        public int CustomerSysNo { get; set; }
    }
   /// <summary>
   /// 预约商品列表
   /// </summary>
    public class GetReservationProduct
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public int OrderSysNo { get; set; }
        /// <summary>
        /// 商品编号
        /// </summary>
        public int ProductSysNo { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }

    }
}
