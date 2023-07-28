using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStoreApi.Applications.ActorOperations.Commands.CreateActor;
using MovieStoreApi.Applications.ActorOperations.Commands.DeleteActor;
using MovieStoreApi.Applications.ActorOperations.Querys;
using MovieStoreApi.DbOperations;

namespace MovieStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : Controller
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public ActorController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateActorModel createActor)
        {
            CreateActorCommand command = new CreateActorCommand(_context, _mapper);
            command.Model = createActor;
            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            DeleteActorCommand command = new DeleteActorCommand(_context);
            command.ActorId = id;
            command.Handle();

            return Ok();

        }

        [HttpGet]
        public IActionResult GetList()
        {
            GetListActorQuery query = new GetListActorQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }
    }
}
