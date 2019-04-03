using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.WebApi.Controllers.Dynamic
{
    /// <summary>
    /// 动态APIController 基类
    /// </summary>
    /// <typeparam name="T">代理对象类型</typeparam>
    public class DynamicApiController<T> : MSApiController, IDynamicApiController
    {
        public List<string> AppliedCrossCuttingConcerns { get; }

        public DynamicApiController()
        {
            AppliedCrossCuttingConcerns = new List<string>();
        }
    }
}
