namespace ConsoleApp.ImportExportData
{
    public class CsvImporter : DataImporter
    {
        protected override IEnumerable<IDictionary<string, string>> Parse(string content)
        {
            using StringReader reader = new(content);
            string? headerLine = reader.ReadLine();
            if (headerLine == null)
            {
                yield break;
            }

            string[] headers = [.. headerLine.Split(',').Select(s => s.Trim())];

            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                Dictionary<string, string> dict = [];
                for (int i = 0; i < headers.Length && i < parts.Length; i++)
                {
                    dict[headers[i]] = parts[i].Trim();
                }
                yield return dict;
            }
        }
    }
}
