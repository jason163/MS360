using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS360.Web.Enums
{
    /// <summary>
    /// 支付方式
    /// </summary>
    public enum NetPayType
    {
        [Description("银行在线支付")]
        BankPayType = 1,

        [Description("支付平台支付")]
        PlatformPayType = 2,

        [Description("存储卡支付")]
        DebitCartPayType = 3,
    }
}
