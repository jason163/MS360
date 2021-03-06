using MS360.Web.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;


namespace MS360.Web.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomerInfo
    {

        /// <summary>
        /// 系统编号
        /// </summary>
        public int SysNo { get; set; }


        /// <summary>
        /// 顾客ID
        /// </summary>
        public string CustomerID { get; set; }


        /// <summary>
        /// 手机号码
        /// </summary>
        public string MobliePhone { get; set; }


        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }


        /// <summary>
        /// Email已验证
        /// </summary>
        public int? IsEmailVerify { get; set; }


        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName { get; set; }


        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }


        /// <summary>
        /// 密码盐子
        /// </summary>
        public string PasswordSalt { get; set; }


        /// <summary>
        /// 头像
        /// </summary>
        public string HeadImage { get; set; }


        /// <summary>
        /// 注册的终端类型
        /// </summary>
        public ClientType? RegClientSource { get; set; }


        /// <summary>
        /// 性别，0=女，1=男
        /// </summary>
        public Gender? Gender { get; set; }


        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 出生日期格式化
        /// </summary>
        public string BirthdayStr
        {
            get
            {
                if (Birthday.HasValue)
                {
                    return Birthday.Value.ToString("yyyy-MM-dd");
                }
                return string.Empty;
            }
        }

        /// <summary>
        /// 总积分
        /// </summary>
        public int? TotalPoint { get; set; }

        /// <summary>
        /// 有效积分
        /// </summary>
        public int? ValidPoint { get; set; }

        /// <summary>
        /// 用户账户余额
        /// </summary>
        public decimal? Balance { get; set; }
    }
    /// <summary>
    /// 第三方授权用户
    /// </summary>
    public class CustomerMapping
    {

        /// <summary>
        /// 顾客系统编号
        /// </summary>
        public int CustomerSysNo { get; set; }


        /// <summary>
        /// 用户标识
        /// </summary>
        public string OpenID { get; set; }

        /// <summary>
        /// 用户唯一标识
        /// </summary>
        public string UnionID { get; set; }

        /// <summary>
        /// 第三方渠道 0:微信
        /// </summary>
        public int ThirdType { get; set; }


        /// <summary>
        /// 是否订阅
        /// </summary>
        public int? ISSubscribe { get; set; }


    }
}
