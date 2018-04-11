using System;
using System.Collections.Generic;
using System.Text;

namespace mhq.Blog.Model
{
    public class Category
    {
        /// <summary>
        /// 主键自增
        /// </summary>
        public int id { set; get; }
        /// <summary>
        /// 登录名
        /// </summary>
        public DateTime createdate { set; get; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string caname { set; get; }
        /// <summary>
        /// 用户性别 
        /// </summary>
        public string bh { set; get; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string pbh { set; get; }

        /// <summary>
        /// 用户标签
        /// </summary>
        public string remark { set; get; }

    }  
}
