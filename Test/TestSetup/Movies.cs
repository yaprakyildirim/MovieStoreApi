using MovieStoreApi.DbOperations;
using MovieStoreApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApi.Test.TestSetup
{
    public static class Movies
    {
        public static void AddActors(this MovieStoreDbContext context)
        {
            context.Movies.AddRange(
                    new Movie
                    {
                        GenreID = 1,
                        Title = "After Life",
                        Year = "2015",
                        Director = "Chad Stahelski",
                        Actors = "Dany Won, Henry Doe",
                        Price = 50,
                        IsActive = true
                    },

                    new Movie
                    {
                        GenreID = 3,
                        Title = "Ugly Betty",
                        Year = "2020",
                        Director = "Ashley Jensen",
                        Actors = " Tom Jerry, Jhon Thenissen",
                        Price = 45,
                        IsActive = true
                    });
        }
    }
}
