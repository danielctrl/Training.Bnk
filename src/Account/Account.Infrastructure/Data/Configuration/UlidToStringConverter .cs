using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Account.Infrastructure.Data.Configuration;

internal class UlidToStringConverter : ValueConverter<Ulid, string>
{
    private static readonly ConverterMappingHints defaultHints = new(size: 26);

    public UlidToStringConverter() : this(null)
    { }

    public UlidToStringConverter(ConverterMappingHints? mappingHints = null) :
        base
        (
            convertToProviderExpression: x => x.ToString(),
            convertFromProviderExpression: x => Ulid.Parse(x),
            mappingHints: defaultHints.With(mappingHints)
        )
    { }
}