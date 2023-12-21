using MvcCV.Models.Entity;
using MvcCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class HakkımdaController : Controller
    {
        // GET: Hakkımda
        DbCVEntities1 db = new DbCVEntities1();
        GenericRepository<TblHakkimda> repo = new GenericRepository<TblHakkimda>();
        [HttpGet]
        public ActionResult Index()
        {
            var hakkimda = repo.List();
            return View(hakkimda);
        }
        [HttpPost]
        public ActionResult Index(TblHakkimda p)
        {
            var degerler = repo.Find(x => x.ID == 1);
            degerler.Ad = p.Ad;
            degerler.Soyad = p.Soyad;
            degerler.Adres = p.Adres;
            degerler.Mail = p.Mail;
            degerler.Telefon = p.Telefon;
            degerler.Aciklama = p.Aciklama;
            degerler.Resim = p.Resim;
            repo.TUpdate(degerler);
            var hobiler = repo.List();
            return RedirectToAction("Index");
        }
    }
}