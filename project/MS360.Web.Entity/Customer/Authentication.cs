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
    public class Authentication
    {
        /// <summary>
        /// 
        /// </summary>
        public int SysNo { get; set; }
        /// <summary>
        /// 用户系统编号
        /// </summary>
        public int CustomerSysNo { get; set; }


        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 身份证号码
        /// </summary>
        public string IDCardNumber { get; set; }


        /// <summary>
        /// 收件人电话
        /// </summary>
        public string PhoneNumber { get; set; }


        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BirthdayStr { get { return Birthday.HasValue ? Birthday.Value.ToString("yyyy-MM-dd") : ""; } }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }


        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }


        /// <summary>
        /// 性别
        /// </summary>
        public Gender? Gender { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int InUserSysNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string InUserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int EditUserSysNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EditUserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime EditDate { get; set; }
    }
}
