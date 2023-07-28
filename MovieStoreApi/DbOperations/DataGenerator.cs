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

                 },
                 new Customer
                 {
                     FirstName = "Altun",
                     LastName = "Yıldırım",
                     Email = "altun@gmail.com",
                     Password = "a12345",
                     IsActive = true

                 }, 
                 new Customer
                 {
                     FirstName = "Yusuf",
                     LastName = "Yıldıran",
                     Email = "yusuf@gmail.com",
                     Password = "12345y",
                     IsActive = true

                 });   
                context.SaveChanges();
            }
        }
    }
}