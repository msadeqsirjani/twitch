using TwitchNightFall.Core.Application.Enums;

namespace TwitchNightFall.Core.Application.Services.Subscription
{
    public interface ISubscription
    {
        Guid Id { get; }
        string? Title { get; }
        double Price { get; }
        int Count { get; }
        SubscriptionType SubscriptionType { get; }
        SubscriptionTime SubscriptionTime { get; }
        int DelayBetweenEveryPurchase { get; }
    }

    public class Plan750MonthlySubscription : ISubscription
    {
        public Plan750MonthlySubscription()
        {
            Id = new Guid("5F31BB44-BA41-4CBA-97E5-E0152BAEB259");
            Title = "Purchase a subscription of 750 people per month";
            Price = 22.99;
            Count = 750;
            SubscriptionType = SubscriptionType.PurchaseFollower;
            SubscriptionTime = SubscriptionTime.Monthly;
            DelayBetweenEveryPurchase = 30;
        }

        public Guid Id { get; }
        public string? Title { get; }
        public double Price { get; }
        public int Count { get; }
        public SubscriptionType SubscriptionType { get; }
        public SubscriptionTime SubscriptionTime { get; }
        public int DelayBetweenEveryPurchase { get; }
    }

    public class Plan600MonthlySubscription : ISubscription
    {
        public Plan600MonthlySubscription()
        {
            Id = new Guid("F75A9840-2C97-4F1C-91A0-FD6C68D49F4A");
            Title = "Purchase a subscription of 600 people per month";
            Price = 18.99;
            Count = 600;
            SubscriptionType = SubscriptionType.PurchaseFollower;
            SubscriptionTime = SubscriptionTime.Monthly;
            DelayBetweenEveryPurchase = 30;
        }

        public Guid Id { get; }
        public string? Title { get; }
        public double Price { get; }
        public int Count { get; }
        public SubscriptionType SubscriptionType { get; }
        public SubscriptionTime SubscriptionTime { get; }
        public int DelayBetweenEveryPurchase { get; }
    }

    public class Plan450MonthlySubscription : ISubscription
    {
        public Plan450MonthlySubscription()
        {
            Id = new Guid("06E71005-69D6-4AD4-B218-7BD47DBEED04");
            Title = "Purchase a subscription of 450 people per month";
            Price = 14.49;
            Count = 450;
            SubscriptionType = SubscriptionType.PurchaseFollower;
            SubscriptionTime = SubscriptionTime.Monthly;
            DelayBetweenEveryPurchase = 30;
        }

        public Guid Id { get; }
        public string? Title { get; }
        public double Price { get; }
        public int Count { get; }
        public SubscriptionType SubscriptionType { get; }
        public SubscriptionTime SubscriptionTime { get; }
        public int DelayBetweenEveryPurchase { get; }
    }

    public class Plan300MonthlySubscription : ISubscription
    {
        public Plan300MonthlySubscription()
        {
            Id = new Guid("69B933C5-58D1-41D3-8ABC-18DC0C5A40F4");
            Title = "Purchase a subscription of 300 people per month";
            Price = 9.99;
            Count = 300;
            SubscriptionType = SubscriptionType.PurchaseFollower;
            SubscriptionTime = SubscriptionTime.Monthly;
            DelayBetweenEveryPurchase = 30;
        }

        public Guid Id { get; }
        public string? Title { get; }
        public double Price { get; }
        public int Count { get; }
        public SubscriptionType SubscriptionType { get; }
        public SubscriptionTime SubscriptionTime { get; }
        public int DelayBetweenEveryPurchase { get; }
    }

    public class Plan150MonthlySubscription : ISubscription
    {
        public Plan150MonthlySubscription()
        {
            Id = new Guid("8E5E29EB-2017-4D75-9CF6-7C8B8BF5B9B5");
            Title = "Purchase a subscription of 150 people per month";
            Price = 4.99;
            Count = 150;
            SubscriptionType = SubscriptionType.PurchaseFollower;
            SubscriptionTime = SubscriptionTime.Monthly;
            DelayBetweenEveryPurchase = 30;
        }

        public Guid Id { get; }
        public string? Title { get; }
        public double Price { get; }
        public int Count { get; }
        public SubscriptionType SubscriptionType { get; }
        public SubscriptionTime SubscriptionTime { get; }
        public int DelayBetweenEveryPurchase { get; }
    }

    public class Plan175WeeklySubscription : ISubscription
    {
        public Plan175WeeklySubscription()
        {
            Id = new Guid("8E5E29EB-2017-4D75-9CF6-7C8B8BF5B9B5");
            Title = "Purchase a subscription of 175 people per week";
            Price = 6.49;
            Count = 175;
            SubscriptionType = SubscriptionType.PurchaseFollower;
            SubscriptionTime = SubscriptionTime.Weekly;
            DelayBetweenEveryPurchase = 7;
        }

        public Guid Id { get; }
        public string? Title { get; }
        public double Price { get; }
        public int Count { get; }
        public SubscriptionType SubscriptionType { get; }
        public SubscriptionTime SubscriptionTime { get; }
        public int DelayBetweenEveryPurchase { get; }
    }

    public class Plan140WeeklySubscription : ISubscription
    {
        public Plan140WeeklySubscription()
        {
            Id = new Guid("4B01F654-1410-492C-8B97-BBB9E142B372");
            Title = "Purchase a subscription of 140 people per week";
            Price = 5.49;
            Count = 140;
            SubscriptionType = SubscriptionType.PurchaseFollower;
            SubscriptionTime = SubscriptionTime.Weekly;
            DelayBetweenEveryPurchase = 7;
        }

        public Guid Id { get; }
        public string? Title { get; }
        public double Price { get; }
        public int Count { get; }
        public SubscriptionType SubscriptionType { get; }
        public SubscriptionTime SubscriptionTime { get; }
        public int DelayBetweenEveryPurchase { get; }
    }

    public class Plan70WeeklySubscription : ISubscription
    {
        public Plan70WeeklySubscription()
        {
            Id = new Guid("8D96397F-A217-43A7-8F9B-91CFF10FD135");
            Title = "Purchase a subscription of 70 people per week";
            Price = 2.99;
            Count = 70;
            SubscriptionType = SubscriptionType.PurchaseFollower;
            SubscriptionTime = SubscriptionTime.Weekly;
            DelayBetweenEveryPurchase = 7;
        }

        public Guid Id { get; }
        public string? Title { get; }
        public double Price { get; }
        public int Count { get; }
        public SubscriptionType SubscriptionType { get; }
        public SubscriptionTime SubscriptionTime { get; }
        public int DelayBetweenEveryPurchase { get; }
    }

    public class Plan10RoundSubscription : ISubscription
    {
        public Plan10RoundSubscription()
        {
            Id = new Guid("42A62722-2C58-4F59-A81F-487141A288BB");
            Title = "10 rounds of luck one to five followers";
            Price = 0.99;
            Count = 10;
            SubscriptionType = SubscriptionType.LuckRound;
            SubscriptionTime = SubscriptionTime.Daily;
            DelayBetweenEveryPurchase = 5;
        }

        public Guid Id { get; }
        public string? Title { get; }
        public double Price { get; }
        public int Count { get; }
        public SubscriptionType SubscriptionType { get; }
        public SubscriptionTime SubscriptionTime { get; }
        public int DelayBetweenEveryPurchase { get; }
    }

    public class Plan20RoundSubscription : ISubscription
    {
        public Plan20RoundSubscription()
        {
            Id = new Guid("B55BCAAB-901E-4D30-8E82-E5572B84937C");
            Title = "20 rounds of luck one to five followers";
            Price = 1.89;
            Count = 20;
            SubscriptionType = SubscriptionType.LuckRound;
            SubscriptionTime = SubscriptionTime.Daily;
            DelayBetweenEveryPurchase = 5;
        }

        public Guid Id { get; }
        public string? Title { get; }
        public double Price { get; }
        public int Count { get; }
        public SubscriptionType SubscriptionType { get; }
        public SubscriptionTime SubscriptionTime { get; }
        public int DelayBetweenEveryPurchase { get; }
    }

    public class Plan50RoundSubscription : ISubscription
    {
        public Plan50RoundSubscription()
        {
            Id = new Guid("95DF2344-8FB7-4F20-BB51-F1BF1F5618C0");
            Title = "50 rounds of luck one to five followers";
            Price = 3.49;
            Count = 50;
            SubscriptionType = SubscriptionType.LuckRound;
            SubscriptionTime = SubscriptionTime.Daily;
            DelayBetweenEveryPurchase = 10;
        }

        public Guid Id { get; }
        public string? Title { get; }
        public double Price { get; }
        public int Count { get; }
        public SubscriptionType SubscriptionType { get; }
        public SubscriptionTime SubscriptionTime { get; }
        public int DelayBetweenEveryPurchase { get; }
    }
}
