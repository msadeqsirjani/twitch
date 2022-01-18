using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TwitchNightFall.Core.Application.ViewModels.FollowerAward;

namespace TwitchNightFall.Core.Application.Validators
{
    public class FollowerAwardAddDtoValidator : AbstractValidator<FollowerAwardAddDto>
    {
        public FollowerAwardAddDtoValidator()
        {
            RuleFor(x => x.Prize)
                .LessThanOrEqualTo(5)
                .WithMessage("تعداد فالوور ها نمی تواند بیشتر از 5 مورد باشد");

            RuleFor(x => x.Prize)
                .GreaterThanOrEqualTo(0)
                .WithMessage("تعداد فالوور ها نمی تواند کمتر از 0 مورد باشد");

            RuleFor(x => x.Username)
                .MaximumLength(250)
                .WithMessage("نام کاربری نمی تواند بیشتر از 250 کاراکتر باشد");
        }
    }
}
