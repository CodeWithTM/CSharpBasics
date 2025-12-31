using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CApp_DesignPatterns
{
    internal class AdapterPattern
    {

        //structural design pattern

        //Adapter Pattern: Convert the interface of a class into another interface clients expect.
        //Adapter lets classes work together that couldn't otherwise because of incompatible interfaces.


        static void MainClient()
        {
            JsonDataProvider jsonProvider = new JsonDataProvider();
            ICsvProvider csvProvider = new JsonToCsvAdapter(jsonProvider);

            string csv = csvProvider.GetCsv();
            Console.WriteLine("CSV output:\n");
            Console.WriteLine(csv);
        }

        // Target interface: what the client expects
        public interface ICsvProvider
        {
            string GetCsv();
        }

        // Adaptee: existing class that produces JSON
        public class JsonDataProvider
        {
            // In a real app this could read from a web API or file.
            public string GetJson()
            {
                return @"
            [
                { ""name"": ""Alice"", ""age"": 30, ""email"": ""alice@example.com"" },
                { ""name"": ""Bob"",   ""age"": 25, ""email"": ""bob@example.com"" },
                { ""name"": ""Cara"",  ""age"": 28, ""email"": ""cara,dev@example.com"" }
            ]";
            }
        }

        // Adapter: converts JSON from the Adaptee into CSV for the Target interface
        public class JsonToCsvAdapter : ICsvProvider
        {
            private readonly JsonDataProvider _adaptee;

            public JsonToCsvAdapter(JsonDataProvider adaptee)
            {
                _adaptee = adaptee;
            }

            public string GetCsv()
            {
                var json = _adaptee.GetJson();
                using (var doc = JsonDocument.Parse(json))
                {
                    var root = doc.RootElement;

                    if (root.ValueKind != JsonValueKind.Array)
                        throw new InvalidOperationException("Expected a JSON array of objects.");

                    var elements = root.EnumerateArray().ToList();
                    if (elements.Count == 0) return string.Empty;

                    // Collect headers from the first object (assumes all objects share same keys)
                    var headers = elements[0].EnumerateObject().Select(p => p.Name).ToList();

                    var sb = new StringBuilder();
                    sb.AppendLine(string.Join(",", headers.Select(EscapeCsv)));

                    foreach (var el in elements)
                    {
                        var row = new List<string>();
                        foreach (var header in headers)
                        {
                            if (el.TryGetProperty(header, out var prop))
                                row.Add(EscapeCsv(JsonElementToString(prop)));
                            else
                                row.Add(EscapeCsv(string.Empty));
                        }
                        sb.AppendLine(string.Join(",", row));
                    }

                    return sb.ToString();
                }
            }

            private static string JsonElementToString(JsonElement el)
            {
                switch (el.ValueKind)
                {
                    case JsonValueKind.String:
                        return el.GetString() ?? string.Empty;
                    case JsonValueKind.Number:
                        return el.GetRawText();
                    case JsonValueKind.True:
                        return "true";
                    case JsonValueKind.False:
                        return "false";
                    case JsonValueKind.Null:
                        return string.Empty;
                    // For Object/Array return raw JSON
                    default:
                        return el.GetRawText();
                }
            }

            // Simple CSV escaping: quote fields that contain comma, quote or newline, and double-up quotes
            private static string EscapeCsv(string field)
            {
                if (field.Contains('"'))
                    field = field.Replace("\"", "\"\"");

                if (field.Contains(',') || field.Contains('"') || field.Contains('\n') || field.Contains('\r'))
                    return $"\"{field}\"";

                return field;
            }
        }

    }
}



