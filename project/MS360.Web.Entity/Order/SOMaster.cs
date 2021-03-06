
using MS.Enum;
using MS360.Web.Entity.Common;
using MS360.Web.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;


namespace MS360.Web.Entity.Order
{
    /// <summary>
    /// 订单主信息
    /// </summary>
    public class SOMaster
    {

        /// <summary>
        /// 系统编号，也即是订单ID
        /// </summary>
        public int SysNo { get; set; }


        /// <summary>
        /// 顾客系统编号
        /// </summary>
        public int CustomerSysNo { get; set; }


        /// <summary>
        /// 第三方订单ID
        /// </summary>
        public string ThirdSOID { get; set; }


        /// <summary>
        /// 订单客户端来源
        /// </summary>
        public ClientSource ClientSource { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public DateTime SODate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SODateStr { get { return SODate.ToString("yyyy-MM-dd HH:mm:ss"); } }


 

        /// <summary>
        /// 配送类型
        /// </summary>
        public string ShipTypeID { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public string ShipTypeName { get; set; }
        /// <summary>
        /// 支付类型
        /// </summary>
        public string PayTypeID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PayTypeName { get; set; }

        /// <summary>
        /// 仓库ID
        /// </summary>
        public string StockID { get; set; }


        /// <summary>
        /// 业务类型，以后可扩展；1=餐饮美食,2=酒店住宿,3=旅游休闲,4=生活服务
        /// </summary>
        public BizType BizType { get; set; }


        /// <summary>
        /// 贸易类型：0=普通贸易，1=跨境自贸，2=跨境直邮
        /// </summary>
        public TradeType TradeType { get; set; }


        /// <summary>
        /// 订单类型：0=普通订单，1=团购订单，2=抢购订单，3=预售订单
        /// </summary>
        public SOType SOType { get; set; }


        /// <summary>
        /// 销售时支付模式，0=款到发货，1=货到付款，2=订金模式
        /// </summary>
        public PayMode PayMode { get; set; }


        /// <summary>
        /// 商品原始总额
        /// </summary>
        public decimal ProductOriginAmt { get; set; }


        /// <summary>
        /// 运费
        /// </summary>
        public decimal ShippingOriginAmt { get; set; }


        /// <summary>
        /// 税费
        /// </summary>
        public decimal TaxAmt { get; set; }


        /// <summary>
        /// 手续费
        /// </summary>
        public decimal CommissionAmt { get; set; }


        /// <summary>
        /// 商品总折扣
        /// </summary>
        public decimal ProductDiscountAmt { get; set; }


        /// <summary>
        /// 优惠券抵扣
        /// </summary>
        public decimal CouponDiscountAmt { get; set; }


        /// <summary>
        /// 运费总折扣
        /// </summary>
        public decimal ShippingDiscountAmt { get; set; }


        /// <summary>
        /// 总应付金额
        /// </summary>
        public decimal TotalPayAbleAmount { get; set; }


        /// <summary>
        /// 现金应付金额
        /// </summary>
        public decimal CashPayAbleAmount { get; set; }


        /// <summary>
        /// 积分支付
        /// </summary>
        public decimal PointPayAmount { get; set; }


        /// <summary>
        /// 账户余额支付
        /// </summary>
        public decimal BalancePayAmount { get; set; }


        /// <summary>
        /// 礼品卡支付
        /// </summary>
        public decimal GiftCardPayAmount { get; set; }


        /// <summary>
        /// 消耗的积分
        /// </summary>
        public int ConsumedPoint { get; set; }


        /// <summary>
        /// 收货地区
        /// </summary>
        public int? ReceiveAreaSysNo { get; set; }


        /// <summary>
        /// 收货人
        /// </summary>
        public string ReceiveContact { get; set; }


        /// <summary>
        /// 收货电话
        /// </summary>
        public string ReceivePhone { get; set; }


        /// <summary>
        /// 收货地址
        /// </summary>
        public string ReceiveAddress { get; set; }


        /// <summary>
        /// 收货邮编
        /// </summary>
        public string ReceiveZipCode { get; set; }


        /// <summary>
        /// 冻结标记
        /// </summary>
        public int HoldMark { get; set; }


        /// <summary>
        /// 冻结时间
        /// </summary>
        public DateTime? HoldDate { get; set; }


        /// <summary>
        /// 冻结说明
        /// </summary>
        public string HoldMemo { get; set; }


        /// <summary>
        /// 购物车ID
        /// </summary>
        public string ShoppingCartID { get; set; }


        /// <summary>
        /// 货币Code
        /// </summary>
        public string CurrencyCode { get; set; }


        /// <summary>
        /// 订单状态
        /// </summary>
        public SOStatus SOStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SOStatusStr { get { return EnumHelper.GetDescription(SOStatus); } }

        /// <summary>
        /// 发票类型。目前只提供普通发票
        /// </summary>
        public InvoiceType InvoiceType { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string CustomerMemo { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string UserMemo { get; set; }


        /// <summary>
        /// 渠道ID
        /// </summary>
        public string ChannelID { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public string InvoiceHeader { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public List<SOItem> Items { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<SODiscountMaster> DiscountList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DeliveryTrackingNumber { get; set; }

        /// <summary>
        /// 销售员编号
        /// </summary>
        public int? SalerSysNo { get; set; }
 
    }
}
