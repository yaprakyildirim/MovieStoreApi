using FluentValidation;
using MovieStoreApi.Applications.DirectorOperations.Commands.CreateDirector;

namespace MovieStoreApi.Applications.DirectorOperations.Validator
{
    public class CreateDirectorCommandValidator : AbstractValidator<CreateDirectorCommand>
    {
        public CreateDirectorCommandValidator()
        {
            RuleFor(d => d.Model.FirstName).NotEmpty();
            RuleFor(d => d.Model.LastName).NotEmpty();
            RuleFor(d => d.Model.FilmsDirected).NotEmpty();
        }
    }
}
