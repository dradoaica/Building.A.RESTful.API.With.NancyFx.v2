using FluentValidation;

namespace Building.A.RESTful.API.With.NancyFx
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(p => p.FirstName).Must((p, firstName) => !string.IsNullOrWhiteSpace(firstName))
                .WithMessage("First name must be filled in");
            RuleFor(p => p.LastName).Must((p, lastName) => !string.IsNullOrWhiteSpace(lastName))
                .WithMessage("Last name must be filled in");
        }
    }
}
