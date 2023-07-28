using AutoMapper;
using MovieStoreApi.Applications.ActorOperations.Commands.CreateActor;
using MovieStoreApi.Applications.ActorOperations.Querys;
using MovieStoreApi.Entities;

namespace MovieStoreApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Actor, CreateActorModel>().ReverseMap();
            CreateMap<Actor, GetListActorModel>().ReverseMap();

        }
    }
}
