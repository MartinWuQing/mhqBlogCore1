using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace mhq.Blog.Web.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            ///1、测试增
            string str = "";
            mhq.Blog.DAL.CategoryDAL cadal = new DAL.CategoryDAL();
            str += "新增的ID值：" + cadal.insert(new Model.Category() { caname = "caname", bh = "01", pbh = "01", remark = "01" }) + "<hr />";

            //2、测试删
            bool b = cadal.Delete(7);
            str += "删除ID=7的结果：" + b + "<hr />";

            //3、测试修改
            ////先取出数据
            Model.Category ca = cadal.Getmodel(8);
            if (ca != null)
            {
                ca.caname = "新修改的名称" + DateTime.Now;
                bool b2 = cadal.update(ca);
                str += "修改ID=8的结果：" + b2 + "<hr />";  
            }
            ///4、测试查询
            List<Model.Category> list = cadal.GetList("");
            foreach (var item in list)
            {
                str += $"<div>分类id:{item.id},分类名称：{item.caname}</div >";
            }

            return Content(str);

        }
    }
}