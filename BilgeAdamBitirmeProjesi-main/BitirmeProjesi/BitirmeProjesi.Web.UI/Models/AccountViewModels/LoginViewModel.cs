using System.ComponentModel.DataAnnotations;

namespace BitirmeProjesi.Web.UI.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "E-Posta adresi gereklidir.")]
        [Display(Name = "E-Posta")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Parola gereklidir.")]
        [Display(Name = "Parola")]
        public string Password { get; set; }
    }
}
