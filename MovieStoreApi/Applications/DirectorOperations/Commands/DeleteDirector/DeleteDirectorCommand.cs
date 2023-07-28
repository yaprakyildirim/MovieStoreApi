using MovieStoreApi.DbOperations;

namespace MovieStoreApi.Applications.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommand
    {
        public int DirectorId { get; set; }
        private readonly IMovieStoreDbContext _movieStoreDbContext;

        public DeleteDirectorCommand(IMovieStoreDbContext movieStoreDbContext)
        {
            _movieStoreDbContext = movieStoreDbContext;
        }
        public void Handle()
        {
            var director = _movieStoreDbContext.Directors.SingleOrDefault(x => x.Id == DirectorId);

            if (director == null)
                throw new InvalidOperationException("Yönetmen Bulunamadı!");

            _movieStoreDbContext.Directors.Remove(director);
            _movieStoreDbContext.SaveChanges();
        }
    }
}
