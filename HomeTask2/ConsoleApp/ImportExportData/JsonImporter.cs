using System.Text.Json;

namespace ConsoleApp.ImportExportData
{
    public class JsonImporter : DataImporter
    {
        protected override IEnumerable<IDictionary<string, string>> Parse(string content)
        {
            JsonDocument doc = JsonDocument.Parse(content);
            if (doc.RootElement.ValueKind != JsonValueKind.Array)
            {
                yield break;
            }

            foreach (JsonElement el in doc.RootElement.EnumerateArray())
            {
                Dictionary<string, string> dict = [];
                foreach (JsonProperty prop in el.EnumerateObject())
                {
                    dict[prop.Name] = prop.Value.ToString();
                }
                yield return dict;
            }
        }
    }
}
