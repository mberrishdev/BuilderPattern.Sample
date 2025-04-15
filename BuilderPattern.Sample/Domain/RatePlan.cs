namespace BuilderPattern.Sample.Domain;

// წარმოდგენს საბანკო პროდუქტის საპროცენტო გეგმის განსაზღვრას, რომელსაც აქვს დიფერენცირებული ტარიფები და ბონუსები
public class RatePlan
{
    // პროდუქტის უნიკალური კოდი (მაგ. "SAVINGS-GOLD", "FIXED-DEPOSIT")
    public string ProductCode { get; set; } = default!;

    // ვალუტა, რომელშიც მოქმედებს საპროცენტო გეგმა (მაგ. GEL, USD, EUR)
    public string Currency { get; set; } = "GEL";

    // საპროცენტო ტარიფების სია სხვადასხვა თანხის დიაპაზონზე (მაგ. 0-1000 GEL, 1000-5000 GEL)
    public List<Tier> Tiers { get; set; } = new();

    // ბონუს პირობების სია, რაც შეიძლება გაზარდოს საპროცენტო ტარიფი (მაგ. ხელფასი ამ ანგარიშზე, ერთგულება)
    public List<BonusCondition> BonusConditions { get; set; } = new();

    // პერიოდი, როდესაც ეს საპროცენტო გეგმა ამოქმედდება (მალე დაიწყება)
    public DateTime EffectiveFrom { get; set; }

    // ამ გეგმაზე მოქმედების ბოლო ვადა (null ნიშნავს რომ დროით შეზღუდული არ არის)
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
    
    public RatePlan(
        string productCode,
        string currency,
        List<Tier> tiers,
        List<BonusCondition> bonusConditions,
        DateTime effectiveFrom,
        DateTime? effectiveTo)
    {
        ProductCode = productCode;
        Currency = currency;
        Tiers = tiers;
        BonusConditions = bonusConditions;
        EffectiveFrom = effectiveFrom;
        EffectiveTo = effectiveTo;
    }
}

// საპროცენტო ტარიფის დონე მოცემული თანხის ფარგლებში
public class Tier
{
    // მინიმალური თანხა დონეზე
    public decimal MinAmount { get; set; }

    // მაქსიმალური თანხა დონეზე
    public decimal MaxAmount { get; set; }

    // ამ დონეზე მოქმედი საპროცენტო ტარიფი
    public decimal Rate { get; set; }

    public Tier(decimal minAmount, decimal maxAmount, decimal rate)
    {
        MinAmount = minAmount;
        MaxAmount = maxAmount;
        Rate = rate;
    }
}
// ბონუსის პირობები, რომლებიც გამოიწვევს საპროცენტო ტარიფის ზრდას
public class BonusCondition
{
    // ბონუსის აღწერა (მაგ. "1% ბონუსი რომ ხელფასი ამ ანგარიშზე გადიოდეს")
    public string Description { get; set; } = default!;

    // ბონუსის საპროცენტო ტარიფი
    public decimal BonusRate { get; set; }

    public BonusCondition(string description, decimal bonusRate)
    {
        Description = description;
        BonusRate = bonusRate;
    }
}
