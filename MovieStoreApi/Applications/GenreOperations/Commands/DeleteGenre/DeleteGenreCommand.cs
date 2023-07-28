using MovieStoreApi.DbOperations;

namespace MovieStoreApi.Applications.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public int GenreID { get; set; }
        private readonly IMovieStoreDbContext _movieStoreDbContext;

        public DeleteGenreCommand(IMovieStoreDbContext movieStoreDbContext)
        {
            _movieStoreDbContext = movieStoreDbContext;
        }

        public void Handle()
        {
            var genre = _movieStoreDbContext.Genres.SingleOrDefault(x => x.ID == GenreID);
            if (genre == null)
                throw new InvalidOperationException("Film türü Bulunamadı!");

            _movieStoreDbContext.Genres.Remove(genre);
            _movieStoreDbContext.SaveChanges();
        }
    }
}
