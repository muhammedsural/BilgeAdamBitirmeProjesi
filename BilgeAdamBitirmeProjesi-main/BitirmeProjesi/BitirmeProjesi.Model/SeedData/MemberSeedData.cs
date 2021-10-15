using BitirmeProjesi.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Model.SeedData
{
    public class MemberSeedData : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasData(
                new Member
                {
                    Id = 1,
                    firstname = "member",
                    surname = "member",
                    email = "member@member.com",
                    gender = "male",
                    birthDate = DateTime.Parse("10.03.1988"),
                    phonenumber = "55555555",
                    mobilePhonenumber = "55555555",
                    address = "beylikdüzü",
                    password = "123",
                    CountryId = 1,
                    LocationId = 1,
                    isAdmin = false
                },
                new Member
                {
                    Id = 2,
                    firstname = "admin",
                    surname = "admin",
                    email = "admin@admin.com",
                    gender = "male",
                    birthDate = DateTime.Parse("10.03.1988"),
                    phonenumber = "55555555",
                    mobilePhonenumber = "55555555",
                    address = "beylikdüzü",
                    password = "123",
                    CountryId = 1,
                    LocationId = 1,
                    isAdmin = true
                }
            );
        }
    }
}