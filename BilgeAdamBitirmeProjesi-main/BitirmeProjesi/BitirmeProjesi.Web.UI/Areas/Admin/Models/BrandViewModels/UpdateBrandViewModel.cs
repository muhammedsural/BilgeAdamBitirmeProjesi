using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BitirmeProjesi.Web.UI.Areas.Admin.Models.BrandViewModels
{
    public class UpdateBrandViewModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public bool status { get; set; }
        public string brandImage { get; set; }
    }
}