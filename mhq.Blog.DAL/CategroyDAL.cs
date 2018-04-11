using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mhq.Blog.DAL
{
     public  class CategroyDAL
    {
        /// <summary>
        /// 增加方法
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int insert(mhq.Blog.Model.Category m)
        {
            // Dapper - Insert
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                int resid = connection.Query<int>(
                    @"insert into Category(caname,bh,pbh,remark)
                      values( @caname, @bh,@pbh,@remark);SELECT @@IDENTITY;",
                    m).First();
                return resid;
            }

        }
        /// <summary>
        /// 删除方法
        /// </summary>
        public bool Delete(int id)
        {
            // Dapper - Delete
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
               int res= connection.Execute(@"delete from Category where id = @id", new { id = id });
                if(res>0)
                {
                    return true;
                }
                return false;
            }
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="cond">查询条件</param>
        /// <returns></returns>
        public List<Model.Category> GetList(string cond)
        {
            // Dapper – Simple List
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                string sql = "select * from Category";
                if(!string .IsNullOrEmpty(cond))
                {
                    sql += $"where{cond}";
                }
                var list = connection.Query<Model.Category>(sql).ToList();
                return list;
            }
        }
        /// <summary>
        /// 获取实体类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Category Getmodel(int id)
        {
            // Dapper - Single
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                var m= connection.Query<Model.Category>("select * from Category where id = @id",
                  new { id = id}).First();
                return m;
            }
        }

       /// <summary>
       /// 修改
       /// </summary>
       /// <param name=""></param>
       /// <returns></returns>
        public bool  update(Model.Category m)
        {
            // Dapper - Update
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
               
              int res=  connection.Execute(@"UPDATE [category]
                                               SET 
     　                                            [caname] =@caname
                                                  ,[bh] =@bh
                                                  ,[pbh] =@pbh
                                                  ,[remark] =@remark
                                                   WHERE id=@id", m);

                if(res>0)
                {
                    return true;
                }

                return false;
            }
        }



    }
}
