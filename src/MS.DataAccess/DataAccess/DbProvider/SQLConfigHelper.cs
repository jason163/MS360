
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using MS.DataAccess.Configuration;
using MS.Runtime.Caching;
using MS.Xml;

namespace MS.DataAccess.DbProvider
{
    public class SQLConfigHelper : ISQLConfigHelper
    {
        private readonly ICacheManager _cacheManager;
        private readonly IMSDataAccessModuleConfiguration _configuration;
        private readonly IDbConfigProvider _dbConfigProvider;
        private readonly ITypedCache<string, List<SQL>> _cache;


        public SQLConfigHelper(IDbConfigProvider dbConfigProvider,ICacheManager cacheManager,IMSDataAccessModuleConfiguration moduleConfiguration)
        {
            this._cacheManager = cacheManager;
            this._dbConfigProvider = dbConfigProvider;
            this._configuration = moduleConfiguration;
            _cache = _cacheManager.GetCache<string, List<SQL>>("MS360_DataAccess");
        }

        public List<SQL> GetSQLList()
        {
            return _cache.Get("MS360_DataAccess_SQLConfig", (k) => {
                return LoadConfigs();
            });
        }

        private static object _obj = new object();

        private List<SQL> LoadConfigs()
        {
            List<SQL> list = new List<SQL>();
            Regex regex = new Regex(@"@\w*", RegexOptions.IgnoreCase);

            DBConfig dbConfig = _dbConfigProvider.ConfigSetting();
            if (dbConfig != null && dbConfig.SQLFileList != null)
            {
                lock (_obj)
                {
                    foreach (string file in dbConfig.SQLFileList)
                    {

                        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, this._configuration.ConfigPath, file);
                        if (File.Exists(filePath))
                        {
                            SQLConfig sqlConfig = XmlSerializationHelper.LoadFromXml<SQLConfig>(filePath);
                            if (sqlConfig.SQLList != null)
                            {
                                foreach (SQL sql in sqlConfig.SQLList)
                                {
                                    sql.ParameterNameList = new List<string>();

                                    MatchCollection matches = regex.Matches(sql.Text.Trim());
                                    if (matches != null && matches.Count > 0)
                                    {
                                        foreach (Match match in matches)
                                        {
                                            if (!sql.ParameterNameList.Exists(f => f.Trim().ToLower() == match.Value.Trim().ToLower()))
                                            {
                                                sql.ParameterNameList.Add(match.Value);
                                            }
                                        }
                                    }

                                    if (sql.TimeOut == 0)
                                    {
                                        DBConnection conn = _dbConfigProvider.ConfigSetting().DBConnectionList.Find(f => f.Key.ToLower().Trim() == sql.ConnectionKey.ToLower().Trim());
                                        if (conn != null)
                                        {
                                            sql.TimeOut = conn.TimeOut;
                                        }
                                        else
                                        {
                                            sql.TimeOut = 180;
                                        }

                                    }
                                }
                                list.AddRange(sqlConfig.SQLList);
                            }
                        }
                        else
                        {
                            throw new System.Exception(string.Format("Not found sql file {0}", filePath));
                        }
                    }
                }
            }

            return list;

        }
    }
}
