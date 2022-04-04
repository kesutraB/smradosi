using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using SmellLevels.Enums;
namespace SmellLevels.Providers
{
	public class Record
	{
		public string name { get; set; }
		public Smells SmellLevel { get; set; }
	}
	public class CSVProvider
	{
		public void SaveData(string filename, Dictionary<string, Smells> data)
		{
			using var writer = new StreamWriter(filename);
			using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
			var list = new List<Record>();
			foreach (var item in data)
			{
				list.Add(new Record() { name = item.Key, SmellLevel = item.Value });
			}

			csv.WriteRecords(list);
		}
		public Dictionary<string, Smells> LoadDataFromFile(string filename)
		{
			if (!File.Exists(filename))
				return null;

			using var reader = new StreamReader(filename);
			using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
			var records = csv.GetRecords<Record>().ToList();

			return records.ToDictionary(x => x.name, x => x.SmellLevel);
		}
	}
}