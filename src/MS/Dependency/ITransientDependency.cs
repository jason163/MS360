using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Dependency
{
    /// <summary>
    /// 实现此接口的类会自动注册为瞬态对象
    /// </summary>
    public interface ITransientDependency
    {
    }

    /// <summary>
    /// 实现此接口的类会自动注册为单例对象
    /// </summary>
    public interface ISingletonDependency
    {
    }
}
