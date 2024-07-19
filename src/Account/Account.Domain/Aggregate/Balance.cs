using Account.Domain.Common;

namespace Account.Domain.Aggregate;

public class Balance : ValueObject
{
    public decimal Value { get; }

    public Balance(decimal value)
    {
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}