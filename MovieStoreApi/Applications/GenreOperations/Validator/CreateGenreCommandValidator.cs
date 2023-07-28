using FluentValidation;
using MovieStoreApi.Applications.GenreOperations.Commands.CreateGenre;

namespace MovieStoreApi.Applications.GenreOperations.Validator
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(g => g.Model.Name).NotEmpty().MinimumLength(3);

        }
    }
}
