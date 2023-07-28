using FluentValidation;
using MovieStoreApi.Applications.DirectorOperations.Commands.CreateDirector;

namespace MovieStoreApi.Applications.DirectorOperations.Validator
{
    public class UpdateDirectorCommandValidator : AbstractValidator<CreateDirectorCommand>
    {
        public UpdateDirectorCommandValidator()
        {
            RuleFor(d => d.Model.FirstName).NotEmpty();
            RuleFor(d => d.Model.LastName).NotEmpty();
            RuleFor(d => d.Model.FilmsDirected).NotEmpty();
        }
    }
}
