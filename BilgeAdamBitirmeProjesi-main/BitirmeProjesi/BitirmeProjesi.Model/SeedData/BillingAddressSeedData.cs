using BitirmeProjesi.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BitirmeProjesi.Model.SeedData
{
    public class BillingAddressSeedData : IEntityTypeConfiguration<BillingAddress>
    {
        public void Configure(EntityTypeBuilder<BillingAddress> builder)
        {
            builder.HasData(
                new BillingAddress
                {
                    Id = 1,
                    address = "Adres1",
                    firstname = "1",
                    country = "TR",
                    location = "İST",
                    phonenumber = "1",
                    surname = "1",
                    mobilePhonenumber = "555",
                    subLocation = "1",
                    identityRegistrationnumber = 1,
                    invoiceType = "1",
                    orderId = 1,
                    taxNo = 1,
                    taxOffice = "1"
                }, new BillingAddress
                {
                    Id = 2,
                    address = "Adres2",
                    firstname = "2",
                    country = "TR",
                    location = "İST",
                    phonenumber = "2",
                    surname = "2",
                    mobilePhonenumber = "555",
                    subLocation = "2",
                    identityRegistrationnumber = 1,
                    invoiceType = "1",
                    orderId = 2,
                    taxNo = 1,
                    taxOffice = "1"
                }, new BillingAddress
                {
                    Id = 3,
                    address = "Adres3",
                    firstname = "3",
                    country = "TR",
                    location = "İST",
                    phonenumber = "3",
                    surname = "3",
                    mobilePhonenumber = "555",
                    subLocation = "3",
                    identityRegistrationnumber = 1,
                    invoiceType = "1",
                    orderId = 3,
                    taxNo = 1,
                    taxOffice = "1"
                }, new BillingAddress
                {
                    Id = 4,
                    address = "Adres3",
                    firstname = "3",
                    country = "TR",
                    location = "İST",
                    phonenumber = "3",
                    surname = "3",
                    mobilePhonenumber = "555",
                    subLocation = "3",
                    identityRegistrationnumber = 1,
                    invoiceType = "1",
                    orderId = 4,
                    taxNo = 1,
                    taxOffice = "1"
                });
        }
    }
}