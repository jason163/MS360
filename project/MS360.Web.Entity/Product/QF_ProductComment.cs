
using MS.Application.EntityBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MS360.Web.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class QF_ProductComment  : QueryFilter
    {

        /// <summary>
        /// 商品名称
        /// </summary>
        public int? ProductSysNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Condition { get; set; }


    }
    /// <summary>
    /// 
    /// </summary>
	public class QR_ProductComment
    {

        /// <summary>
        /// 系统编号
        /// </summary>
        public int? SysNo { get; set; }


        /// <summary>
        /// 订单编号
        /// </summary>
        public int? SOSysNo { get; set; }


        /// <summary>
        /// 商品名称
        /// </summary>
        public int? ProductSysNo { get; set; }


        /// <summary>
        /// 客户编号
        /// </summary>
        public int? CustomerSysNo { get; set; }

        /// <summary>
        /// 用户头像
        /// </summary>
        public string HeadImage { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string DisplayName { get; set; }


        /// <summary>
        /// 评分
        /// </summary>
        public decimal? Rate { get; set; }


        /// <summary>
        /// 评价
        /// </summary>
        public string Comment { get; set; }


        /// <summary>
        /// 是否有图片
        /// </summary>
        public int? HasPic { get; set; }


        /// <summary>
        /// 图片地址
        /// </summary>
        public string Pics { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> PicList
        {
            get;
            set;
        }

        /// <summary>
        /// 有用
        /// </summary>
        public int? Useful { get; set; }


        /// <summary>
        /// 没用
        /// </summary>
        public int? UnUseful { get; set; }


        /// <summary>
        /// 评论状态
        /// </summary>
        public int? CommonStatus { get; set; }


        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? InDate { get; set; }


         /// <summary>
         /// 创建时间显示信息
         /// </summary>
         public String InDateStr { get { return  InDate.HasValue? InDate.Value.ToString("yyyy-MM-dd HH:mm:ss"):string.Empty; }}

    }
    /// <summary>
    /// 
    /// </summary>
    public class QR_ProductCommentStatistics
    {
        /// <summary>
        /// 
        /// </summary>
        public int GoodCommentsCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int NageCommentsCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int WithPicCount { get; set; }
    }
}

