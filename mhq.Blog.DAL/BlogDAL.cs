using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mhq.Blog.DAL
{
    public class BlogDAL
    {
        /// <summary>
        /// 增加方法
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int insert(mhq.Blog.Model.Blog m)
        {
            // Dapper - Insert
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                int resid = connection.Query<int>(@"insert into blog
                                                   (title
                                                   ,body
                                                   ,body_md
                                                   ,visitnum
                                                   ,cabh
                                                   ,caname
                                                   ,remark
                                                   ,sort)
                                             VALUES
                                                   (@title
                                                   ,@body
                                                   ,@body_md
                                                   ,@visitnum 
                                                   ,@cabh
                                                   ,@caname
                                                   ,@remark
                                                   ,@sort);SELECT @@IDENTITY;", m).First();
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
                int res = connection.Execute(@"delete from Blog where id = @id", new { id = id });
                if (res > 0)
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
        public List<Model.Blog> GetList(string cond)
        {
            // Dapper – Simple List
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                string sql = "select * from blog ";
                if (!string.IsNullOrEmpty(cond))
                {
                    sql=sql+$" where{cond}";
                }
                var list = connection.Query<Model.Blog>(sql).ToList();
                return list;
            }
        }
        /// <summary>
        /// 获取实体类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Blog Getmodel(int id)
        {
            // Dapper - Single
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                var m = connection.Query<Model.Blog>("select * from Blog where id = @id",
                  new { id = id }).First();
                return m;
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public bool update(Model.Blog m)
        {
            // Dapper - Update
            using (var connection = ConnectionFactory.GetOpenConnection())
            {

                int res = connection.Execute(@"UPDATE [blog]
                                                   SET 
   　　                                            [title] = @title
                                                  ,[body] = @body
                                                  ,[body_md] = @body_md
                                                  ,[visitnum] = @visitnum
                                                  ,[cabh] = @cabh
                                                  ,[caname] = @caname
                                                  ,[remark] =@remark
                                                  ,[sort] = @sort
                                                    WHERE id=@id", m);

                if (res > 0)
                {
                    return true;
                }

                return false;
            }
        }



    }
}
