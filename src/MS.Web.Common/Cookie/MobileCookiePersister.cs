
using Microsoft.AspNetCore.Http;
using MS.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;


namespace MS.Web.Cookie
{
    internal class MobileCookiePersister : ICookiePersist
    {
        private IHttpContextAccessor _httpAccessor;

        public MobileCookiePersister(IHttpContextAccessor contextAccessor)
        {
            _httpAccessor = contextAccessor;
        }

        #region ICookiePersist Members

        public void Save(string cookieName, string cookieValue, Dictionary<string, string> parameters)
        {
            var collection = _httpAccessor.HttpContext.Response.Headers;
            if (collection.Keys.Contains(MobileCookie.COOKIE_NAME))
            {
                string json = collection[MobileCookie.COOKIE_NAME];



                dynamic x1 = DynamicJson.Parse(json);
                x1[cookieName] = cookieValue;
                string v = x1.ToString();
                collection[MobileCookie.COOKIE_NAME] = v;
            }
            else
            {
                dynamic x1 = new DynamicJson();
                x1[cookieName] = cookieValue;
                string v = x1.ToString();
                _httpAccessor.HttpContext.Response.Headers.Add(MobileCookie.COOKIE_NAME, v);
            }            
        }

        public string Get(string cookieName, Dictionary<string, string> parameters)
        {
            var collection = _httpAccessor.HttpContext.Request.Headers;
            if (collection.Keys.Contains(MobileCookie.COOKIE_NAME))
            {
                string json = collection[MobileCookie.COOKIE_NAME];
                dynamic x1 = DynamicJson.Parse(json);
                if (x1.IsDefined(cookieName))
                {
                    object t = x1[cookieName];
                    return t == null ? string.Empty : t.ToString();
                }
            }
            return string.Empty;
        }

        public void Remove(string cookieName, Dictionary<string, string> parameters)
        {
            var collection = _httpAccessor.HttpContext.Response.Headers;
            if (collection.Keys.Contains(MobileCookie.COOKIE_NAME))
            {
                string json = collection[MobileCookie.COOKIE_NAME];
                dynamic x1 = DynamicJson.Parse(json);
                if (x1.IsDefined(cookieName))
                {
                    x1.Delete(cookieName);
                    string v = x1.ToString();
                    collection[MobileCookie.COOKIE_NAME] = v;
                }
            }
        }

        #endregion
    }

    public static class MobileCookie
    {
        public const string COOKIE_NAME = "x-ms360-mobile-cookie";
    }
}
