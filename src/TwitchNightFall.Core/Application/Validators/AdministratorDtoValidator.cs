using FluentValidation;
using TwitchNightFall.Core.Application.ViewModels.Administrator;

namespace TwitchNightFall.Core.Application.Validators;

public class AdministratorDtoValidator : AbstractValidator<AdministratorDto>
{
    public AdministratorDtoValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .WithMessage("Username cannot be empty")
            .MaximumLength(250)
            .WithMessage("Username can not be more than 250 characters");

        RuleFor(x => x.Firstname)
            .MaximumLength(250)
            .WithMessage("The First name can not be more than 250 characters");

        RuleFor(x => x.Lastname)
            .MaximumLength(250)
            .WithMessage("Last name can not be more than 250 characters");
    }
}