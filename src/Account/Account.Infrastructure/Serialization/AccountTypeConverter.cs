using Account.Domain.Aggregate;
using Account.Domain.Common;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Account.Infrastructure.Serialization;

public class AccountTypeConverter : JsonConverter<AccountType>
{
    public override AccountType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number && reader.TryGetInt32(out int id))
        {
            return Enumeration.FromValue<AccountType>(id);
        }
        else if (reader.TokenType == JsonTokenType.String)
        {
            var displayName = reader.GetString();
            if (displayName == null)
                return null;

            return Enumeration.FromDisplayName<AccountType>(displayName);
        }

        throw new JsonException($"Unexpected token parsing MyType. Token: {reader.TokenType}");
    }

    public override void Write(Utf8JsonWriter writer, AccountType value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value.Id);
        writer.WriteStringValue(value.Name);
    }
}
