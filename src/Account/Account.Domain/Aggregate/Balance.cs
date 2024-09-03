using Account.Domain.Common;
using System.Text.RegularExpressions;

namespace Account.Domain.Aggregate;

public class Balance : ValueObject
{
    public decimal? Value { get; }

    public DateTime? LastUpdated { get; }

    internal Balance(decimal? value, DateTime? lastUpdated)
    {
        Value = value;
        LastUpdated = lastUpdated;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}