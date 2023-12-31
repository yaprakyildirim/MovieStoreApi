﻿using Microsoft.EntityFrameworkCore;
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
                //Actor Info
                context.Actors.AddRange(
                  new Actor { FirstName = "Ricky", LastName = "Gervais", PlayedMovies = "After Life", IsAvtive = true },
                  new Actor { FirstName = "Tom", LastName = "Basden", PlayedMovies = "Quacks", IsAvtive = true },
                  new Actor { FirstName = "Tony", LastName = "Way", PlayedMovies = "Gökdelen", IsAvtive = true },
                  new Actor { FirstName = "Diane", LastName = "Morgan", PlayedMovies = "After Life", IsAvtive = true },
                  new Actor { FirstName = "Ashley", LastName = "Jensen", PlayedMovies = "Ugly Betty", IsAvtive = true },
                  new Actor { FirstName = "Silvio", LastName = "Horta", PlayedMovies = "Ugly Betty", IsAvtive = true }
                  );
                context.SaveChanges();

                //Customer Info
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

                //Director Info
                context.Directors.AddRange(
                  new Director { FirstName = "Ricky", LastName = "Gervais", FilmsDirected = "After Life", IsActive = true },
                  new Director { FirstName = "Ashley", LastName = "Jensen", FilmsDirected = "Ugly Betty", IsActive = true },
                  new Director { FirstName = "Silvio", LastName = "Horta", FilmsDirected = "Ugly Betty", IsActive = true }
                  );
                context.SaveChanges();

                //Genre Info
                context.Genres.AddRange(
                   new Genre
                   {
                       Name = "Komedi"
                   },
                   new Genre
                   {
                       Name = "Drama"
                   },
                   new Genre
                   {
                       Name = "Gerilim"
                   }
               );
                context.SaveChanges();

                //Movies Info
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
                context.SaveChanges();


                //Order
                context.Orders.AddRange(
                 new Order { CustomerId = 1, MovieId = 1, purchasedTime = new DateTime(2020, 12, 12), IsActive = true },
                 new Order { CustomerId = 2, MovieId = 1, purchasedTime = new DateTime(2010, 06, 20), IsActive = true },
                 new Order { CustomerId = 3, MovieId = 2, purchasedTime = new DateTime(2005, 09, 01), IsActive = true }
                 );
                context.SaveChanges();
            }
        }
    }
}