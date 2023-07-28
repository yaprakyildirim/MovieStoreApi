using AutoMapper;
using MovieStoreApi.DbOperations;
using MovieStoreApi.Entities;

namespace MovieStoreApi.Applications.ActorOperations.Querys
{
    public class GetListActorQuery
    {
        public GetListActorModel Model { get; set; }

        private readonly IMovieStoreDbContext _movieStoreDbContext;
        private readonly IMapper _mapper;

        public GetListActorQuery(IMovieStoreDbContext movieStoreDbContext, IMapper mapper)
        {
            _movieStoreDbContext = movieStoreDbContext;
            _mapper = mapper;
        }

        public List<GetListActorModel> Handle()
        {
            var actors = _movieStoreDbContext.Actors.Where(x => x.IsAvtive == true).ToList<Actor>();

            var mapModel = _mapper.Map<List<GetListActorModel>>(actors);

            return mapModel;

        }
    }

    public class GetListActorModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PlayedMovies { get; set; }
    }
}
