using System.ComponentModel.DataAnnotations;

namespace DemoProduct.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Lütfen isminizi giriniz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen soyisminizi giriniz")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Lütfen mail adresinizi giriniz")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Lütfen şifre giriniz")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen şifreyi tekrar giriniz")]
        [Compare("Password", ErrorMessage = "Şifreler Eşleşmiyor")]
        public string ConfirmPassword { get; set; }
    }
}
