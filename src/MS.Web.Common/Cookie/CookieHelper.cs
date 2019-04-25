using Microsoft.AspNetCore.Http;
using MS.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MS.Web.Cookie
{
    /// <summary>
    /// Cookie工具
    /// </summary>
    public class CookieHelper
    {
        private IHttpContextAccessor _httpAccessor;
        private ICookiePersist s_Mobile;
        private ICookiePersist s_Web;

        private  ICookieEncryption s_Normal;
        private  ICookieEncryption s_Security;
        private  ICookieEncryption s_HighSecurity;

        public CookieHelper(IHttpContextAccessor httpContext)
        {
            _httpAccessor = httpContext;
             s_Mobile = new MobileCookiePersister(this._httpAccessor);
             s_Web = new WebCookiePersister(_httpAccessor);
            s_Normal = new NormalCookie();
            s_Security = new SecurityCookie();
            s_HighSecurity = new HighSecurityCookie(httpContext);
        }

        #region Private Member

        private  void LoadConfig(string nodeName, out string persistType, out string securityLevel,
            out Dictionary<string, string> parameters)
        {
            var entity = IocManager.Instance.IocContainer.Resolve<CookieConfigManager>().GetCookieConfig(nodeName);
            parameters = entity.Properties;
            persistType = entity.PersistType;
            securityLevel = entity.SecurityLevel;
        }

        
        private ICookiePersist CreatePersister(string persistType)
        {
            switch (persistType.ToUpper())
            {
                case "MOBILE":
                    return s_Mobile;
                case "WEB":
                    return s_Web;
                case "AUTO":
                    return DiscernPersistType();
                default:
                    return (ICookiePersist)Activator.CreateInstance(Type.GetType(persistType, true));
            }
        }

        private ICookiePersist DiscernPersistType()
        {
            var httpContext = IocManager.Instance.IocContainer.Resolve<IHttpContextAccessor>();
            if (httpContext.HttpContext.Request.Headers.Keys.Contains(MobileCookie.COOKIE_NAME)
                //mobile 所有的请求必须经过core里的方法进行调用,否则头信息不能回写
                //|| (HttpContext.Current.Request.QueryString.AllKeys.Count()>0&&HttpContext.Current.Request.QueryString["type"].ToUpper()=="MOBILE")
                )
                return s_Mobile;
            return s_Web;
        }

        
        private ICookieEncryption CreateCookieHelper(string securityLevel)
        {
            //return IocManager.Instance.Resolve< ICookieEncryption>
            switch (securityLevel.ToUpper())
            {
                case "LOW":
                    return s_Normal;
                case "MIDDLE":
                    return s_Security;
                case "HIGH":
                    return s_HighSecurity;
                default:
                    return (ICookieEncryption)Activator.CreateInstance(Type.GetType(securityLevel, true));
            }
        }

        public static string GetCookieName(string nodeName, Dictionary<string, string> parameters)
        {
            string name;
            if (parameters != null && parameters.TryGetValue("cookieName", out name)
                && !string.IsNullOrWhiteSpace(name))
            {
                return name;
            }
            return nodeName;
        }

        #endregion

        /// <summary>
        /// 保存Cookie
        /// </summary>
        /// <typeparam name="T">需要存放的Cookie值的类型</typeparam>
        /// <param name="nodeName">配置的Cookie节点名，若未配置，则使用此名作为cookie存储名且使用默认配置</param>
        /// <param name="obj">需要存放的Cookie值</param>
        public void SaveCookie<T>(string nodeName, T obj)
        {
            string persistType;
            string securityLevel;
            Dictionary<string, string> parameters;
            LoadConfig(nodeName, out persistType, out securityLevel, out parameters);

            ICookiePersist persister = CreatePersister(persistType);
            ICookieEncryption safer = CreateCookieHelper(securityLevel);
            string cookieValue = safer.EncryptCookie<T>(obj, parameters);
            persister.Save(GetCookieName(nodeName, parameters), cookieValue, parameters);
        }

        /// <summary>
        /// 读取Cookie
        /// </summary>
        /// <typeparam name="T">返回的类型</typeparam>
        /// <param name="nodeName">配置的Cookie节点名，若未配置，则使用此名作为cookie存储名且使用默认配置</param>
        /// <returns></returns>
        public  T GetCookie<T>(string nodeName)
        {
            string persistType;
            string securityLevel;
            Dictionary<string, string> parameters;
            LoadConfig(nodeName, out persistType, out securityLevel, out parameters);

            ICookiePersist persister = CreatePersister(persistType);
            string cookieValue = persister.Get(GetCookieName(nodeName, parameters), parameters);
            ICookieEncryption safer = CreateCookieHelper(securityLevel);
            return safer.DecryptCookie<T>(cookieValue, parameters);
        }

        /// <summary>
        /// 清除指定的Cookie
        /// </summary>
        /// <param name="nodeName">配置的Cookie节点名，若未配置，则使用此名作为cookie存储名且使用默认配置</param>
        public void RemoveCookie(string nodeName)
        {
            string persistType;
            string securityLevel;
            Dictionary<string, string> parameters;
            LoadConfig(nodeName, out persistType, out securityLevel, out parameters);

            ICookiePersist persister = CreatePersister(persistType);
            persister.Remove(GetCookieName(nodeName, parameters), parameters);
        }
    }
}
