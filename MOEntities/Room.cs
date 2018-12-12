using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOEntities
{
    public class Room: Entity
    {
        [Display(Name="Oda")]
        public string RoomName { get; set; }
    }
}
