using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;


namespace MS.Web.Cookie
{
    /// <summary>
    /// Cookie配置信息管理
    /// </summary>
    internal class CookieConfigManager
    {
        private IHttpContextAccessor _httpAccessor;

        private const string COOKIE_CONFIG_FILE_PATH = "Configuration/Cookie.config";
        private const string COOKIE_CONFIG_FILE_PATH_NODE_NAME = "CookieConfigPath";

        public CookieConfigManager(IHttpContextAccessor httpContext)
        {
            _httpAccessor = httpContext;
        }

        private string CookieConfigFilePath
        {
            get
            {
                string path = COOKIE_CONFIG_FILE_PATH;
                if (string.IsNullOrWhiteSpace(path))
                {
                    path = COOKIE_CONFIG_FILE_PATH;
                }
                string p = Path.GetPathRoot(path);
                if (p == null || p.Trim().Length <= 0) // 说明是相对路径
                {
                    return Path.Combine(Path.GetDirectoryName(typeof(CookieConfigManager).Assembly.Location), path);
                }
                return path;
            }
        }

        private Dictionary<string, CookieConfigEntity> GetAllCookieConfig()
        {
            string path = CookieConfigFilePath;
            if (string.IsNullOrWhiteSpace(path) || File.Exists(path) == false)
            {
                return new Dictionary<string, CookieConfigEntity>(0);
            }

            Dictionary<string, CookieConfigEntity> dic = new Dictionary<string, CookieConfigEntity>();
            XmlDocument doc = new XmlDocument();
            doc.Load(CookieConfigFilePath);
            XmlNodeList nodeList = doc.GetElementsByTagName("cookies");
            if (nodeList != null && nodeList.Count > 0)
            {
                foreach (XmlNode xmlNode in nodeList)
                {
                    if (xmlNode == null)
                    {
                        continue;
                    }
                    CookieConfigEntity entity = new CookieConfigEntity();
                    entity.NodeName = xmlNode.Attributes["nodeName"] != null ? xmlNode.Attributes["nodeName"].Value : null;
                    entity.PersistType = xmlNode.Attributes["persistType"] != null ? xmlNode.Attributes["persistType"].Value : null;
                    entity.SecurityLevel = xmlNode.Attributes["securityLevel"] != null ? xmlNode.Attributes["securityLevel"].Value : null;
                    if (string.IsNullOrWhiteSpace(entity.NodeName))
                    {
                        throw new ApplicationException("Not set node name for cookie config in file '" + path + "'");
                    }
                    if (dic.ContainsKey(entity.NodeName))
                    {
                        throw new ApplicationException("Duplicated cookie config of node '" + entity.NodeName + "' in file '" + path + "'");
                    }
                    if (string.IsNullOrWhiteSpace(entity.PersistType))
                    {
                        entity.PersistType = "Auto"; // 如果没有配置persistType，则默认为web
                    }
                    if (string.IsNullOrWhiteSpace(entity.SecurityLevel))
                    {
                        entity.SecurityLevel = "Middle"; // 如果没有配置securityLevel，则默认为Middle
                    }
                    foreach (XmlNode childNode in xmlNode.ChildNodes)
                    {
                        if (childNode.NodeType == XmlNodeType.Element)
                        {
                            if (entity.Properties.ContainsKey(childNode.Name))
                            {
                                entity.Properties[childNode.Name] = childNode.InnerText;
                            }
                            else
                            {
                                entity.Properties.Add(childNode.Name, childNode.InnerText);
                            }
                        }
                    }
                    dic.Add(entity.NodeName, entity);
                }
            }
            return dic;
        }

        private  CookieConfigEntity GetDefaultCookieConfig(string nodeName)
        {
            CookieConfigEntity defaultConfig = new CookieConfigEntity();
            defaultConfig.NodeName = "defaultConfig";
            defaultConfig.PersistType = "Web";
            defaultConfig.SecurityLevel = "Middle";
            //节点名默认作为Cookie的存储名
            defaultConfig.Properties["cookieName"] = nodeName;
            defaultConfig.Properties["hashkey"] = "baeaaea5-3d57-4b98-abde-47ac0aa15d54";
            defaultConfig.Properties["rc4key"] = "5cb8b18c-7b5e-4f7b-a7c2-4603a250f39b";
            defaultConfig.Properties["domain"] = ((_httpAccessor.HttpContext == null || _httpAccessor.HttpContext.Request == null) ? "localhost" : _httpAccessor.HttpContext.Request.Host.Host);
            defaultConfig.Properties["path"] = "/";
            defaultConfig.Properties["expires"] = "0";
            defaultConfig.Properties["securityExpires"] = "20";
            return defaultConfig;
        }

        public CookieConfigEntity GetCookieConfig(string nodeName)
        {
            Dictionary<string, CookieConfigEntity> all = GetAllCookieConfig();
            CookieConfigEntity entity;
            if (all.TryGetValue(nodeName, out entity) && entity != null)
            {
                return entity;
            }
            return GetDefaultCookieConfig(nodeName);
        }

    }

    internal class CookieConfigEntity
    {
        public string NodeName { get; set; }
        public string PersistType { get; set; }
        public string SecurityLevel { get; set; }

        private Dictionary<string, string> m_Properties = new Dictionary<string, string>();
        public Dictionary<string, string> Properties { get { return m_Properties; } }
    }
}
