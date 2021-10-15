using BitirmeProjesi.Common.DTOs.Base;
using System;
using BitirmeProjesi.Common.Models;

namespace BitirmeProjesi.Common.DTOs.Member
{
    public class MemberResponse : BaseDto
    {
        public string firstname { get; set; }
        public string surname { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public DateTime? birthDate { get; set; }
        public string phonenumber { get; set; }
        public string mobilePhonenumber { get; set; }
        public string address { get; set; }
        public int? tcId { get; set; }
        public string status { get; set; }
        public DateTime? lastLoginDate { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public DateTime? lastMailSentDate { get; set; }
        public string lastIp { get; set; }
        public bool? allowedToCampaigns { get; set; }
        public string deviceType { get; set; }
        public string deviceInfo { get; set; }
        public int CountryId { get; set; }
        public int LocationId { get; set; }
        public bool isAdmin { get; set; }
        public GetAccessToken AccessToken { get; set; }
    }
}