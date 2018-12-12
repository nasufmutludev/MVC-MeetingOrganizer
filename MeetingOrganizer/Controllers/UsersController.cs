using MeetingOrganizerDATA;
using MOBussines;
using MOEntities;
using MVCIntroduction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeetingOrganizer.Controllers
{
    [Authorize(Roles ="admin")]
    public class UsersController : Controller
    {
        // GET: Users
        MOContext db = new MOContext();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetList()
        {
            var result = UsersRepository.GetAll();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult Add(User users)
        {

            if (UsersRepository.Insert(users))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.HataMesaji = "Kullanıcı eklenemedi!";
            }

            return View();
        }
        public JsonResult Delete(int id)
        {
            var deleteResult = UsersRepository.Delete(id);

            var result = new PostResult(deleteResult);

            return Json(result);
        }
        public ActionResult Edit(int id)
        {            
            var user = UsersRepository.GetById(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(User users)
        {
            if (UsersRepository.Update(users))
            {
                return RedirectToAction("Index");
            }
            else
            {                
                ViewBag.HataMesaji = "Lütfen değişiklik yapıp tekrar deneyiniz!";
            }

            return View(users);
        }
    }
}