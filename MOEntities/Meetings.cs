using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MOEntities
{
    public class Meetings: Entity
    {
        [Required(ErrorMessage = "Lütfen Toplantı Konusunu Belirtiniz")]
        [Display(Name = "Toplantı Konusu")]
        public string MeetingSubject { get; set; }
        [Required(ErrorMessage = "Lütfen Bir Toplantı Açıklaması Yazınız")]
        [Display(Name = "Oda")]        
        public int RoomID { get; set; }
        [Display(Name = "Başlangıç Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [Required(ErrorMessage = "Toplantının Başlangıç Saatini Belirtiniz")]
        public DateTime StartingTime { get; set; }
        [Display(Name = "Başlangıç Saati")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [Required(ErrorMessage = "Toplantının Başlangıç Bitiş Belirtiniz")]
        public DateTime EndTime { get; set; }
        [Display(Name = "Katılımcılar")]
        public ICollection<Subscriber> Subscribers { get; set; }
        
    }
}
