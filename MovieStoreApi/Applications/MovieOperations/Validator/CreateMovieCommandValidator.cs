using FluentValidation;
using MovieStoreApi.Applications.MovieOperations.Commands.CreateMovie;

namespace MovieStoreApi.Applications.MovieOperations.Validator
{
    public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieCommandValidator()
        {
            RuleFor(m => m.Model.GenreID).NotEmpty().GreaterThan(0);
            RuleFor(m => m.Model.Price).NotEmpty().GreaterThan(0);
            RuleFor(m => m.Model.Year).NotEmpty().MinimumLength(4).MaximumLength(4);
            RuleFor(m => m.Model.Title).NotEmpty().MinimumLength(3);
            RuleFor(m => m.Model.Actors).NotEmpty().MinimumLength(3);
            RuleFor(m => m.Model.Director).NotEmpty().MinimumLength(3);
        }

    }
}
