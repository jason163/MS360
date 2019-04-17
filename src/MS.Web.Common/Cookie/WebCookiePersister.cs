using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MS.Web.Cookie
{
    internal class WebCookiePersister : ICookiePersist
    {
        private IHttpContextAccessor _httpAccessor;

        public WebCookiePersister(IHttpContextAccessor contextAccessor)
        {
            _httpAccessor = contextAccessor;
        }

        #region ICookiePersist Members

        public void Save(string cookieName, string cookieValue, Dictionary<string, string> parameters)
        {
            int expires = 0;
            int.TryParse(parameters["expires"], out expires);
            
            CookieOptions options = new CookieOptions();
            
            if (_httpAccessor.HttpContext.Request.Path.ToString().Contains(parameters["domain"]) && parameters["domain"] != "localhost")
            {
                options.Domain = parameters["domain"];
            }
            options.Path = parameters["path"];
            //配置为0，则cookie在会话结束后失效
            if (expires > 0)
                options.Expires = DateTime.Now.AddMinutes(expires);
            _httpAccessor.HttpContext.Response.Cookies.Append(cookieName,cookieValue,options);
        }

        public string Get(string cookieName, Dictionary<string, string> parameters)
        {
            _httpAccessor.HttpContext.Request.Cookies.TryGetValue(cookieName,out string cookie);
            return cookie;
        }

        public void Remove(string cookieName, Dictionary<string, string> parameters)
        {
            _httpAccessor.HttpContext.Request.Cookies.TryGetValue(cookieName,out string cookie);
            if (cookie != null)
            {
                _httpAccessor.HttpContext.Response.Cookies.Delete(cookieName,new CookieOptions {
                    Expires = DateTime.Now.AddMinutes(-1)
            });
            }
        }

        #endregion
    }
}
