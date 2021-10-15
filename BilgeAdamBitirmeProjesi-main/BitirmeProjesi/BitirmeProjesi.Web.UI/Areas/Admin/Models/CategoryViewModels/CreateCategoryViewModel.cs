using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BitirmeProjesi.Web.UI.Areas.Admin.Models.CategoryViewModels
{
    public class CreateCategoryViewModel
    {
        public string name { get; set; }
        public bool status { get; set; }
        public string metaDescription { get; set; }
    }
}