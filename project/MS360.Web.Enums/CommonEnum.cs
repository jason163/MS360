using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS360.Web.Enums
{
    public enum CommonStatus
    {
        [Description("有效")]
        Actived = 1,
        [Description("无效")]
        DeActived = 0
    }
    public enum ClientSource
    {
        [Description("PC网站")]
        PC = 0,
        [Description("后台")]
        Backend = 1,
        [Description("M站点")]
        Msite = 2,
        [Description("Android")]
        Android = 3,
        [Description("IOS")]
        Iphone = 4,
        [Description("WeiXin")]
        Wechat = 5,
        [Description("第三方分销")]
        ThirdDistribute = 5
    }

    public enum ImageSize
    {
        P60,
        P80,
        P90,
        P100,
        P120,
        P130,
        P140,
        P160,
        P200,
        P220,
        P240,
        P450,
        P800
    }

    public enum BizObjectType
    {
        [Description("订单")]
        SO
    }

    public enum BizOperationType
    {
       
    }

    /// <summary>
    /// 客户端类型
    /// </summary>
    public enum ClientType
    {
        [Description("MSite")]
        Msite = 0,
        //[Description("后台")]
        //Backend = 1,
        //[Description("M站点")]
        //Msite = 2,
        [Description("Android")]
        Android = 3,
        [Description("IPhone")]
        IPhone = 4,
        [Description("WeiXin")]
        Wechat = 5
    }
}
