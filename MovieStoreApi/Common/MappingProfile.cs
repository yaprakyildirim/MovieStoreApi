using AutoMapper;
using MovieStoreApi.Applications.ActorOperations.Commands.CreateActor;
using MovieStoreApi.Applications.ActorOperations.Querys;
using MovieStoreApi.Applications.CustomerOperations.CreateCustomer;
using MovieStoreApi.Applications.DirectorOperations.Commands.CreateDirector;
using MovieStoreApi.Applications.DirectorOperations.Commands.UpdateDirector;
using MovieStoreApi.Applications.DirectorOperations.Queries;
using MovieStoreApi.Applications.GenreOperations.Commands.CreateGenre;
using MovieStoreApi.Applications.GenreOperations.Commands.UpdateGenre;
using MovieStoreApi.Applications.GenreOperations.Querys;
using MovieStoreApi.Applications.MovieOperations.Commands.CreateMovie;
using MovieStoreApi.Applications.MovieOperations.Commands.UpdateMovie;
using MovieStoreApi.Applications.MovieOperations.Querys;
using MovieStoreApi.Entities;

namespace MovieStoreApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Actor
            CreateMap<Actor, CreateActorModel>().ReverseMap();
            CreateMap<Actor, GetListActorModel>().ReverseMap();

            //Customer
            CreateMap<Customer, CreateCustomerModel>().ReverseMap();

            //Director
            CreateMap<Director, CreateDirectorModel>().ReverseMap();
            CreateMap<Director, UpdateDirectorModel>().ReverseMap();
            CreateMap<Director, GetListDirectorModel>().ReverseMap();
            CreateMap<Director, GetByIdDirectorModel>().ReverseMap();

            //Genre
            CreateMap<Genre, GetListModel>().ReverseMap();
            CreateMap<Genre, GenreDetailModel>().ReverseMap();
            CreateMap<CreateGenreModel, Genre>().ReverseMap();
            CreateMap<UpdateGenreModel, Genre>().ReverseMap();

            //Movei
            CreateMap<Movie, MovieViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Movie, MovieDetailModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Movie, CreateMovieModel>().ReverseMap();
            CreateMap<UpdateMoveiModel, Movie>().ReverseMap();
        }
    }
}
