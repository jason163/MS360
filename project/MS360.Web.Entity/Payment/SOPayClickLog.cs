using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MS360.Web.Entity
{
    /// <summary>
    /// 支付点击日志
    /// </summary>
    public class SOPayClickLog
    {
        /// <summary>
        /// 系统编号
        /// </summary>
        public int SysNo { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public int SOSysNo { get; set; }

        /// <summary>
        /// 支付方式编号
        /// </summary>
        public string PayTypeSysNo { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public int CustomerSysNo { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public DateTime ClickPayTime { get; set; }
    }
}
