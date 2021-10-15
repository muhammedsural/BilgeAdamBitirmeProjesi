using BitirmeProjesi.Core.Entity;
using System;

namespace BitirmeProjesi.Model.Entities
{
    public class Maillist : CoreEntity
    {

        public string name { get; set; }
        public string email { get; set; }
        public DateTime? lastMailSentDate { get; set; }
        public string creatorIpAddress { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public MaillistGroup maillistGroupId { get; set; }
    }
}
