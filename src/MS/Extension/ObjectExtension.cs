using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MS.Extension
{
    public static class ObjectExtension
    {
        /// <summary>
        /// 判断项是否在列表中
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool IsIn<T>(this T item,params T[] list)
        {
            return list.Contains(item);
        }
    }
}
