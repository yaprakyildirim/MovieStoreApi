using AutoMapper;
using MovieStoreApi.DbOperations;

namespace MovieStoreApi.Applications.DirectorOperations.Queries
{
    public class GetByIdDirectorQuery
    {
        public int DirectorId { get; set; }
        private readonly IMovieStoreDbContext _movieStoreDbContext;
        private readonly IMapper _mapper;

        public GetByIdDirectorQuery(IMovieStoreDbContext movieStoreDbContext, IMapper mapper)
        {
            _movieStoreDbContext = movieStoreDbContext;
            _mapper = mapper;
        }
        public GetByIdDirectorModel Handle()
        {
            var director = _movieStoreDbContext.Directors.SingleOrDefault(x => x.Id == DirectorId);
            if (director == null)
            {
                throw new InvalidOperationException("Yönetmen bulunamadı!");
            }

            var model = _mapper.Map<GetByIdDirectorModel>(director);
            return model;
        }
    }

    public class GetByIdDirectorModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FilmsDirected { get; set; }
    }
}
