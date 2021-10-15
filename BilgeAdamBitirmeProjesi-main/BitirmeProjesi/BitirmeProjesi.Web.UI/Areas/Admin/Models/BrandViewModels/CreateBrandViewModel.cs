using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BitirmeProjesi.Web.UI.Areas.Admin.Models.BrandViewModels
{
    public class CreateBrandViewModel
    {
        public string name { get; set; }
        public bool status { get; set; }
        public string brandImage { get; set; }
    }
}