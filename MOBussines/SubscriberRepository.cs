using MeetingOrganizerDATA;
using MOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOBussines
{
    public class SubscriberRepository
    {
        static MOContext db = MOConnection.Init();
        public static bool IsUpdated;
        public static List<Subscriber> GetAll()
        {
            return db.Subscribers.ToList();
        }
    }
}
