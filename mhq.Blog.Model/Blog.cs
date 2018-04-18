using System;
using System.Collections.Generic;
using System.Text;

namespace mhq.Blog.Model
{
    /// <summary>
    /// 博客表
    /// </summary>
    public class Blog
    {
        /// <summary>
        /// 主键自增
        /// </summary>
        public int id { set; get; }
        /// <summary>
        ///创建时间
        /// </summary>
        public DateTime createdate { set; get; }
        /// <summary>
        /// 标题
        /// </summary>
        public string title { set; get; }
        /// <summary>
        /// 内容
        /// </summary>
        public string body { set; get; }
        /// <summary>
        /// 内容-markdown
        /// </summary>
        public string body_md { set; get; }
        /// <summary>
        /// 访问量
        /// </summary>
        public int visitnum { set; get; }
        /// <summary>
        /// 分类编号
        /// </summary>
        public string cabh { set; get; }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string caname { set; get; }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark { set; get; }
        /// <summary>
        /// 排序号
        /// </summary>
        public int sort { set; get; }

    }
}
