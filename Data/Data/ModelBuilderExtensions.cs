using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(
                        new Person
                        {
                            PersonId = new Guid("61d6f3a9-4f1a-4148-8dd2-d82d2372f627"),
                            FirstName = "Ivan",
                            Surname = "Petrov",
                            DateOfBirth = new DateTime(1978, 3, 23),
                            Address = "Bulgaria",
                            Phone = "+359 88 9123456",
                            IBAN = "BG89UNCR70008359568951"
                        },
                        new Person
                        {
                            PersonId = new Guid("cb0c7e8e-419f-4f18-b482-d19eb5e79408"),
                            FirstName = "John",
                            Surname = "Doe",
                            DateOfBirth = new DateTime(1988, 5, 3),
                            Address = "UK",
                            Phone = "+44 7911 123456",
                            IBAN = "GB77BARC20037884596399"
                        });
        }
    }
}
