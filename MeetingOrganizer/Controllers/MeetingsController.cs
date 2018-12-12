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
    public class MeetingsController : Controller
    {        
        private static List<SelectListItem> roomList;
        // GET: Meetings        
        public ActionResult Index()
        {            
            GetRoomListForDropDownList();
            return View();
        }
        
        
        public JsonResult GetList()
        {
            var result = MORepository.GetAll();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public MeetingsController()
        {
            if (roomList == null || RoomRepository.IsUpdated)
            {
                roomList = (from roomList in RoomRepository.GetAll()
                              select new SelectListItem()
                              {
                                  Text = roomList.RoomName,
                                  Value = roomList.ID.ToString()
                              }).ToList();

                RoomRepository.IsUpdated = false;
            }
        }
        public ActionResult Add()
        {
            GetRoomListForDropDownList();

            return View();
        }

        [HttpPost]
        public ActionResult Add(Meetings meeting)
        {

            if (MORepository.Insert(meeting))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.HataMesaji = "Toplantı eklenemedi!";
            }

            return View();
        }
        public JsonResult Delete(int id)
        {
            var deleteResult = MORepository.Delete(id);

            var result = new PostResult(deleteResult);

            return Json(result);
        }
        public ActionResult Edit(int id)
        {
            var meeting = MORepository.GetById(id);
            return View(meeting);
        }
        [HttpPost]
        public ActionResult Edit(Meetings meeting)
        {
            if (MORepository.Update(meeting))
            {
                return RedirectToAction("Index");
            }
            else
            {
                GetRoomListForDropDownList();
                ViewBag.HataMesaji = "Lütfen değişiklik yapıp tekrar deneyiniz!";
            }

            return View(meeting);
        }        
        private void GetRoomListForDropDownList()
        {
            if (TempData["RoomList"] == null)
            {
                TempData["RoomList"] = roomList;
            }
        }
    }
}