using AutoMapper;
using MovieStoreApi.DbOperations;
using MovieStoreApi.Entities;

namespace MovieStoreApi.Applications.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommand
    {
        public CreateActorModel Model { get; set; }

        private readonly IMovieStoreDbContext _movieStoreDbContext;
        private readonly IMapper _mapper;

        public CreateActorCommand(IMovieStoreDbContext movieStoreDbContext, IMapper mapper)
        {
            _movieStoreDbContext = movieStoreDbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var actor = _movieStoreDbContext.Actors.SingleOrDefault(x => x.FirstName == Model.FirstName && x.LastName == Model.LastName);

            if (actor != null)
                throw new InvalidOperationException("Oyuncu zaten mevcut.");

            actor = _mapper.Map<Actor>(Model);

            _movieStoreDbContext.Actors.Add(actor);
            _movieStoreDbContext.SaveChanges();
        }
    }

    public class CreateActorModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PlayedMovies { get; set; }
    }

}