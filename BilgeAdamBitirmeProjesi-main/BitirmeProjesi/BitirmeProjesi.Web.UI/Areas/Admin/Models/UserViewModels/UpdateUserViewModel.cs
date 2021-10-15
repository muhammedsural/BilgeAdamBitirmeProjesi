using System;
using System.ComponentModel.DataAnnotations;

namespace BitirmeProjesi.Web.UI.Areas.Admin.Models.UserViewModels
{
    public class UpdateUserViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
