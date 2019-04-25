using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS360.Web.Enums
{
    public enum RMAType
    {
        [Description("退货")]
        Refund = 0,
        [Description("换货")]
        Replace = 1,

    }
    public enum RMAStatus
    {
        [Description("待处理")]
        Init = 0,
        [Description("审核通过")]
        Audit = 10,
        [Description("确认收货")]
        Received = 50,
        [Description("售后完成")]
        Complete = 100,
        [Description("作废")]
        Void = -1,

    }
    public enum RefundType
    {
        [Description("银行转账")]
        Bank = 0,
        [Description("网管直退")]
        DirectRefund = 1,

    }

}
