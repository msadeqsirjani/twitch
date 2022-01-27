using FluentValidation;
using TwitchNightFall.Core.Application.Extensions;
using TwitchNightFall.Core.Application.ViewModels.Twitch;

namespace TwitchNightFall.Core.Application.Validators;

public class TwitchEditDtoValidator : AbstractValidator<TwitchEditDto>
{
    public TwitchEditDtoValidator()
    {
        RuleFor(x => x.Email)
            .MaximumLength(255).WithMessage("پست الکترونیکی نمی تواند بیشتر از 255 کاراکتر باشد")
            .EmailAddress().WithMessage("پست الکترونیکی معتبر نمی باشد");

        RuleFor(x => x.Password)!
            .Password();
    }
}