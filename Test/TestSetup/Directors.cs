using MovieStoreApi.DbOperations;
using MovieStoreApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApi.Test.TestSetup
{
    public static class Directors
    {
        public static void AddActors(this MovieStoreDbContext context)
        {
            context.Actors.AddRange(
                  new Actor { FirstName = "Ricky", LastName = "Gervais", PlayedMovies = "After Life", IsAvtive = true },
                  new Actor { FirstName = "Tom", LastName = "Basden", PlayedMovies = "Quacks", IsAvtive = true },
                  new Actor { FirstName = "Tony", LastName = "Way", PlayedMovies = "Gökdelen", IsAvtive = true }
                  );
        }
    }
}
