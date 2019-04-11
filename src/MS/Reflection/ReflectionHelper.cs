using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace MS.Reflection
{
    /// <summary>
    /// 反射帮助类
    /// </summary>
    public static class ReflectionHelper
    {
        /// <summary>
        /// 获取类成员定义的Attribute,包含继承;如果没有表明则返回默认值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="memberInfo"></param>
        /// <param name="defValue"></param>
        /// <param name="inhert"></param>
        /// <returns></returns>
        public static T GetSingleAttributeOrDefault<T>(MemberInfo memberInfo,T defValue = default(T),bool inhert = true)
            where T:Attribute
        {
            if (memberInfo.IsDefined(typeof(T), inhert))
            {
                return memberInfo.GetCustomAttributes(typeof(T), inhert).Cast<T>().First();
            }
            return defValue;
        }
    }
}
