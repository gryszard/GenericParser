using CsvHelper;
using GenericParser.Enums;
using GenericParser.Exceptions;
using GenericParser.Models;
using System.Globalization;

namespace GenericParser.Parsers;

public class CsvParser : IContentParser
{
    public ParseResult Parse(string content)
    {
        using var stringReader = new StringReader(content);
        using var csvReader = new CsvReader(stringReader, CultureInfo.InvariantCulture);

        var readResult = csvReader.Read();

        if (!readResult)
        {
            return new ParseResult
            {
                OperationStatus = OperationStatus.Success,
                EntitiesProcessed = 0,
                ParsedData = null
            };
        }

        csvReader.ReadHeader();
        var headers = csvReader.HeaderRecord ?? throw new ParsingFailedException("Header record is not present");

        var records = new List<Dictionary<string, object?>>();
        while (csvReader.Read())
        {
            var row = new Dictionary<string, object?>();

            for (int i = 0; i < headers.Length; i++)
            {
                var headerName = headers[i];
                row[headerName] = csvReader.GetField(i);
            }

            records.Add(row);
        }

        return new ParseResult
        {
            OperationStatus = OperationStatus.Success,
            EntitiesProcessed = records.Count,
            ParsedData = records
        };
    }
}
