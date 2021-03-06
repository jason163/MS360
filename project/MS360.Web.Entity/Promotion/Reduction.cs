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
    public class Reduction 
    {

        /// <summary>
        /// 系统编号
        /// </summary>
        public int? SysNo { get; set; }


        /// <summary>
        /// 活动名称
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 应用方式
        /// </summary>
        public ReductionUsableRange UsableRange { get; set; }


        /// <summary>
        /// 状态
        /// </summary>
        public ReductionStatus Status { get; set; }


        /// <summary>
        /// 开始时间  
        /// </summary>
        public DateTime? StartDate { get; set; }


        /// <summary>
        /// 结束时间  
        /// </summary>
        public DateTime? EndDate { get; set; }


    }
    /// <summary>
    /// 
    /// </summary>
    public class ReductionRule  
    {

        /// <summary>
        /// 
        /// </summary>
        public int? SysNo { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public int ReductionSysNo { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public decimal? Target { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public int? Rate { get; set; }


        /// <summary>
        /// 规则单位
        /// </summary>
        public ReductionRuleUnit RuleUnit { get; set; }


        /// <summary>
        /// 打折方式
        /// </summary>
        public ReductionType ReduceType { get; set; }


    }
    /// <summary>
    /// 
    /// </summary>
    public class ReductionProduct  
    {

        /// <summary>
        /// 系统编号
        /// </summary>
        public int SysNo { get; set; }


        /// <summary>
        /// 活动编号
        /// </summary>
        public int ReductionSysNo { get; set; }


        /// <summary>
        /// 商品编号
        /// </summary>
        public int ProductSysNo { get; set; }


    }
}
