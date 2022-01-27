using FluentValidation;
using TwitchNightFall.Core.Application.Extensions;
using TwitchNightFall.Core.Application.ViewModels.Twitch;

namespace TwitchNightFall.Core.Application.Validators;

public class TwitchAddDtoValidator : AbstractValidator<TwitchAddDto>
{
    public TwitchAddDtoValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("نام کاربری الزامی می باشد")
            .MaximumLength(250).WithMessage("نام کاربری نمی تواند بیشتر از 250 کاراکتر باشد");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("پست الکترونیکی الزامی می باشد")
            .MaximumLength(255).WithMessage("پست الکترونیکی نمی تواند بیشتر از 255 کاراکتر باشد")
            .EmailAddress().WithMessage("پست الکترونیکی معتبر نمی باشد");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("رمز عبور الزامی است")!
            .Password();
    }
}