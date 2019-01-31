using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MS
{
    /// <summary>
    /// 提供一个方法当释放资源方法被调用时
    /// </summary>
    public class DisposeAction : IDisposable
    {
        public static readonly DisposeAction Empty = new DisposeAction(null);

        private Action _action;

        /// <summary>
        /// 创建一个 <see cref="DisposeAction"/> 对象.
        /// </summary>
        /// <param name="action">对象被释放时被调用的操作</param>
        public DisposeAction([CanBeNull] Action action)
        {
            _action = action;
        }

        public void Dispose()
        {
            // Interlocked prevents multiple execution of the _action.
            var action = Interlocked.Exchange(ref _action, null);
            action?.Invoke();
        }
    }
}
