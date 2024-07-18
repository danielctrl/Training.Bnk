using Account.Domain.Common;

namespace Account.Domain.Aggregate;

public class Balance : ValueObject
{
    public string Currency { get; }
    public decimal Value { get; }

    public Balance(string currency, decimal value)
    {
        if (string.IsNullOrWhiteSpace(currency) || currency.Length != 3)
            throw new ArgumentException("Currency must be a 3-letter code.");

        Currency = currency;
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Currency;
        yield return Value;
    }
}