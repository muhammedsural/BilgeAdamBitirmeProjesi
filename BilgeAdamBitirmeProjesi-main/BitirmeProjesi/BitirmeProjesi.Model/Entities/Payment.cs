using BitirmeProjesi.Core.Entity;
using System;

namespace BitirmeProjesi.Model.Entities
{
    public class Payment : CoreEntity
    {
        public string memberFirstname { get; set; }
        public string memberSurname { get; set; }
        public string memberEmail { get; set; }
        public string memberPhone { get; set; }
        public string paymentTypeName { get; set; }
        public string paymentProviderCode { get; set; }
        public string paymentProviderName { get; set; }
        public string paymentGatewayName { get; set; }
        public string paymentGatewayCode { get; set; }
        public string bankName { get; set; }
        public string deviceType { get; set; }
        public string clientIp { get; set; }
        public string currencyRates { get; set; }
        public decimal amount { get; set; }
        public decimal finalAmount { get; set; }
        public decimal? sumOfGainedPoints { get; set; }
        public decimal installment { get; set; }
        public decimal installmentRate { get; set; }
        public int? extraInstallment { get; set; }
        public string currency { get; set; }
        public int? transactionId { get; set; }
        public string memberNote { get; set; }
        public string userNote { get; set; }
        public string status { get; set; }
        public string errorMessage { get; set; }
        public string cardSavingSystem { get; set; }
        public DateTime? createdAt { get; set; }
        public Member memberid { get; set; }

    }
}
