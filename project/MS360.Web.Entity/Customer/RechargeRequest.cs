
using MS360.Web.Enums;
using System;

namespace MS360.Web.Entity
{
    /// <summary>
    /// 用户充值请求
    /// </summary>
    public class RechargeRequest
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
        /// 充值来源
        /// </summary>
        public RechargeSource RechargeSource { get; set; }
        

        /// <summary>
        /// 充值状态
        /// </summary>
        public RechargeStatus RechargeStatus { get; set; }

        /// <summary>
        /// 支付公司流水号
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public RequestType RechargeAction { get; set; }
        
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
        public int InUserSysNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int CompanyCode { get; set; }
    }
}
