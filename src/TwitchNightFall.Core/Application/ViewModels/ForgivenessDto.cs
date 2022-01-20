using Gridify;
using Gridify.Filter;
using Gridify.Meta;

namespace TwitchNightFall.Core.Application.ViewModels;

public class ForgivenessDto : GridResponse<ForgivenessDto>
{
    public Guid Id { get; set; }
    public string? Username { get; set; }
    public Guid TwitchId { get; set; }
    public int Prize { get; set; }
    public bool IsChecked { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public override void InitSchema()
    {
        Meta(x => x.Id)
            .IsKey()
            .IsVisible(false);

        Meta(x => x.Username)
            .AddTitle("نام کاربری");

        Meta(x => x.Prize)
            .AddTitle("تعداد دنبال کنندگان")
            .AddFilter(new Filter
            {
                Operator = Operators.GreaterOrEqualThan,
                DataType = DataType.Int,
                Key = nameof(Prize)
            })
            .AddFilter(new Filter
            {
                Operator = Operators.GreaterThan,
                DataType = DataType.Int,
                Key = nameof(Prize)
            })
            .AddFilter(new Filter
            {
                Operator = Operators.LessOrEqualThan,
                DataType = DataType.Int,
                Key = nameof(Prize)
            })
            .AddFilter(new Filter
            {
                Operator = Operators.LessThan,
                DataType = DataType.Int,
                Key = nameof(Prize)
            })
            .AddFilter(new Filter
            {
                Operator = Operators.Equal,
                DataType = DataType.Int,
                Key = nameof(Prize)
            })
            .AddFilter(new Filter
            {
                Operator = Operators.NotEqual,
                DataType = DataType.Int,
                Key = nameof(Prize)
            });

        Meta(x => x.IsChecked)
            .AddTitle("بررسی شده");

        Meta(x => x.CreatedAt)
            .AddTitle("تاریخ ثبت")
            .AddFilter(new Filter
            {
                Operator = Operators.GreaterOrEqualThan,
                DataType = DataType.Int,
                Key = nameof(Prize)
            })
            .AddFilter(new Filter
            {
                Operator = Operators.GreaterThan,
                DataType = DataType.Int,
                Key = nameof(Prize)
            })
            .AddFilter(new Filter
            {
                Operator = Operators.LessOrEqualThan,
                DataType = DataType.Int,
                Key = nameof(Prize)
            })
            .AddFilter(new Filter
            {
                Operator = Operators.LessThan,
                DataType = DataType.Int,
                Key = nameof(Prize)
            })
            .AddFilter(new Filter
            {
                Operator = Operators.Equal,
                DataType = DataType.Int,
                Key = nameof(Prize)
            })
            .AddFilter(new Filter
            {
                Operator = Operators.NotEqual,
                DataType = DataType.Int,
                Key = nameof(Prize)
            });
    }
}