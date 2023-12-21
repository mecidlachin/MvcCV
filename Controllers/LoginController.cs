using MvcCV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Description;

namespace MvcCV.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblAdmin p)
        {
            DbCVEntities1 db = new DbCVEntities1();
            var userinfo = db.TblAdmin.FirstOrDefault(x => x.KullaniciAdi == p.KullaniciAdi && x.Sifre == p.Sifre);

            if (userinfo != null)
            {
                FormsAuthentication.SetAuthCookie(userinfo.KullaniciAdi, false);
                Session["KullaniciAdi"] = userinfo.KullaniciAdi.ToString();
                return RedirectToAction("Index", "Deneyim");
            }
            else
            {
                // Eğer kullanıcı adı veya şifre hatalıysa uyarı mesajı oluşturur
                TempData["ErrorMessage"] = "Kullanıcı Adı veya Şifre Hatalı! Lütfen Bilgileri Kontrol Ediniz";

                // Hata durumunda giriş sayfasına yönlendirir
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }


    }
}