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
using MovieStoreApi.Applications.OrderOperations.Model;
using MovieStoreApi.Entities;
using static MovieStoreApi.Applications.OrderOperations.Commands.CreateOrder.CreateOrderCommand;
using static MovieStoreApi.Applications.OrderOperations.Commands.UpdateOrder.UpdateOrderCommand;

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

            //Movie
            CreateMap<Movie, MovieViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Movie, MovieDetailModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Movie, CreateMovieModel>().ReverseMap();
            CreateMap<UpdateMoveiModel, Movie>().ReverseMap();

            //Order
            CreateMap<CreateOrderModel, Order>().ReverseMap();
            CreateMap<UpdateOrderModel, Order>().ReverseMap();
            CreateMap<Customer, OrderViewModel>()
                .ForMember(dest => dest.NameSurname, opt => opt.MapFrom(x => x.FirstName + " " + x.LastName))
                .ForMember(dest => dest.Movies, opt => opt.MapFrom(x => x.Orders.Select(y => y.Movie.Title)))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(x => x.Orders.Select(y => y.Movie.Price)))
                .ForMember(dest => dest.PurchasedDate, opt => opt.MapFrom(x => x.Orders.Select(y => y.purchasedTime)));
        }
    }
}
