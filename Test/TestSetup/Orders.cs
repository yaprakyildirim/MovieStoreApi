using MovieStoreApi.DbOperations;
using MovieStoreApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApi.Test.TestSetup
{
    public static class Orders
    {
        public static void AddActors(this MovieStoreDbContext context)
        {
            context.Orders.AddRange(
                 new Order { CustomerId = 1, MovieId = 1, purchasedTime = new DateTime(2020, 12, 12), IsActive = true },
                 new Order { CustomerId = 2, MovieId = 1, purchasedTime = new DateTime(2010, 06, 20), IsActive = true },
                 new Order { CustomerId = 3, MovieId = 2, purchasedTime = new DateTime(2005, 09, 01), IsActive = true }
                 );
        }
    }
}
