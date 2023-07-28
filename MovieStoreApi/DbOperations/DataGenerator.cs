using Microsoft.EntityFrameworkCore;
using MovieStoreApi.Entities;

namespace MovieStoreApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {
                if (context.Movies.Any())
                {
                    return;
                }

                context.Actors.AddRange(
                  new Actor { FirstName = "Ricky", LastName = "Gervais", PlayedMovies = "After Life", IsAvtive = true },
                  new Actor { FirstName = "Tom", LastName = "Basden", PlayedMovies = "Quacks", IsAvtive = true },
                  new Actor { FirstName = "Tony", LastName = "Way", PlayedMovies = "Gökdelen", IsAvtive = true },
                  new Actor { FirstName = "Diane", LastName = "Morgan", PlayedMovies = "After Life", IsAvtive = true },
                  new Actor { FirstName = "Ashley", LastName = "Jensen", PlayedMovies = "Ugly Betty", IsAvtive = true },
                  new Actor { FirstName = "Silvio", LastName = "Horta", PlayedMovies = "Ugly Betty", IsAvtive = true }
                  );
                context.SaveChanges();
            }
        }

    }
}