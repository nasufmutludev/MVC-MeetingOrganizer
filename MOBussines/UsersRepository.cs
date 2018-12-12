using MeetingOrganizerDATA;
using MOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOBussines
{
    public class UsersRepository
    {
        static MOContext db = MOConnection.Init();
        public static bool IsUpdated;
        public static List<User> GetAll()
        {
            return db.Users.ToList();
        }
        public static bool Insert(User item)
        {
            db.Users.Add(item);
            return db.SaveChanges() > 0 ? true : false;
        }
        public static User GetById(int id)
        {
            return db.Users.Find(id);
        }
        public static bool Update(User item)
        {
            var Item = db.Users.Find(item.ID);
            Item.ID = item.ID;
            Item.Mail = item.Mail;
            Item.Username = item.Username;
            Item.Password = item.Password;
            Item.Role = item.Role;
            return db.SaveChanges() > 0 ? true : false;
        }
        public static bool Delete(int id)
        {
            var item = db.Users.Find(id);
            db.Users.Remove(item);
            return db.SaveChanges() > 0 ? true : false;
        }
    }
}
