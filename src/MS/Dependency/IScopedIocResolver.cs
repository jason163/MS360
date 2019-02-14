using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Dependency
{
    /// <summary>
    /// 用一个using包装一个范围,在此范围内批量释放资源
    /// </summary>
    public interface IScopedIocResolver : IIocResolver,IDisposable
    {
    }
}
