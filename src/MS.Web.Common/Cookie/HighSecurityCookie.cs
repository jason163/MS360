﻿using Microsoft.AspNetCore.Http;
using MS.Dependency;
using MS.Encryption;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;


namespace MS.Web.Cookie
{
    /// <summary>
    /// 经加密算法加密并且在一定时间内过期的高安全COOKIE存取
    /// </summary>
    internal class HighSecurityCookie : ICookieEncryption
    {
        private IHttpContextAccessor _httpAccessor;

        public HighSecurityCookie(IHttpContextAccessor contextAccessor)
        {
            _httpAccessor = contextAccessor;
        }

        private string GetClientIP()
        {
            if (_httpAccessor.HttpContext == null || _httpAccessor.HttpContext.Request == null)
            {
                return string.Empty;
            }
            string result = _httpAccessor.HttpContext.Request.Headers["HTTP_X_FORWARDED_FOR"];
            if (null == result || result.Trim() == String.Empty)
            {
                result = _httpAccessor.HttpContext.Request.Headers["REMOTE_ADDR"];
            }

            if (null == result || result.Trim() == String.Empty)
            {
                result = _httpAccessor.HttpContext.Request.Host.ToString();
            }
            if (null == result)
            {
                return string.Empty;
            }
            return result.Trim();
        }

        #region ICookieEncryption Members

        public string EncryptCookie<T>(T obj, Dictionary<string, string> parameters)
        {
            string strCookieValue = string.Empty;
            string strEncCookieValue = string.Empty;
            string strSHA1Sign = string.Empty;
            string[] arrayCookieValue = new string[3];

            int securityExpires = 0;
            int.TryParse(parameters["securityExpires"], out securityExpires);

            arrayCookieValue[0] = JsonConvert.SerializeObject(obj);
            arrayCookieValue[1] = DateTime.Now.AddMinutes(securityExpires).ToString();
            arrayCookieValue[2] = GetClientIP();
            strCookieValue = JsonConvert.SerializeObject(arrayCookieValue);

            strEncCookieValue = RC4Encrypt.Encrypt(strCookieValue, parameters["rc4key"], RC4Encrypt.EncoderMode.HexEncoder).Trim();
            strSHA1Sign = HashEncrypt.SHA1Encrypt(strEncCookieValue + parameters["hashkey"]);
            strEncCookieValue = HttpUtility.UrlEncode(strEncCookieValue);
            strEncCookieValue = strSHA1Sign + strEncCookieValue;

            return strEncCookieValue;
        }

       

        public T DecryptCookie<T>(string cookieValue, Dictionary<string, string> parameters)
        {
            T result = default(T);
            string strEncCookieValue = string.Empty;
            string strContent = string.Empty;
            string strSHA1Sign = string.Empty;
            string strShA1Temp = string.Empty;
            string[] arrayCookieValue = new string[2];

            try
            {
                if (cookieValue.Length < 40)
                    return result;
                //  取出签名和密文
                strSHA1Sign = cookieValue.Substring(0, 40);
                strEncCookieValue = cookieValue.Substring(40);
                //  签名校验
                strShA1Temp = HashEncrypt.SHA1Encrypt(HttpUtility.UrlDecode(strEncCookieValue).Trim() + parameters["hashkey"]);
                if (strSHA1Sign != strShA1Temp)
                    return result;
                strEncCookieValue = HttpUtility.UrlDecode(strEncCookieValue);
                //  还原成明文
                strContent = RC4Encrypt.Decrypt(strEncCookieValue, parameters["rc4key"], RC4Encrypt.EncoderMode.HexEncoder);
                if (strContent.Length == 0)
                    return result;

                arrayCookieValue = JsonConvert.DeserializeObject<string[]>(strContent);
                if (arrayCookieValue != null && arrayCookieValue.Length == 3)
                {
                    if (DateTime.Parse(arrayCookieValue[1]) > DateTime.Now && GetClientIP() == arrayCookieValue[2])
                    {
                        result = JsonConvert.DeserializeObject<T>(arrayCookieValue[0]);
                        //Cookie有效，则继续延续有效期
                        IocManager.Instance.IocContainer.Resolve<CookieHelper>().SaveCookie<T>(parameters["nodeName"], result);
                        //CookieHelper.SaveCookie<T>(parameters["nodeName"], result);
                    }
                }

                return result;
            }
            catch
            {
                return result;
            }
        }

        #endregion
    }
}
