using AutoMapper;
using MovieStoreApi.DbOperations;
using MovieStoreApi.Entities;

namespace MovieStoreApi.Applications.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommand
    {
        public UpdateDirectorModel Model { get; set; }
        public int GenreID { get; set; }

        private readonly IMovieStoreDbContext _movieStoreDbContext;
        private readonly IMapper _mapper;

        public UpdateDirectorCommand(IMovieStoreDbContext movieStoreDbContext, IMapper mapper)
        {
            _movieStoreDbContext = movieStoreDbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var director = _movieStoreDbContext.Directors.SingleOrDefault(x => x.Id == GenreID);
            if (director == null)
            {
                throw new InvalidOperationException("Yönetmen Bulunamadı!");
            }

            _mapper.Map<UpdateDirectorModel, Director>(Model, director);
            _movieStoreDbContext.Directors.Update(director);
            _movieStoreDbContext.SaveChanges();
        }
    }

    public class UpdateDirectorModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FilmsDirected { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
