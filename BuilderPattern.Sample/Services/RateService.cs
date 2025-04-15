using BuilderPattern.Sample.Domain.Builder;

namespace BuilderPattern.Sample.Services;

public class RateService
{
    public void CreatePlan_WithBuilder()
    {
        var plan = new BuilderPattern.Sample.Domain.Builder.RatePlanBuilder()
            .ForProduct("SAVING-GOLD")
            .InCurrency("USD")
            .EffectiveFrom(DateTime.UtcNow)
            .EffectiveTo(DateTime.UtcNow.AddYears(1))
            .AddTier(0, 1000, 0.01m)
            .AddTier(1000.01m, 10000, 0.015m)
            .AddTier(10000.01m, decimal.MaxValue, 0.02m)
            .AddBonus("Salary Account Holder", 0.005m)
            .AddBonus("Loyalty Over 3 Years", 0.002m)
            .Build();

        var rateForClient = plan.GetRateForAmount(5000);
    }

    public void CreatePlan_WithSetter()
    {
        var plan = new RatePlan
        {
            ProductCode = "SAVING-GOLD",
            Currency = "USD",
            EffectiveFrom = DateTime.UtcNow,
            EffectiveTo = DateTime.UtcNow.AddYears(1),
            Tiers = new List<Tier>
            {
                new Tier { MinAmount = 0, MaxAmount = 1000, Rate = 0.01m },
                new Tier { MinAmount = 1000.01m, MaxAmount = 10000, Rate = 0.015m },
                new Tier { MinAmount = 10000.01m, MaxAmount = decimal.MaxValue, Rate = 0.02m }
            },
            BonusConditions = new List<BonusCondition>
            {
                new BonusCondition { Description = "Salary Account Holder", BonusRate = 0.005m },
                new BonusCondition { Description = "Loyalty Over 3 Years", BonusRate = 0.002m }
            }
        };

        var rate = plan.GetRateForAmount(5000); // 0.015 + 0.007 = 0.022
    }

    public void CreatePlan_WithConstructor()
    {
        var tiers = new List<BuilderPattern.Sample.Domain.Tier>
        {
            new BuilderPattern.Sample.Domain.Tier(minAmount: 0, maxAmount: 1000, rate: 0.01m),
        };

        var bonuses = new List<BuilderPattern.Sample.Domain.BonusCondition>
        {
            new BuilderPattern.Sample.Domain.BonusCondition(description: "Salary Account Holder", bonusRate: 0.005m)
        };

        var plan = new BuilderPattern.Sample.Domain.RatePlan(
            productCode: "SAVING-GOLD",
            currency: "USD",
            tiers: tiers,
            bonusConditions: bonuses,
            effectiveFrom: DateTime.UtcNow,
            effectiveTo: DateTime.UtcNow.AddYears(1)
        );

        var rate = plan.GetRateForAmount(5000); // 0.015 + 0.007 = 0.022
    }
}