using MeetingOrganizerDATA;
using MOEntities;
using MOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MOBussines
{
    public static class MORepository
    {
        static MOContext db = MOConnection.Init();
        public static IQueryable<MeetingViews> GetAll()
        {
            var sorgu = from m in db.Meetings
                        join r in db.Rooms on m.RoomID equals r.ID
                        select new MeetingViews()
                        {
                            ID = m.ID,
                            MeetingSubject = m.MeetingSubject,                            
                            RoomName = r.RoomName,
                            StartingTime = m.StartingTime,
                            EndTime = m.EndTime
                        };
            return sorgu;
        }
        public static bool Delete(int id)
        {
            var item = db.Meetings.Find(id);
            db.Meetings.Remove(item);
            return db.SaveChanges() > 0 ? true : false;
        }
        public static bool Update(Meetings item)
        {
            var Item = db.Meetings.Find(item.ID);
            Item.MeetingSubject = item.MeetingSubject;            
            Item.RoomID = item.RoomID;
            Item.StartingTime = item.StartingTime;
            Item.EndTime = item.EndTime;
            return db.SaveChanges() > 0 ? true : false;
        }
        public static Meetings GetById(int id)
        {
            return db.Meetings.Find(id);
        }
        public static bool Insert(Meetings item)
        {
            db.Meetings.Add(item);
            return db.SaveChanges() > 0 ? true : false;
        }                
    }
}
