
using MS.Application.EntityBasic;

namespace MS360.Web.Entity
{
    /// <summary>
    /// 订单查询条件
    /// </summary>
    public class QF_SO : QueryFilter
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int CustomerSysNo { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public int? SOStatus { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class SOStatistics
    {
        /// <summary>
        /// 
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int SOStatus { get; set; }
    }
}
