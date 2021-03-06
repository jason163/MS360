
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MS.DataAccess;
using MS.Dependency;
using MS360.Web.Entity;

namespace MS360.Web.DataAccess
{

    public class AuthenticationDA : IAuthenticationDA
    {

        /// <summary>
        /// 创建Authentication信息
        /// </summary>
        public   int InsertAuthentication(Authentication entity)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>(); //new DataCommand("CustomerCheckTelIsExist");
            cmd.CreateCommand("InsertAuthentication");

            //DataCommand cmd = new DataCommand("InsertAuthentication");
            cmd.SetParameter<Authentication>(entity);
            int result = cmd.ExecuteScalar<int>();
            return result;

        }



        /// <summary>
        /// 更新Authentication信息
        /// </summary>
        public   void UpdateAuthentication(Authentication entity)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>(); //new DataCommand("CustomerCheckTelIsExist");
            cmd.CreateCommand("UpdateAuthentication");

            //DataCommand cmd = new DataCommand("UpdateAuthentication");
            cmd.SetParameter<Authentication>(entity);
            cmd.ExecuteNonQuery();			 
        }



        /// <summary>
        /// 删除Authentication信息
        /// </summary>
        public   void DeleteAuthentication(int sysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>(); //new DataCommand("CustomerCheckTelIsExist");
            cmd.CreateCommand("DeleteAuthentication");

            //DataCommand cmd = new DataCommand("DeleteAuthentication");
            cmd.SetParameter("@SysNo", DbType.Int32, sysNo);
            cmd.ExecuteNonQuery();
        }


 

        /// <summary>
        /// 获取单个Authentication信息
        /// </summary>
        public   Authentication LoadAuthentication(int customerSysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>(); //new DataCommand("CustomerCheckTelIsExist");
            cmd.CreateCommand("LoadAuthentication");

            //DataCommand cmd = new DataCommand("LoadAuthentication");
            cmd.SetParameter("@CustomerSysNo", DbType.Int32, customerSysNo);
            Authentication result = cmd.ExecuteEntity<Authentication>();
			return result; 
        }



    }

}
