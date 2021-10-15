using System;
using BitirmeProjesi.Common.Models;

namespace BitirmeProjesi.Web.UI.Infrastructure.Helpers
{
    public class CookieModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImagePath { get; set; }
        public GetAccessToken AccessToken { get; set; }
    }
}
