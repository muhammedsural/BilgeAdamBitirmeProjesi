using BitirmeProjesi.Common.DTOs.Base;
using System;
namespace BitirmeProjesi.Common.DTOs.ProductComment
{
    public class ProductCommentRequest : BaseDto
    {
        public string title { get; set; }
        public string content { get; set; }
        public bool status { get; set; }
        public int rank { get; set; }
        public bool isAnonymous { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public int memberId { get; set; }
        public int productId { get; set; }
    }
}
