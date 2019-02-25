using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.AspNetCore.Mvc
{
    internal static class MSMvcOptionsExtensions
    {
        public static void AddMS(this MvcOptions options,IServiceCollection services)
        {
            AddConventions(options, services);

            AddFilters(options);

            AddModelBinders(options);
        }

        private static void AddFilters(MvcOptions options)
        {
        }

        private static void AddModelBinders(MvcOptions options)
        {
        }

        private static void AddConventions(MvcOptions options, IServiceCollection services)
        {
        }
    }
}
