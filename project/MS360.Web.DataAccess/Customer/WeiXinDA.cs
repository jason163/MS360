using MS.DataAccess;
using MS.Dependency;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS360.Web.DataAccess
{
    public class WeiXinDA : IWeiXinDA
    {
        /// <summary>
        /// 获取微信公共Token
        /// </summary>
        /// <returns></returns>
        public string GetWeiXinCommonToken()
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("GetWeiXinCommonToken");

            //DataCommand cmd = new DataCommand("GetWeiXinCommonToken");
            string result = cmd.ExecuteScalar<string>();
            return result;
        }

        /// <summary>
        /// 添加Token
        /// </summary>
        /// <param name="commonToken"></param>
        /// <param name="expiresIn"></param>
        public void AddWeiXinCommonToken(string commonToken, int expiresIn)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("AddWeiXinCommonToken");

            //DataCommand cmd = new DataCommand("AddWeiXinCommonToken");
            cmd.SetParameter("@CommonToken", DbType.String, commonToken);
            cmd.SetParameter("@ExpiresIn", DbType.Int32, expiresIn);

            cmd.ExecuteNonQuery();
        }
    }
}
