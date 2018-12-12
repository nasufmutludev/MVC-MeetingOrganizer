using MeetingOrganizerDATA;
using MOBussines;
using MOEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MeetingOrganizer.Controllers
{
    public class SubscriberController : Controller
    {
        MOContext db = new MOContext();
        // GET: Subscriber
        public ActionResult Index()
        {
            return View(db.Subscribers.ToList());
        }
        public JsonResult GetList()
        {
            var result = SubscriberRepository.GetAll();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]// Create Get
        public ActionResult Create()
        {
            #region DDL Toplanti Doldurma
            List<SelectListItem> IcerikListele =
                     (from k in db.Meetings
                      select new SelectListItem
                      {
                          Text = k.MeetingSubject,
                          Value = k.ID.ToString()
                      }).ToList();
            #endregion
            ViewBag.Liste = IcerikListele;
            return View();
        }
        [HttpPost]// Create Get
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Surname,MeetingID")]Subscriber kt)
        {
            if (ModelState.IsValid)
            {
                db.Subscribers.Add(kt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kt);
        }
        public ActionResult Edit(int? id) //Edit Get
        {
            #region DDL Toplanti Doldurma
            List<SelectListItem> IcerikListele =
                     (from k in db.Meetings
                      select new SelectListItem
                      {
                          Text = k.MeetingSubject,
                          Value = k.ID.ToString()
                      }).ToList();



            ViewBag.Liste = IcerikListele;


            #endregion

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscriber kt = db.Subscribers.Find(id);
            if (kt == null)
            {
                return HttpNotFound();
            }

            return View(kt);
        }
        [HttpPost]//Edit Post
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Surname,MeetingID")]Subscriber kt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kt);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscriber kt = db.Subscribers.Find(id);
            if (kt == null)
            {
                return HttpNotFound();
            }

            return View(kt);
        }

        //Post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Subscriber kt = db.Subscribers.Find(id);
            db.Subscribers.Remove(kt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
    
