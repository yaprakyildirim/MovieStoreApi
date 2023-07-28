using FluentValidation;
using MovieStoreApi.Applications.OrderOperations.Commands.CreateOrder;

namespace MovieStoreApi.Applications.OrderOperations.Validator
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(o => o.Model.MovieId).NotEmpty();
            RuleFor(o => o.Model.CustomerId).NotEmpty();
        }
    }
}
