using BitirmeProjesi.Common.DTOs.Base;
using System;

namespace BitirmeProjesi.Common.DTOs.Maillist
{
    public class MaillistRequest : BaseDto
    {
        

        
        public string name { get; set; }
        
        public string email { get; set; }
        public DateTime? lastMailSentDate { get; set; }
        
        public string creatorIpAddress { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public int maillistGroupId { get; set; }
    }
}
