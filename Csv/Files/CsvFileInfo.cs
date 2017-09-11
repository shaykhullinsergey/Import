using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

using ImportAnalyzer.Extensions;
using ImportAnalyzer.Core.Files;

namespace ImportAnalyzer.Csv.Files
{
	public class CsvFileInfo : IFileInfo
	{
		private string[] fileRows;
		private string separator;

		public string[] Header { get; }
		public Encoding Encoding { get; }
		public List<string[]> Content { get; }
		public string FilePath { get; }

		public CsvFileInfo(string filePath, string fileSource, Encoding encoding)
		{
			FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
			fileRows = fileSource 
				.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
				?? throw new ArgumentNullException(nameof(fileSource));
			Encoding = encoding ?? throw new ArgumentNullException(nameof(encoding));

			separator = fileRows[0].Split(";").Length == 1 ? "\",\"" : ";";

			Header = fileRows[0].Split(separator);
			Content = fileRows.Skip(1).Select(row => row.Split(separator)).ToList();
		}
	}
}
