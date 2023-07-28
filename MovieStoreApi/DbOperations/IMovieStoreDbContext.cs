using Microsoft.EntityFrameworkCore;
using MovieStoreApi.Entities;

namespace MovieStoreApi.DbOperations
{
    public interface IMovieStoreDbContext
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Customer> Customers { get; set; }        
        public DbSet<Director> Directors { get; set; }
        public DbSet<Order> Orders { get; set; }

        DbSet<Movie> Movies { get; set; }
        DbSet<Genre> Genres { get; set; }

        int SaveChanges();
    }
}
