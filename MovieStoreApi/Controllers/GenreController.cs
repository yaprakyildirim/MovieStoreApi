using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStoreApi.Applications.GenreOperations.Commands.CreateGenre;
using MovieStoreApi.Applications.GenreOperations.Commands.DeleteGenre;
using MovieStoreApi.Applications.GenreOperations.Commands.UpdateGenre;
using MovieStoreApi.Applications.GenreOperations.Querys;
using MovieStoreApi.Applications.GenreOperations.Validator;
using MovieStoreApi.DbOperations;

namespace MovieStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : Controller
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GenreController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetListGenres()
        {
            GetListGenreQuery query = new GetListGenreQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdGenre(int id)
        {
            GenreDetailModel result;
            GetByIdGenreQuery query = new GetByIdGenreQuery(_context, _mapper);
            query.GenreId = id;
            result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateGenreModel model)
        {
            CreateGenreCommand command = new CreateGenreCommand(_context, _mapper);
            command.Model = model;

            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.GenreID = id;
            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateGenreModel model)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context, _mapper);
            command.GenreID = id;
            command.Model = model;

            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}
