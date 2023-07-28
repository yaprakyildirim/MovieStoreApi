using AutoMapper;
using MovieStoreApi.Applications.ActorOperations.Commands.CreateActor;
using MovieStoreApi.Applications.ActorOperations.Querys;
using MovieStoreApi.Applications.CustomerOperations.CreateCustomer;
using MovieStoreApi.Applications.DirectorOperations.Commands.CreateDirector;
using MovieStoreApi.Applications.DirectorOperations.Commands.UpdateDirector;
using MovieStoreApi.Applications.DirectorOperations.Queries;
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
        }
    }
}
