using BitirmeProjesi.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace BitirmeProjesi.Model.SeedData
{
    public class OrderSeedData : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(
                new Order
                {
                    Id = 1,
                    amount = 5,
                    status = "Beklemede",
                    bankName = "GBVA",
                    clientIp = "127.0.0.1",
                    createdAt = DateTime.Now,
                    customerEmail = "1@1.com",
                    customerFirstname = "Mahmut",
                    customerPhone = "1111",
                    customerSurname = "Mahmudow",
                    deviceType = "Android",
                    finalAmount = 500,
                    shippingAmount = 1,
                    taxAmount = 2,
                    transactionId = "Sip1",
                    billingAdresId = 1,
                    hasUserNote = false,
                    memberGroupName = "1",
                    paymentGatewayCode = "1",
                    paymentGatewayName = "1",
                    paymentProviderCode = "1",
                    paymentProviderName = "1",
                    paymentTypeName = "1",
                    shippingCompanyName = "1",
                    shippingPaymentType = "1",
                    shippingProviderCode = "1",
                    shippingProviderName = "1",
                    shippingTrackingCode = "1",
                    ShippingAddressId = 1,
                    userAgent = "1"
                },
                new Order
                {
                    Id = 2,
                    amount = 5,
                    status = "Beklemede",
                    bankName = "GBVA",
                    clientIp = "127.0.0.1",
                    createdAt = DateTime.Now,
                    customerEmail = "1@1.com",
                    customerFirstname = "Mahmut",
                    customerPhone = "1111",
                    customerSurname = "Mahmudow",
                    deviceType = "Android",
                    finalAmount = 500,
                    shippingAmount = 1,
                    taxAmount = 2,
                    transactionId = "Sip1",
                    billingAdresId = 1,
                    hasUserNote = false,
                    memberGroupName = "1",
                    paymentGatewayCode = "1",
                    paymentGatewayName = "1",
                    paymentProviderCode = "1",
                    paymentProviderName = "1",
                    paymentTypeName = "1",
                    shippingCompanyName = "1",
                    shippingPaymentType = "1",
                    shippingProviderCode = "1",
                    shippingProviderName = "1",
                    shippingTrackingCode = "1",
                    ShippingAddressId = 1,
                    userAgent = "1"
                },
                new Order
                {
                    Id = 3,
                    amount = 5,
                    status = "Beklemede",
                    bankName = "GBVA",
                    clientIp = "127.0.0.1",
                    createdAt = DateTime.Now,
                    customerEmail = "1@1.com",
                    customerFirstname = "Mahmut",
                    customerPhone = "1111",
                    customerSurname = "Mahmudow",
                    deviceType = "Android",
                    finalAmount = 500,
                    shippingAmount = 1,
                    taxAmount = 2,
                    transactionId = "Sip1",
                    billingAdresId = 1,
                    hasUserNote = false,
                    memberGroupName = "1",
                    paymentGatewayCode = "1",
                    paymentGatewayName = "1",
                    paymentProviderCode = "1",
                    paymentProviderName = "1",
                    paymentTypeName = "1",
                    shippingCompanyName = "1",
                    shippingPaymentType = "1",
                    shippingProviderCode = "1",
                    shippingProviderName = "1",
                    shippingTrackingCode = "1",
                    ShippingAddressId = 1,
                    userAgent = "1"
                },
                new Order
                {
                    Id = 4,
                    amount = 5,
                    status = "Beklemede",
                    bankName = "GBVA",
                    clientIp = "127.0.0.1",
                    createdAt = DateTime.Now,
                    customerEmail = "1@1.com",
                    customerFirstname = "Mahmut",
                    customerPhone = "1111",
                    customerSurname = "Mahmudow",
                    deviceType = "Android",
                    finalAmount = 500,
                    shippingAmount = 1,
                    taxAmount = 2,
                    transactionId = "Sip1",
                    billingAdresId = 1,
                    hasUserNote = false,
                    memberGroupName = "1",
                    paymentGatewayCode = "1",
                    paymentGatewayName = "1",
                    paymentProviderCode = "1",
                    paymentProviderName = "1",
                    paymentTypeName = "1",
                    shippingCompanyName = "1",
                    shippingPaymentType = "1",
                    shippingProviderCode = "1",
                    shippingProviderName = "1",
                    shippingTrackingCode = "1",
                    ShippingAddressId = 1,
                    userAgent = "1"
                }
            );
        }
    }
}