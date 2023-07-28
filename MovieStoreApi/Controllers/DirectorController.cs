using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStoreApi.Applications.DirectorOperations.Commands.CreateDirector;
using MovieStoreApi.Applications.DirectorOperations.Commands.DeleteDirector;
using MovieStoreApi.Applications.DirectorOperations.Commands.UpdateDirector;
using MovieStoreApi.Applications.DirectorOperations.Queries;
using MovieStoreApi.DbOperations;

namespace MovieStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : Controller
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public DirectorController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            GetListDirectorQuery query = new GetListDirectorQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetByIdDirectorModel result;
            GetByIdDirectorQuery query = new GetByIdDirectorQuery(_context, _mapper);
            query.DirectorId = id;
            result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateDirectorModel model)
        {
            CreateDirectorCommand command = new CreateDirectorCommand(_context, _mapper);
            command.Model = model;
            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            DeleteDirectorCommand command = new DeleteDirectorCommand(_context);
            command.DirectorId = id;
            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateDirectorModel model)
        {
            UpdateDirectorCommand command = new UpdateDirectorCommand(_context, _mapper);
            command.GenreID = id;
            command.Model = model;
            command.Handle();
            return Ok();

        }
    }
}
