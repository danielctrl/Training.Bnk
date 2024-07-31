using Account.Domain.Common;

namespace Account.Domain.Aggregate;

public class CreditLimit : ValueObject
{
    public decimal? Value { get; }

    internal CreditLimit(decimal? value)
    {
        if (value < 0)
            throw new InvalidOperationException("Credit limit cannot be negative");

        Value = value;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}