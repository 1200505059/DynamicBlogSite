using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DinamikBlogSite.Models.Entity;
namespace DinamikBlogSite.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
       BlogSiteDBEntities1 db=new BlogSiteDBEntities1();
        public ActionResult Index()
        {
			using (var db = new BlogSiteDBEntities1())
			{
                var haber=db.TBLCARDS.ToList();
                ViewBag.haber = haber;
                var giris=db.TBLGİRİS.ToList();
                ViewBag.giris=giris;
				var hakkimda = db.TBLHAKKİMDA.ToList();
				ViewBag.list = hakkimda;
				return View();
			}
		}
      
        public ActionResult haber()
        {
            
            return View();
        }
        public ActionResult hakkımda()
        {
            return View();
            
        }
        public ActionResult PartialFooter()
        {
            return View();
        }
     

    }
}