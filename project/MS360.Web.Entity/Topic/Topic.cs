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
    public class Topic 
    {

        /// <summary>
        /// 系统编号
        /// </summary>
        public int SysNo { get; set; }


        /// <summary>
        /// 类别系统编号
        /// </summary>
        public int TopicCategorySysNo { get; set; }


        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }


        /// <summary>
        /// 副标题
        /// </summary>
        public string SubTitle { get; set; }


        /// <summary>
        /// 缺省图片
        /// </summary>
        public string DefaultImage { get; set; }


        /// <summary>
        /// 文章缩略
        /// </summary>
        public string Summary { get; set; }


        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }


        /// <summary>
        /// 关键字
        /// </summary>
        public string Keywords { get; set; }


        /// <summary>
        /// 标签
        /// </summary>
        public string Tag { get; set; }


        /// <summary>
        /// 是否标红
        /// </summary>
        public int? IsRed { get; set; }


        /// <summary>
        /// 是否置顶
        /// </summary>
        public int? IsTop { get; set; }


        /// <summary>
        /// 浏览次数
        /// </summary>
        public int? PageViews { get; set; }


        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime PublishDate { get; set; }

        public string PublishDateStr { 
            get
            {

                return PublishDate.ToString("yyyy-MM-dd");

            }

        }

    }
}
