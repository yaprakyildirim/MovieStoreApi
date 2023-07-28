using MovieStoreApi.DbOperations;
using MovieStoreApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApi.Test.TestSetup
{
    public static class Genres
    {
        public static void AddActors(this MovieStoreDbContext context)
        {
            context.Genres.AddRange(
               new Genre{Name = "Komedi"},
               new Genre{Name = "Drama"},
               new Genre{Name = "Gerilim"}
               );
        }
    }
}
