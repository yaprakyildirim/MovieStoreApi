using FluentValidation;
using MovieStoreApi.Applications.GenreOperations.Commands.UpdateGenre;

namespace MovieStoreApi.Applications.GenreOperations.Validator
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty().MinimumLength(3);
        }
    }
}
