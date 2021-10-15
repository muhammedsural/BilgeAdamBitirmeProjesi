using BitirmeProjesi.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BitirmeProjesi.Model.SeedData
{
    public class ShippingAddressSeedData : IEntityTypeConfiguration<ShippingAddress>
    {
        public void Configure(EntityTypeBuilder<ShippingAddress> builder)
        {
            builder.HasData(
                new ShippingAddress
                {
                    Id = 1,
                    address = "Adres1",
                    firstname = "1",
                    country = "TR",
                    location = "İST",
                    phonenumber = "1",
                    surname = "1",
                    mobilePhonenumber = "555",
                    subLocation = "1"
                }, new ShippingAddress
                {
                    Id = 2,
                    address = "Adres2",
                    firstname = "2",
                    country = "TR",
                    location = "İST",
                    phonenumber = "2",
                    surname = "2",
                    mobilePhonenumber = "555",
                    subLocation = "2"
                }, new ShippingAddress
                {
                    Id = 3,
                    address = "Adres3",
                    firstname = "3",
                    country = "TR",
                    location = "İST",
                    phonenumber = "3",
                    surname = "3",
                    mobilePhonenumber = "555",
                    subLocation = "3"
                });
        }
    }
}