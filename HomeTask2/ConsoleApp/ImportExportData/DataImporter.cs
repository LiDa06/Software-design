namespace ConsoleApp.ImportExportData
{
    public abstract class DataImporter
    {
        public void Import(string content)
        {
            IEnumerable<IDictionary<string, string>> records = Parse(content);
            foreach (IDictionary<string, string> rec in records)
            {
                ProcessRecord(rec);
            }
        }

        protected abstract IEnumerable<IDictionary<string, string>> Parse(string content);
        protected virtual void ProcessRecord(IDictionary<string, string> record)
        {
            Console.WriteLine("Record:");
            foreach (KeyValuePair<string, string> kv in record)
            {
                Console.WriteLine($"  {kv.Key} = {kv.Value}");
            }
        }
    }
}
