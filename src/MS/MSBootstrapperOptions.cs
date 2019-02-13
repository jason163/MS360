using MS.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS
{
    /// <summary>
    /// MS 启动参数选项
    /// </summary>
    public class MSBootstrapperOptions
    {
        /// <summary>
        /// Used to disable all interceptors added by ABP.
        /// </summary>
        public bool DisableAllInterceptors { get; set; }

        /// <summary>
        /// IIocManager that is used to bootstrap the MS system. If set to null, uses global <see cref="MS.Dependency.IocManager.Instance"/>
        /// </summary>
        public IIocManager IocManager { get; set; }


        public MSBootstrapperOptions()
        {
            IocManager = MS.Dependency.IocManager.Instance;
        }
    }
}
