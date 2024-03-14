using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DinamikBlogSite.Models.Entity;


namespace DinamikBlogSite.Controllers
{
    
    public class AdminController : Controller
    {
        BlogSiteDBEntities1 db=new BlogSiteDBEntities1();


		//GİRİŞ İŞLEMLERİ
		/****************************************************************************************/

		public ActionResult Index()
        {
           var degerler=db.TBLGİRİS.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniGiris()
        { 
            return View(); 
        }
        [HttpPost]
		public ActionResult YeniGiris(TBLGİRİS p)
		{
            db.TBLGİRİS.Add(p);
            db.SaveChanges();
			return RedirectToAction("Index");
		}
        public ActionResult GirisSil(int id)
        { 
            var girisSil=db.TBLGİRİS.Find(id);
            db.TBLGİRİS.Remove(girisSil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult GirisGuncelle(int id)
        {
            var gg = db.TBLGİRİS.Find(id);
            return View(gg);
        }
        [HttpPost]
        public ActionResult GirisGuncelle(TBLGİRİS p)
        {
            var deger = db.TBLGİRİS.Find(p.GirisID);
            deger.GirisID = p.GirisID;
            deger.GirisText1 = p.GirisText1;
            deger.GirisAdSoyad = p.GirisAdSoyad;
            deger.GirisText2 = p.GirisText2;
            db.TBLGİRİS.AddOrUpdate(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
		//HAKKIMDA İŞLEMLERİ
		/****************************************************************************************/

		public ActionResult hakkimda()
        {
            var hakk=db.TBLHAKKİMDA.ToList();
            return View(hakk);
        }
        [HttpGet]
        public ActionResult YeniHakkimda() 
        { 
            return View();
        }
        [HttpPost]
        public ActionResult YeniHakkimda(TBLHAKKİMDA p)
        {
            db.TBLHAKKİMDA.Add(p);
            db.SaveChanges();
            return RedirectToAction("hakkimda");
        }
        public ActionResult HakkimdaSil(int id)
        {
            var sil=db.TBLHAKKİMDA.Find(id);
            db.TBLHAKKİMDA.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("hakkimda");
        }
        [HttpGet]
        public ActionResult HakkımdaGuncelle(int id)
        {
            var hg = db.TBLHAKKİMDA.Find(id);
           return View(hg);
        }
		[HttpPost]
		public ActionResult HakkımdaGuncelle(TBLHAKKİMDA p)
		{
			var deger=db.TBLHAKKİMDA.Find(p.HakkimdaID);
            deger.HakkımdaAciklama=p.HakkımdaAciklama;
			db.TBLHAKKİMDA.AddOrUpdate(deger);
			db.SaveChanges();
            return RedirectToAction("hakkimda");
		}

		//CARD İŞLEMLERİ
		/****************************************************************************************/

		public ActionResult Cards()
        {
            var card=db.TBLCARDS.ToList();
            return View(card);
        }
        [HttpGet]
        public ActionResult YeniKard()
        {
            return View();
        }

		[HttpPost]
		public ActionResult YeniKard(TBLCARDS p)
		{
            db.TBLCARDS.Add(p);
            db.SaveChanges();
			return RedirectToAction("Cards");
		}
        public ActionResult KardSil(int id)
        {
            var sil=db.TBLCARDS.Find(id);
            db.TBLCARDS.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("Cards");
        }

        [HttpGet]
        public ActionResult KardGuncelle(int id) {
            var kg=db.TBLCARDS.Find(id);
            return View(kg);
        }
        [HttpPost]
        public ActionResult KardGuncelle(TBLCARDS p) 
        {
            var deger = db.TBLCARDS.Find(p.CardID);
          deger.CardBaslik=p.CardBaslik;
            deger.CardAciklama=p.CardAciklama;
            deger.cardButon = p.cardButon;
            db.TBLCARDS.AddOrUpdate(deger);
            db.SaveChanges();
            return RedirectToAction("Cards");
        }
		//ADMİN İŞLEMLERİ
		/****************************************************************************************/
		public ActionResult Admin()
        { 
            var admin=db.TBLADMİN.ToList();
            
            return View(admin); 
        }
        [HttpGet]
        public ActionResult AdminGuncelle(int id)
        {
            var ag=db.TBLADMİN.Find(id);
            return View(ag);
        }
		[HttpPost]
		public ActionResult AdminGuncelle(TBLADMİN p)
		{
			var ag = db.TBLADMİN.Find(p.AdminID);
			ag.AdminUserName=p.AdminUserName;
            ag.AdminPassword=p.AdminPassword;
            db.TBLADMİN.AddOrUpdate(ag);
            db.SaveChanges();
            return RedirectToAction("Admin");
		}
	}
}