using MeetingOrganizerDATA;
using MOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOBussines
{
    public class RoomRepository
    {
        static MOContext db = MOConnection.Init();
        public static bool IsUpdated;

        public static List<Room> GetAll()
        {
            return db.Rooms.ToList();
        }

        public static bool Insert(Room item)
        {
            db.Rooms.Add(item);
            return db.SaveChanges() > 0 ? true : false;
        }
        public static Room GetById(int id)
        {
            return db.Rooms.Find(id);
        }
        public static bool Update(Room item)
        {
            var Item = db.Rooms.Find(item.ID);
            Item.ID = item.ID;           
            Item.RoomName = item.RoomName;
            return db.SaveChanges() > 0 ? true : false;
        }
        public static bool Delete(int id)
        {
            var item = db.Rooms.Find(id);
            db.Rooms.Remove(item);
            return db.SaveChanges() > 0 ? true : false;
        }
    }
}
