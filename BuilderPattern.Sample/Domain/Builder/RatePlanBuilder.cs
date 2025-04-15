namespace BuilderPattern.Sample.Domain.Builder;

public class RatePlanBuilder
{
    private readonly RatePlan _plan = new();

    public RatePlanBuilder ForProduct(string productCode)
    {
        _plan.ProductCode = productCode;
        return this;
    }

    public RatePlanBuilder InCurrency(string currency)
    {
        _plan.Currency = currency;
        return this;
    }

    public RatePlanBuilder EffectiveFrom(DateTime date)
    {
        _plan.EffectiveFrom = date;
        return this;
    }

    public RatePlanBuilder EffectiveTo(DateTime date)
    {
        _plan.EffectiveTo = date;
        return this;
    }

    public RatePlanBuilder AddTier(decimal min, decimal max, decimal rate)
    {
        _plan.Tiers.Add(new Tier { MinAmount = min, MaxAmount = max, Rate = rate });
        return this;
    }

    public RatePlanBuilder AddBonus(string description, decimal rate)
    {
        _plan.BonusConditions.Add(new BonusCondition { Description = description, BonusRate = rate });
        return this;
    }

    public RatePlan Build() => _plan;
}
