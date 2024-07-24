using Account.Domain.Common;

namespace Account.Domain.Aggregate;

public class Balance : ValueObject
{
    public decimal? Value { get; }

    public DateTime? LastUpdated { get; }

    public Balance(decimal? value, DateTime? lastUpdated)
    {
        Value = value;
        LastUpdated = lastUpdated;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}