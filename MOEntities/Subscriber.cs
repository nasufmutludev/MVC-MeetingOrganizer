using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOEntities
{
    public class Subscriber
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(50, ErrorMessage = "50 karakterden uzun olamaz")]
        [Required(ErrorMessage = "Lütfen Adınızı Giriniz")]
        public string  Name { get; set; }
        [MaxLength(50, ErrorMessage = "50 karakterden uzun olamaz")]
        [Required(ErrorMessage = "Lütfen Soyadınızı Giriniz")]
        public string Surname { get; set; }
        public System.Nullable<int> MeetingID { get; set; }
        [ForeignKey("MeetingID")]
        public virtual Meetings Meetings { get; set; }
    }
}
