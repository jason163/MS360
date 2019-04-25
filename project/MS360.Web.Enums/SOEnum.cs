using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS360.Web.Enums
{
    public enum SOType
    {
        [Description("普通订单")]
        Common = 0,
        [Description("团购订单")]
        GroupBuy = 1,
        [Description("抢购订单")]
        Countdown = 2,
        [Description("预售订单")]
        PreSale = 3,

    }
    public enum SOStatus
    {
        [Description("待支付")]
        Init = 0,
        [Description("部分支付")]
        Part = 5,
        [Description("待出库")]
        AuditPass = 10,
        [Description("申报通关中")]
        Declared = 60,
        [Description("已发货")]
        OutCustom = 65,
        [Description("订单完成")]
        Close = 100,
        [Description("已作废")]
        Void = -1,


    }


    public enum InvoiceType
    {
        [Description("普通发票")]
        Common = 0,
        [Description("增值发票")]
        VATInvoice = 1,
    }

    public enum AuthIDCardType
    {
        [Description("身份证")]
        IdentityCard = 0,
        [Description("护照")]
        Passport = 1,

    }

    public enum PromotionType
    {
        /// <summary>
        /// 限时抢购
        /// </summary>
        [Description("限时抢购")]
        Countdown = 1,
        /// <summary>
        /// 满减
        /// </summary>
        [Description("满减")]
        Reduction = 2,
        [Description("套餐")]
        Combo = 3,
        [Description("优惠券")]
        Coupon = 20,
        [Description("运费")]
        Shipping = 90,

    }


    public enum SOItemType
    {
        [Description("普通商品")]
        Common = 0,
        [Description("赠品")]
        Gift = 1,
        [Description("加购商品")]
        AddBuy = 2,
    }


    public enum PaySource
    {
        [Description("在线付款")]
        Online = 0,
        [Description("线下付款")]
        Offline = 1,
        [Description("后台创建")]
        Backend = 2,

    }
    public enum SONetPayStatus
    {
        [Description("待确认")]
        Init = 0,
        [Description("已确认")]
        Confirmed = 10,
        [Description("已作废")]
        Void = -1,

    }

    public enum SOIncomeType
    {
        [Description("正收款单")]
        SO = 0,
        [Description("负收款单")]
        AO = 1,
        [Description("RMA负收款单")]
        RMA = 2

    }
    public enum SOIncomeBillStatus
    {
        [Description("待确认")]
        Init = 0,
        [Description("已确认")]
        Confirmed = 10,
        [Description("退款中")]
        Processing = 20,
        [Description("网关退款中")]
        GatewayProcessing = 25,
        [Description("退款失败")]
        Failed = 30,
        [Description("退款成功")]
        Success = 50,
        [Description("已作废")]
        Void = -1
    }

    //public enum StorageType
    //{
    //    [Description("平台仓储")]
    //    PlatformStock = 0,
    //    [Description("商家仓储")]
    //    SellerStock = 1,

    //}
    //public enum Type
    //{
    //    [Description("验证手机，注册")]
    //    VerifyPhone = 0,
    //    [Description("修改密码")]
    //    AlertUpdatePassword = 3,
    //    [Description("团购")]
    //    VirualGroupBuy = 4,

    //}

}
