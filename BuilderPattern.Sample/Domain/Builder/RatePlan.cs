namespace BuilderPattern.Sample.Domain.Builder;

public class RatePlan
{
    public string ProductCode { get; set; } = default!;
    public string Currency { get; set; } = "GEL";
    public List<Tier> Tiers { get; set; } = new();
    public List<BonusCondition> BonusConditions { get; set; } = new();
    public DateTime EffectiveFrom { get; set; }
    public DateTime? EffectiveTo { get; set; }

    public decimal GetRateForAmount(decimal amount)
    {
        var baseRate = Tiers
            .Where(t => amount >= t.MinAmount && amount <= t.MaxAmount)
            .Select(t => t.Rate)
            .FirstOrDefault();

        var bonus = BonusConditions.Sum(b => b.BonusRate);
        return baseRate + bonus;
    }
}


public class Tier
{
    public decimal MinAmount { get; set; }
    public decimal MaxAmount { get; set; }
    public decimal Rate { get; set; }
}

public class BonusCondition
{
    public string Description { get; set; } = default!;
    public decimal BonusRate { get; set; }
}
