using AutoMapper;
using MovieStoreApi.DbOperations;

namespace MovieStoreApi.Applications.GenreOperations.Querys
{
    public class GetByIdGenreQuery
    {
        public int GenreId { get; set; }
        private readonly IMovieStoreDbContext _movieStoreDbContext;
        private readonly IMapper _mapper;

        public GetByIdGenreQuery(IMovieStoreDbContext movieStoreDbContext, IMapper mapper)
        {
            _movieStoreDbContext = movieStoreDbContext;
            _mapper = mapper;
        }

        public GenreDetailModel Handle()
        {
            var genre = _movieStoreDbContext.Genres.SingleOrDefault(x => x.ID == GenreId);

            if (genre == null)
            {
                throw new InvalidOperationException("Film Türü bulunamadı!");
            }
            GenreDetailModel model = _mapper.Map<GenreDetailModel>(genre);
            return model;
        }
    }

    public class GenreDetailModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
