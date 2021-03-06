
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MS.Application.EntityBasic;
using MS.DataAccess;
using MS.Dependency;
using MS360.Web.Entity;

namespace MS360.Web.DataAccess
{
    public class ProductCommentDA : IProductCommentDA
    {
        /// <summary>
        /// 创建ProductComment信息
        /// </summary>
        public   int InsertProductComment(ProductComment entity)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("InsertProductComment");

            //DataCommand cmd = new DataCommand("InsertProductComment");
            cmd.SetParameter<ProductComment>(entity);
            int result = cmd.ExecuteScalar<int>();
            return result;

        }



        /// <summary>
        /// 更新ProductComment信息
        /// </summary>
        public   void UpdateProductComment(ProductComment entity)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("UpdateProductComment");

            //DataCommand cmd = new DataCommand("UpdateProductComment");
            cmd.SetParameter<ProductComment>(entity);
            cmd.ExecuteNonQuery();			 
        }



        /// <summary>
        /// 删除ProductComment信息
        /// </summary>
        public   void DeleteProductComment(int sysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("DeleteProductComment");

            //DataCommand cmd = new DataCommand("DeleteProductComment");
            cmd.SetParameter("@SysNo", DbType.Int32, sysNo);
            cmd.ExecuteNonQuery();
        }



        /// <summary>
        /// 分页查询ProductComment信息
        /// </summary>
        public   QueryResult<QR_ProductComment> QueryProductCommentList(QF_ProductComment filter)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("QueryProductCommentList");

            //DataCommand cmd = new DataCommand("QueryProductCommentList");

            cmd.QuerySetCondition("pc.ProductSysNo", ConditionOperation.Equal, DbType.Int32, filter.ProductSysNo);
            cmd.QuerySetCondition("pc.CommonStatus", ConditionOperation.Equal, DbType.Int32, 1);

            if (filter.Condition == 1)
            {
                cmd.QuerySetCondition("pc.Rate", ConditionOperation.MoreThan, DbType.Int32, 1);
            }
            if (filter.Condition == 2)
            {
                cmd.QuerySetCondition("pc.Rate", ConditionOperation.LessThanEqual, DbType.Int32, 1);
            }
            if (filter.Condition == 3)
            {
                cmd.QuerySetCondition("pc.HasPic", ConditionOperation.Equal, DbType.Int32, 1);
            }

			            
            QueryResult<QR_ProductComment> result = cmd.Query<QR_ProductComment>(filter, " pc.SysNo DESC");
			
            return result;
			 
            
        }

        public   QR_ProductCommentStatistics QueryProductCommentStatistics(int productSysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("QueryProductCommentStatistics");

            //var cmd = new DataCommand("QueryProductCommentStatistics");
            cmd.SetParameter("ProductSysNo", DbType.Int32, productSysNo);
            return cmd.ExecuteEntity<QR_ProductCommentStatistics>();
        }


        /// <summary>
        /// 获取单个ProductComment信息
        /// </summary>
        public   ProductComment LoadProductComment(int sysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("LoadProductComment");

            //DataCommand cmd = new DataCommand("LoadProductComment");
            cmd.SetParameter("@SysNo", DbType.Int32, sysNo);
            ProductComment result = cmd.ExecuteEntity<ProductComment>();
			return result; 
        }


        /// <summary>
        /// 通过订单编号和商品编号获得商品评论
        /// </summary>
        /// <param name="sosysno"></param>
        /// <param name="productSysNo"></param>
        /// <returns></returns>
        public   ProductComment GetProductCommentBySoSysNoAndProductSysNo(int sosysno,int productSysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("GetProductCommentBySoSysNoAndProductSysNo");

            //var cmd = new DataCommand("GetProductCommentBySoSysNoAndProductSysNo");
            cmd.SetParameter("@SoSysNo", DbType.Int32, sosysno);
            cmd.SetParameter("@ProductSysNo", DbType.Int32, productSysNo);
            return cmd.ExecuteEntity<ProductComment>();
        }

        /// <summary>
        /// 检查商品评价是否存在
        /// </summary>
        /// <param name="sosysno"></param>
        /// <param name="productSysNo"></param>
        /// <returns></returns>
        public   bool CheckProductCommentExists(int sosysno,int productSysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("CheckProductCommentExists");

            //var cmd = new DataCommand("CheckProductCommentExists");
            cmd.SetParameter("@SOSysNo", DbType.Int32, sosysno);
            cmd.SetParameter("@ProductSysNo", DbType.Int32, productSysNo);
            return cmd.ExecuteScalar<bool>();
        }

    }

}
