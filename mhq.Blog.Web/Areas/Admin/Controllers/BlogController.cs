using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace mhq.Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        DAL.BlogDAL dal = new DAL.BlogDAL();
        DAL.CategoryDAL cadal = new DAL.CategoryDAL();

        public IActionResult Index()
        {
            List<Model.Blog> list = dal.GetList("");
            return View(list);
        }
        public IActionResult Add(int ? id)
        {
            ViewBag.calist = cadal.GetList("");
            Model.Blog m = new Model.Blog();
            if(id !=null)
            {
                m = dal.Getmodel(id.Value);

            }
            return View(m);      
        }
        [HttpPost]
        public IActionResult Add(Model.Blog m)
        {
            Model.Category ca = cadal.GetModelByBh(m.cabh);
            if(ca!=null)
            {
                m.caname = ca.caname;
            }
            if (m.id == 0)
            {
                //新增
                dal.insert(m);
            }
            else
            {
                //修改
                dal.update(m);
            }
            return Redirect("/Admin/Blog/Index");
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Del(int id)
        {
            dal.Delete(id);
            return Redirect("/Admin/Blog/Index");
        }


    }
}