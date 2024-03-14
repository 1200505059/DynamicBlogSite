using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DinamikBlogSite.Models.Entity;
namespace DinamikBlogSite.Controllers
{
    public class LoginController : Controller
    {
        BlogSiteDBEntities1 db= new BlogSiteDBEntities1();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
		public ActionResult Index(TBLADMİN p)
		{
            var c = db.TBLADMİN.FirstOrDefault(x=>x.AdminUserName==p.AdminUserName && x.AdminPassword==p.AdminPassword);
            if (c!=null)
            {
                return RedirectToAction("Index","Admin");
            }
            else {
                return RedirectToAction("Index");
                
            }
			
		}
	}
}