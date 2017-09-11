using System.Collections.Generic;

using ImportAnalyzer.Core.Files;

namespace ImportAnalyzer.Csv.Files
{
	public class CsvContent : IContent<List<string[]>>
	{
		public List<string[]> Source { get; set; }
		public List<string> Valid { get; set; }
		public List<string> InvalidColumn { get; set; }
		public List<string> Exponential { get; set; }
		public List<string> Zero { get; internal set; }
	}
}
