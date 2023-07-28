using MovieStoreApi.DbOperations;
using MovieStoreApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApi.Test.TestSetup
{
    public static class Customers
    {
        public static void AddActors(this MovieStoreDbContext context)
        {
            context.Customers.AddRange(
                new Customer
                {
                    FirstName = "Yaprak",
                    LastName = "Yildirim",
                    Email = "yaprakyildirim@gmail.com",
                    Password = "111111",
                    IsActive = true

                },
                new Customer
                {
                    FirstName = "Cem",
                    LastName = "Günveren",
                    Email = "cem@gmail.com",
                    Password = "123456",
                    IsActive = true

                });
        }
    }
}
