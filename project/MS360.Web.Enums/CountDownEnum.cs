using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS360.Web.Enums
{
    public enum CountDownType
    {
        [Description("普通模式")]
        Normal = 0,
        [Description("循环模式")]
        Loop = 1,

    }
    public enum CountDownStatus
    {
        [Description("初始化")]
        Init = 0,
        [Description("提交审核")]
        WaitAudit = 1,
        [Description("审核通过")]
        AuditPass = 10,
        [Description("审核拒绝")]
        AuditRefuse = 11,
        [Description("作废")]
        Void = -1,

    }

}
