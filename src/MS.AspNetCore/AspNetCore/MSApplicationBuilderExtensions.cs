using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Castle.LoggingFacility.MsLogging;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using MS.AspNetCore.Security;

namespace MS.AspNetCore
{
    public static class MSApplicationBuilderExtensions
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="app"></param>
        public static void UseMS(this IApplicationBuilder app)
        {
            app.UseMS(null);
        }

        /// <summary>
        /// 初始化MS 框架 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="optionsAction"></param>
        public static void UseMS([NotNull]this IApplicationBuilder app,Action<MSApplicationBuilderOptions> optionsAction)
        {
            var options = new MSApplicationBuilderOptions();
            optionsAction?.Invoke(options);

            if (options.UseCastleLoggerFactory)
            {
                app.UseCastleLoggerFactory();
            }

            InitializeMS(app);

            if (options.UseSecurityHeaders)
            {
                app.UseMSSecurityHeaders();
            }
        }

        /// <summary>
        /// 初始化框架
        /// </summary>
        /// <param name="app"></param>
        private static void InitializeMS(IApplicationBuilder app)
        {
            // 初始化框架
            var msBootstrapper = app.ApplicationServices.GetRequiredService<MSBootStrapper>();
            msBootstrapper.Initialize();

            var applicationLifetime = app.ApplicationServices.GetService<IApplicationLifetime>();
            applicationLifetime.ApplicationStopped.Register(() => msBootstrapper.Dispose());
        }

        /// <summary>
        /// 使用Castle日志工厂
        /// </summary>
        /// <param name="app"></param>
        public static void UseCastleLoggerFactory(this IApplicationBuilder app)
        {
            var castleLoggerFactory = app.ApplicationServices.GetService<Castle.Core.Logging.ILoggerFactory>();
            if(null == castleLoggerFactory)
            {
                return;
            }
            app.ApplicationServices
                .GetRequiredService<ILoggerFactory>()
                .AddCastleLogger(castleLoggerFactory);

        }

        public static void UseMSSecurityHeaders(this IApplicationBuilder app)
        {
            app.UseMiddleware<MSSecurityHeadersMiddleware>();
        }
    }
}
