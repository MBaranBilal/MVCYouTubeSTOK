﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCYouTubeSTOK.Models.Entity;

namespace MVCYouTubeSTOK.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri

        MVCYoutubeStokEntities db=new MVCYoutubeStokEntities();

        public ActionResult Index(string p)
        {
            var degerler=from d in db.TBLMUSTERILER select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler=degerler.Where(x=>x.MUSTERIAD.Contains(p));
            }
            return View(degerler.ToList());
            //var degerler=db.TBLMUSTERILER.ToList();
            //return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();  
        }


        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TBLMUSTERILER.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var musteri=db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var musteri = db.TBLMUSTERILER.Find(id);
            return View("MusteriGetir",musteri);
        }

        public ActionResult Guncelle(TBLMUSTERILER p1) 
        {
            var musteri=db.TBLMUSTERILER.Find(p1.MUSTERIID);
            musteri.MUSTERIAD = p1.MUSTERIAD;
            musteri.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}