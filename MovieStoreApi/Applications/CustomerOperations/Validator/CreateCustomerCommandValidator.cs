using FluentValidation;
using MovieStoreApi.Applications.CustomerOperations.CreateCustomer;

namespace MovieStoreApi.Applications.CustomerOperations.Validator
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(c => c.Model.FirstName).NotEmpty();
            RuleFor(c => c.Model.LastName).NotEmpty();
            RuleFor(c => c.Model.Email).NotEmpty();
            RuleFor(c => c.Model.Password).NotEmpty();
        }
    }
}
