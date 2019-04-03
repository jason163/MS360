using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MS.Web.Mvc.Controllers
{
    public abstract class MSController : Controller
    {
        public ILogger Logger { get; set; }

        protected MSController()
        {
            Logger = NullLogger.Instance;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }

        #region
        protected override void OnException(ExceptionContext context)
        {
            if(null == context)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if(context.ExceptionHandled || context.IsChildAction)
            {
                base.OnException(context);
                return;
            }


            base.OnException(context);
        }
        #endregion
    }
}
