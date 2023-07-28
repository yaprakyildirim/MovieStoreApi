using FluentValidation;
using MovieStoreApi.Applications.ActorOperations.Commands.CreateActor;

namespace MovieStoreApi.Applications.ActorOperations.Validator
{
    public class CreateActorCommandValidator : AbstractValidator<CreateActorCommand>
    {
        public CreateActorCommandValidator()
        {
            RuleFor(a => a.Model.FirstName).NotEmpty();
            RuleFor(a => a.Model.LastName).NotEmpty();
            RuleFor(a => a.Model.PlayedMovies).NotEmpty();
        }
    }
}
