using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS360.Web.Enums
{
    public enum BannerPosition
    {
        #region 首页相关

        /// <summary>
        /// 首页轮播广告
        /// </summary>
        HomePage_Top_Slider = 1001,
        /// <summary>
        /// 首页上部广告
        /// </summary>
        HomePage_Top_AD = 1002,
        /// <summary>
        /// 首页中部广告
        /// </summary>
        HomePage_Mid_AD = 1003,

        /// <summary>
        /// 首页洋货街
        /// </summary>
        HomePage_Import_AD= 1004,

        /// <summary>
        /// 首页国货街
        /// </summary>
        HomePage_Internal_AD = 1005,

        /// <summary>
        /// 首页推荐商品
        /// </summary>
        HomePage_RecommendProduct_AD = 1006,
        /// <summary>
        /// APP启动页图片
        /// </summary>

        StartImage=1007
        #endregion
    }

    public enum PageType
    {
        All = -1,
        Home = 0,
        /// <summary>
        /// 一级类别
        /// </summary>
        TabStore = 1,
        /// <summary>
        /// 二级类别
        /// </summary>
        MidCategory = 2,
        /// <summary>
        /// 三级类别
        /// </summary>
        SubStore = 3,
        /// <summary>
        /// 开机动画
        /// </summary>
        AppStartimg=4
    }
}
