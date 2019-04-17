
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;


namespace MS.Web.Cookie
{
    /// <summary>
    /// 明文存储的COOKIE存取
    /// </summary>
    internal class NormalCookie : ICookieEncryption
    {
        #region ICookieEncryption Members

        public string EncryptCookie<T>(T obj, Dictionary<string, string> parameters)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public T DecryptCookie<T>(string cookieValue, Dictionary<string, string> parameters)
        {
            return JsonConvert.DeserializeObject<T>(cookieValue);
        }

        #endregion
    }
}
