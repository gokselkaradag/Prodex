using System.ComponentModel.DataAnnotations;

namespace DemoProduct.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Lütfen mailinizi giriniz")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz")]
        public string Password { get; set; }
    }
}
