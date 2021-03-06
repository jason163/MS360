
using MS.Application.EntityBasic;
using MS360.Web.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;


namespace MS360.Web.Entity
{
    /// <summary>
    /// 优惠券信息
    /// </summary>
    public class Coupon
    {

        /// <summary>
        /// 系统编号
        /// </summary>
        public int SysNo { get; set; }


        /// <summary>
        /// 优惠券名称
        /// </summary>
        public string CouponName { get; set; }


        /// <summary>
        /// 优惠券面额
        /// </summary>
        public decimal FaceValue { get; set; }


        /// <summary>
        /// 领取数量
        /// </summary>
        public int? GetCount { get; set; }


        /// <summary>
        /// 使用数量
        /// </summary>
        public int? UseCount { get; set; }


        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }


        /// <summary>
        /// 状态
        /// </summary>
        public CouponStatus Status { get; set; }


        /// <summary>
        /// 生成方式 
        /// </summary>
        public CouponGenerateWay CouponGenerateWay { get; set; }


        /// <summary>
        /// 领取订单金额限制
        /// </summary>
        public decimal? GetOrderAmountLimit { get; set; }


        /// <summary>
        /// 领取开始时间
        /// </summary>
        public DateTime? GetStartDate { get; set; }


        /// <summary>
        /// 领取结束时间
        /// </summary>
        public DateTime? GetEndDate { get; set; }


        /// <summary>
        /// 领取商品限制类型
        /// </summary>
        public CouponProductLimitType? ProductLimitType { get; set; }


        /// <summary>
        /// 类别的叶子节点，和商品挂的category一致
        /// </summary>
        public string GetProductCategorySysNos { get; set; }


        /// <summary>
        /// 领取限制商品ID
        /// </summary>
        public string GetProductSysNos { get; set; }


        /// <summary>
        /// 领取数量限制
        /// </summary>
        public CouponGetQtyLimit GetQtyLimit { get; set; }


        /// <summary>
        /// 发放数量
        /// </summary>
        public int? GenerateQty { get; set; }


        /// <summary>
        /// 使用时间限制类型
        /// </summary>
        public CouponUseType UseDateLimitType { get; set; }


        /// <summary>
        /// 使用开始时间
        /// </summary>
        public DateTime? UseStartDate { get; set; }


        /// <summary>
        /// 使用结束时间
        /// </summary>
        public DateTime? UseEndDate { get; set; }


        /// <summary>
        /// 使用天数限制
        /// </summary>
        public int? UseLimitDays { get; set; }


        /// <summary>
        /// 使用限制商品目录ID
        /// </summary>
        public string UseProductCategorySysNos { get; set; }


        /// <summary>
        /// 使用限制商品品牌ID
        /// </summary>
        public string UseProductBrandSysNos { get; set; }


        /// <summary>
        /// 使用最低订单金额限制
        /// </summary>
        public decimal? UseOrderAmountLimit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int MerchantSysNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int HasReceived { get; set; }

    }
    /// <summary>
    /// 优惠券获得
    /// </summary>
    public class CouponReceivingRecord
    {

        /// <summary>
        /// 物理ID 
        /// </summary>
        public int SysNo { get; set; }


        /// <summary>
        /// 优惠券ID
        /// </summary>
        public int CouponSysNo { get; set; }


        /// <summary>
        /// 优惠券名称 
        /// </summary>
        public string CouponName { get; set; }


        /// <summary>
        /// 优惠券编号 
        /// </summary>
        public string CouponNo { get; set; }


        /// <summary>
        /// 优惠券面额 
        /// </summary>
        public decimal FaceValue { get; set; }


        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }

        private DateTime? _receivingDate;

        /// <summary>
        /// 领取日期
        /// </summary>
        public DateTime? ReceivingDate
        {
            get { return _receivingDate; }
            set
            {
                _receivingDate = value;
                Set_UseEndDate();
            }
        }


        /// <summary>
        /// 状态 
        /// </summary>
        public CouponReceivingStatus Status { get; set; }


        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserSysNo { get; set; }


        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }


        /// <summary>
        /// 生成方式  
        /// </summary>
        public CouponGenerateWay? CouponGenerateWay { get; set; }

        private CouponUseType _useDateLimitType;

        /// <summary>
        /// 使用时间限制类型 
        /// </summary>
        public CouponUseType UseDateLimitType
        {
            get
            {
                return _useDateLimitType;
            }
            set
            {
                _useDateLimitType = value;
                Set_UseEndDate();
            }
        }
        private void Set_UseEndDate()
        {
            if (UseDateLimitType == CouponUseType.Days)
            {
                if(!ReceivingDate.HasValue)
                {
                    _useEndDate = null;
                }
                else
                {
                    _useEndDate = ReceivingDate.GetValueOrDefault().AddDays(UseLimitDays.GetValueOrDefault());
                }
                
            }
            else if (UseDateLimitType == CouponUseType.All)
            {
                _useEndDate = null;
            }
        }


        /// <summary>
        /// 使用开始时间  
        /// </summary>
        public DateTime? UseStartDate { get; set; }

        private DateTime? _useEndDate;

        /// <summary>
        /// 使用结束时间  
        /// </summary>
        public DateTime? UseEndDate
        {
            get
            {
                return _useEndDate;
            }
            set
            {
                _useEndDate = value;
                Set_UseEndDate();
            }
        }

        private int? _useLimitDays;

        /// <summary>
        /// 使用天数限制
        /// </summary>
        public int? UseLimitDays
        {
            get { return _useLimitDays; }
            set
            {
                _useLimitDays = value;
                Set_UseEndDate();
            }
        }


        private string useProductCategorySysNos;
        /// <summary>
        /// 使用限制商品目录,多个之间用“,”隔开
        /// </summary>
        public string UseProductCategorySysNos
        {
            get { return useProductCategorySysNos; }
            set
            {
                useProductCategorySysNos = value;
                _seProductCategoryList = StringToIntList(useProductCategorySysNos, new char[] { ',' });
            }
        }
        private List<int> _seProductCategoryList;
        /// <summary>
        /// 使用限制商品目录ID
        /// </summary>
        public List<int> GetUseProductCategoryList
        {
            get
            {
                return _seProductCategoryList;
            }
        }


        private string _useProductBrandSysNos;
        /// <summary>
        /// 使用限制商品品牌ID  ,多个之间用“,”隔开
        /// </summary>
        public string UseProductBrandSysNos
        {
            get { return _useProductBrandSysNos; }
            set
            {
                _useProductBrandSysNos = value;
                _productBrandSysNoList = StringToIntList(_useProductBrandSysNos, new char[] { ',' });
            }
        }

        private List<int> StringToIntList(string input, char[] splitChar)
        {
            if (string.IsNullOrWhiteSpace(input)) return null;
            string[] s = input.Split(splitChar, StringSplitOptions.RemoveEmptyEntries);
            List<int> intList = null;
            if (s != null && s.Length > 0)
            {
                intList = new List<int>(s.Length);
                int i = 0;
                foreach (string t in s)
                {
                    if (int.TryParse(t, out i))
                    {
                        intList.Add(i);
                    }
                }
            }
            return intList;
        }

        private List<int> _productBrandSysNoList;
        /// <summary>
        /// 使用限制商品品牌ID
        /// </summary>
        public List<int> GetProductBrandSysNoList
        {
            get
            {
                return _productBrandSysNoList;
            }
        }

        /// <summary>
        /// 使用限制最低消费金额
        /// </summary>
        public decimal? UseOrderAmountLimit { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class QF_CouponReceivingRecord : QueryFilter
    {
        /// <summary>
        /// 
        /// </summary>
        public int CustomerSysNo { get; set; }
    }
    /// <summary>
    /// 优惠券使用
    /// </summary>
    public class CouponUseRecord
    {

        /// <summary>
        /// 系统编号
        /// </summary>
        public int SysNo { get; set; }


        /// <summary>
        /// 优惠券活动编号
        /// </summary>
        public int CouponSysNo { get; set; }


        /// <summary>
        /// 优惠券名称 
        /// </summary>
        public string CouponName { get; set; }


        /// <summary>
        /// 优惠券编号 
        /// </summary>
        public string CouponNo { get; set; }


        /// <summary>
        /// 订单编号
        /// </summary>
        public int OrderSysNo { get; set; }


        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserSysNo { get; set; }


        /// <summary>
        /// 优惠券面额 
        /// </summary>
        public decimal FaceValue { get; set; }


        /// <summary>
        /// 使用日期
        /// </summary>
        public DateTime UseDate { get; set; }


    }
}
