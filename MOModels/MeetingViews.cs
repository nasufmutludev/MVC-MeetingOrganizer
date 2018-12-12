using MOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOModels
{
    public class MeetingViews
    {
        public int ID { get; set; }
        public string MeetingSubject { get; set; }        
        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public DateTime StartingTime { get; set; }
        public DateTime EndTime { get; set; }
        public virtual ICollection<Subscriber> Subscribers { get; set; }
        
    }
}
