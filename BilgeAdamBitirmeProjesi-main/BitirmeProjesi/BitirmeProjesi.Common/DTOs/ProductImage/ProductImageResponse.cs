using BitirmeProjesi.Common.DTOs.Base;
namespace BitirmeProjesi.Common.DTOs.ProductImage
{
    public class ProductImageResponse : BaseDto
    {
        public string filename { get; set; }
        public string extension { get; set; }
        public int? directoryName { get; set; }
        public int? revision { get; set; }
        public int sortOrder { get; set; }
        public int productId { get; set; }
        public string base64 { get; set; }
    }
}
