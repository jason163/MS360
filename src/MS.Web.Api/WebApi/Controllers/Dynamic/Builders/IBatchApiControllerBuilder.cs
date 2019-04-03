using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace MS.WebApi.Controllers.Dynamic.Builders
{
    public interface IBatchApiControllerBuilder<T>
    {
        IBatchApiControllerBuilder<T> Where(Func<Type, bool> predicate);

        IBatchApiControllerBuilder<T> WithFilters(params IFilter[] filters);

        IBatchApiControllerBuilder<T> WithApiExplorer(bool isEnabled);

        IBatchApiControllerBuilder<T> WithServiceName(Func<Type, string> serviceNameSelector);

        IBatchApiControllerBuilder<T> ForMethods(Action<IApiControllerActionBuilder> action);

        IBatchApiControllerBuilder<T> WithConventionalVerbs();

        void Build();
    }
}
