using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS360.Web.Enums
{
    public enum ProductStatus
    {
        [Description("初始")]
        Init = 0,
        [Description("上架")]
        Online = 10,
        [Description("上架不展示")]
        OnlineNotShow = 11,
        [Description("下架")]
        Offline = 20,
        [Description("作废")]
        Void = -1,

    }

    public enum BizType
    {
        [Description("百货商品")]
        Goods = 0,
        [Description("美容服务")]
        Service = 1

    }

    public enum PropertyType
    {
        [Description("一般属性")]
        Common = 0,
        [Description("分组属性")]
        Group = 1,

    }
    public enum ValueSetMode
    {
        [Description("文本框")]
        TextBox = 0,
        [Description("下拉列表框")]
        DropdownList = 1,
        [Description("日期选择")]
        DatePicker = 2,

    }
    public enum TradeType
    {
        [Description("普通")]
        Common = 0,
        [Description("跨境")]
        FTA = 1,
        [Description("跨境")]
        DirectMail = 2,

    }
    public enum PayMode
    {
        [Description("款到发货")]
        FirstPayment = 0,
        [Description("货到付款")]
        FirstDelivery = 1,
        [Description("两种都支持")]
        Both = 2,

    }

}
