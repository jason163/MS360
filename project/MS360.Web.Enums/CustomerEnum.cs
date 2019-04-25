using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS360.Web.Enums
{
    public enum CustomerType
    {
        [Description("个人用户")]
        Person = 0,
        [Description("企业用户")]
        Merchant = 1
    }
    /// <summary>
    /// 加密模式
    /// </summary>
    public enum EncryptMode
    {
        /// <summary>
        /// SHA1,并使用Salt，该方法为默认的加密方式
        /// </summary>
        [Description("SHA1加密")]
        SHA1 = 0,
        /// <summary>
        /// MD5加密算法，为了兼容KJT外部系统导入的密码
        /// </summary>
        [Description("MD5加密")]
        MD5 = 1
    }
    public enum RegClientSource
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
    public enum Gender
    {
        [Description("女")]
        Woman = 0,
        [Description("男")]
        Man = 1,
        [Description("保密")]
        NotSet = -1,

    }

    /// <summary>
    /// 充值请求来源
    /// </summary>
    public enum RechargeSource
    {
        [Description("线上充值")]
        Online = 0,
        [Description("线下充值")]
        Offline = 1
    }

    /// <summary>
    /// 充值请求状态
    /// </summary>
    public enum RechargeStatus
    {
        [Description("未支付")]
        Init=0,
        [Description("充值成功")]
        Confirmed = 10,
        [Description("充值失败")]
        Void = -3
    }
    public enum NursingDiaryStatus
    {
        [Description("待确认")]
        NotConsum = 0,
        [Description("已确认")]
        Consum = 1
    }
    public enum RequestType
    {
        [Description("充值")]
        Recharge = 1,
        [Description("提现")]
        Withdrawal = -1
    }
    public enum PointLogType
    {
        [Description("注册送积分")]
        Register_Point = 0,
        [Description("下单送积分")]
        Order_Point = 1
    }
    /// <summary>
    /// 来源
    /// </summary>
    public enum Source
    {
        [Description("前台")]
        app = 0,
        [Description("后台")]
        ecc = 1
    }
    public enum PointStatus
    {
        [Description("有效")]
        Actived = 1,
        [Description("无效")]
        DeActived = 0
    }

    public enum Action
    {
        [Description("增加")]
        Add = 1,
        [Description("扣减")]
        Reduce = 0
    }

}
