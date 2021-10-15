using BitirmeProjesi.Common.DTOs.Base;
namespace BitirmeProjesi.Common.DTOs.Tag
{
    public class TagResponse : BaseDto
    {
        public string name { get; set; }
        public string pageTitle { get; set; }
        public string metaDescription { get; set; }
        public string metaKeywords { get; set; }
    }
}
