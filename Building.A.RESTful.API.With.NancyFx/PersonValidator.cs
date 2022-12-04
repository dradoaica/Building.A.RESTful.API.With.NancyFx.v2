using FluentValidation;

namespace Building.A.RESTful.API.With.NancyFx;

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        _ = RuleFor(p => p.FirstName).Must((p, firstName) => !string.IsNullOrWhiteSpace(firstName))
            .WithMessage("First name must be filled in");
        _ = RuleFor(p => p.LastName).Must((p, lastName) => !string.IsNullOrWhiteSpace(lastName))
            .WithMessage("Last name must be filled in");
    }
}