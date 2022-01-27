using FluentValidation;

namespace TwitchNightFall.Core.Application.Extensions;

public static class RuleBuilderExtensions
{
    public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder, int minimumLength = 6)
    {
        var options = ruleBuilder
            .MinimumLength(minimumLength).WithMessage($"رمز عبور نمی تواند کمتر از {minimumLength} باشد")
            .Matches("[A-Z]").WithMessage("رمز عبور باید حداقل یک کاراکتر از حروف بزرگ انگلیسی داشته باشد")
            .Matches("[a-z]").WithMessage("رمز عبور باید حداقل یک کاراکتر از حروف کوچک انگلیسی داشته باشد")
            .Matches("[0-9]").WithMessage("رمز عبور باید حداقل یک کاراکتر از اعداد انگلیسی داشته باشد")
            .Matches("[^a-zA-Z0-9]").WithMessage("رمز عبور باید حداقل یک کاراکتر خاص داشته باشد");
        return options;
    }
}