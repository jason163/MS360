using MS360.Web.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;


namespace MS360.Web.Entity
{
    /// <summary>
    /// 商品评论
    /// </summary>
    public class ProductComment
    {

        /// <summary>
        /// 系统编号
        /// </summary>
        public int SysNo { get; set; }


        /// <summary>
        /// 订单编号
        /// </summary>
        public int SOSysNo { get; set; }


        /// <summary>
        /// 商品编号
        /// </summary>
        public int ProductSysNo { get; set; }


        /// <summary>
        /// 客户编号
        /// </summary>
        public int CustomerSysNo { get; set; }


        /// <summary>
        /// 评分
        /// </summary>
        public decimal Rate { get; set; }


        /// <summary>
        /// 评价
        /// </summary>
        public string Comment { get; set; }


        /// <summary>
        /// 是否有图片
        /// </summary>
        public int HasPic { get; set; }


        /// <summary>
        /// 图片地址
        /// </summary>
        public string Pics { get; set; }


        /// <summary>
        /// 有用
        /// </summary>
        public int Useful { get; set; }


        /// <summary>
        /// 没用
        /// </summary>
        public int UnUseful { get; set; }


        /// <summary>
        /// 评论状态
        /// </summary>
        public CommonStatus CommonStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> Pictures { get; set; }
    }
}
