using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCYouTubeSTOK.Models.Entity;

namespace MVCYouTubeSTOK.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        public ActionResult Index()
        {
            return View();
        }

        MVCYoutubeStokEntities db=new MVCYoutubeStokEntities();

        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(TBLSATIS satis)
        {
            db.TBLSATIS.Add(satis);
            db.SaveChanges();
            return View("Index");
        }
    }
}