using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Common.Model
{
    public class SignupModel : LoginModel
    {
        public SignupModel()
        {
            RoleList = new List<CustomSelectListItem>();
            Roles = new List<string>();
        }

        [Display(Name="Ad"),Required]
        public string Name { get; set; }

        [Display(Name = "Soyad"), Required]
        public string Surname { get; set; }

        [Display(Name = "Şifre Tekrar"), Required]
        [Compare("Password",ErrorMessage ="Girdiğiniz şifreler uyuşmuyor")]
        public string PasswordConfirm { get; set; }

        [Display(Name = "Roller")]
        public List<CustomSelectListItem> RoleList { get; set; }

        public List<string> Roles { get; set; }

    }
}
