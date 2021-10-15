using System.ComponentModel.DataAnnotations;

namespace BitirmeProjesi.Web.UI.Areas.Admin.Models.UserViewModels
{
    public class CreateUserViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
