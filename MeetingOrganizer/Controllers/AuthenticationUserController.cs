using MeetingOrganizerDATA;
using MOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MeetingOrganizer.Controllers
{    
    public class AuthenticationUserController : Controller
    {
        // GET: AuthenticationUser
        MOContext db = new MOContext();
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(User users)
        {
            var user = db.Users.FirstOrDefault(x => x.Username == users.Username && x.Password == users.Password);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Username,false);
                return RedirectToAction("Index", "Meetings");
            }
            else
            {
                ViewBag.Message = "Geçersiz Kullanıcı Adı veya Şifre";
                return View();
            }            
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}