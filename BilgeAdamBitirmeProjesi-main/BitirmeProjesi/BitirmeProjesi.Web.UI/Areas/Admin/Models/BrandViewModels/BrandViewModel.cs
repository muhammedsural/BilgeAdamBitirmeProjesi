using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BitirmeProjesi.Web.UI.Areas.Admin.Models.BrandViewModels
{
    public class BrandViewModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public bool status { get; set; }
    }
}