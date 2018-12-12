using System.ComponentModel.DataAnnotations;

namespace ECommerce.Common.Model
{
    public class LoginModel
    {
        [Display(Name = "Email"), Required]
        public string Email { get; set; }

        [Display(Name ="Şifre"),Required]
        public string Password { get; set; }

        public string PreviousUrl { get; set; }
    }
}
