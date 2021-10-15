﻿using BitirmeProjesi.Core.Entity;
using System;
using System.Collections.Generic;

namespace BitirmeProjesi.Model.Entities
{
    public class Order : CoreEntity
    {
        public Order()
        {
            orderItemsId = new HashSet<OrderItem>();
        }

        public string customerFirstname { get; set; }
        public string customerSurname { get; set; }
        public string customerEmail { get; set; }
        public string customerPhone { get; set; }
        public string paymentTypeName { get; set; }
        public string paymentProviderCode { get; set; }
        public string paymentProviderName { get; set; }
        public string paymentGatewayCode { get; set; }
        public string paymentGatewayName { get; set; }
        public string bankName { get; set; }
        public string clientIp { get; set; }
        public string userAgent { get; set; }
        public decimal amount { get; set; } // siparişin vergi hatiç fiyatı
        public decimal taxAmount { get; set; } // siparişin vergi fiyatı
        public decimal shippingAmount { get; set; } // siparişin kargo ücreti
        public decimal finalAmount { get; set; } // siparişin tüm ücreti
        public string transactionId { get; set; }
        public bool? hasUserNote { get; set; }
        public string status { get; set; }
        public string deviceType { get; set; }
        public string memberGroupName { get; set; }
        public string shippingProviderCode { get; set; }
        public string shippingProviderName { get; set; }
        public string shippingCompanyName { get; set; }
        public string shippingPaymentType { get; set; }
        public string shippingTrackingCode { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public Member? memberId { get; set; }
        public ICollection<OrderItem> orderItemsId { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
        public int ShippingAddressId { get; set; }
        public BillingAddress BillingAddress { get; set; }
        public int billingAdresId { get; set; }
    }
}