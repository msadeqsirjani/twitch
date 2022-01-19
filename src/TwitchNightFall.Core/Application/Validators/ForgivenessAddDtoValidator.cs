using FluentValidation;
using TwitchNightFall.Core.Application.ViewModels.Forgiveness;

namespace TwitchNightFall.Core.Application.Validators
{
    public class ForgivenessAddDtoValidator : AbstractValidator<ForgivenessAddDto>
    {
        public ForgivenessAddDtoValidator()
        {
            RuleFor(x => x.Prize)
                .LessThanOrEqualTo(5)
                .WithMessage("تعداد فالوور ها نمی تواند بیشتر از 5 مورد باشد");

            RuleFor(x => x.Prize)
                .GreaterThanOrEqualTo(0)
                .WithMessage("تعداد فالوور ها نمی تواند کمتر از 0 مورد باشد");
        }
    }
}
