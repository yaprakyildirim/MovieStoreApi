using MovieStoreApi.DbOperations;
using MovieStoreApi.Entities;

namespace MovieStoreApi.Test.TestSetup
{
    public static class Actors
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
