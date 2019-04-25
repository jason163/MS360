using System;


namespace MS360.Web.Entity
{
    public class Customer
    {

        /// <summary>
        /// 系统编号
        /// </summary>
        public int? SysNo { get; set; }


        /// <summary>
        /// 顾客ID
        /// </summary>
        public string CustomerID { get; set; }


        /// <summary>
        /// 手机号码
        /// </summary>
        public string MobliePhone { get; set; }



        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string HeadImage { get; set; }



        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime? LastLoginDate { get; set; }


        /// <summary>
        /// 最后登录IP
        /// </summary>
        public string LastLoginIP { get; set; }
    }
}
