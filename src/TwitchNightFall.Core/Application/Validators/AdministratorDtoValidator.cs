using FluentValidation;
using TwitchNightFall.Core.Application.ViewModels.Administrator;

namespace TwitchNightFall.Core.Application.Validators;

public class AdministratorDtoValidator : AbstractValidator<AdministratorDto>
{
    public AdministratorDtoValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .WithMessage("نام کاربری نمی تواند خالی باشد")
            .MaximumLength(250)
            .WithMessage("نام کاربری نمی تواند بیشتر از 250 کاراکتر باشد");

        RuleFor(x => x.Firstname)
            .MaximumLength(250)
            .WithMessage("نام نمی تواند بیشتر از 250 کاراکتر باشد");

        RuleFor(x => x.Lastname)
            .MaximumLength(250)
            .WithMessage("نام خانوادگی نمی تواند بیشتر از 250 کاراکتر باشد");
    }
}