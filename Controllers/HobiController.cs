using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using MvcCV.Repositories;

namespace MvcCV.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        GenericRepository<TblHobilerim> repo = new GenericRepository<TblHobilerim>();
        [HttpGet]
        public ActionResult Index()
        {
            var hobiler = repo.List();
            return View(hobiler);
        }
        [HttpPost]
        public ActionResult Index(TblHobilerim p)
        {
            var degerler = repo.Find(x => x.ID == 1);
            degerler.Aciklama1 = p.Aciklama1;
            degerler.Aciklama2 = p.Aciklama2;
            repo.TUpdate(degerler);
            var hobiler = repo.List();
            return RedirectToAction("Index");
        }

    }
}