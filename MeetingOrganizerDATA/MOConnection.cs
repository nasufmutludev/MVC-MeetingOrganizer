using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingOrganizerDATA
{
    public class MOConnection
    {
        private static MOContext db = null;

        public static MOContext Init()
        {
            if (db == null)
            {
                db = new MOContext();
            }
            return db;
        }

    }
}

