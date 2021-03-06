using MS360.Web.Enums;
using System;


namespace MS360.Web.Entity
{
    public class Customer_PointLog 
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
        /// 积分获取类型或扣减类型
        /// </summary>
        public PointLogType ? PointLogType { get; set; }


        /// <summary>
        /// 积分数量
        /// </summary>
        public int PointAmount { get; set; }


        /// <summary>
        /// 过期日期
        /// </summary>
        public DateTime? ExpireData { get; set; }


        /// <summary>
        /// 积分状态
        /// </summary>
        public PointStatus ?PointStatus { get; set; }


        /// <summary>
        /// 订单编号
        /// </summary>
        public int? OrderSysNo { get; set; }


        /// <summary>
        /// 操作类型
        /// </summary>
        public MS360.Web.Enums.Action? Action { get; set; }


        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }


    }
}
