using MeetingOrganizer.Models;
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
    public class RoomController : Controller
    { 
        // GET: Room
        public ActionResult Add()
        {            
            return View();
        }

        public ActionResult Index()
        {
            var roomList = new List<MOEntities.Room>();

            if (HttpContext.Cache["RoomList"] == null)
            {
                roomList = RoomRepository.GetAll();
                HttpContext.Cache.Insert("RoomList", roomList);
            }
            else
            {
                roomList = HttpContext.Cache["RoomList"] as List<MOEntities.Room>;
            }
            return View(roomList);
        }        
        [HttpPost]
        public ActionResult Add(Room room)
        {
            if (RoomRepository.Insert(room))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.HataMesaji = "Oda Eklenemedi.";
            }
            return View();
        }
        public JsonResult GetList()
        {
            var result = RoomRepository.GetAll();
            return Json(result,JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(int id)
        {
            var Room = RoomRepository.GetById(id);
            return View(Room);
        }
        [HttpPost]
        public ActionResult Edit(Room rm)
        {
            if (RoomRepository.Update(rm))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.HataMesaji = "Lütfen Değişiklik Yapıp Tekrar Deneyiniz.";
            }
            return View(rm);
        }
        public JsonResult Delete(int id)
        {
            var deleteResult = RoomRepository.Delete(id);
            var result = new PostResult(deleteResult);
            return Json(result);
        }
    }
}