using System.Collections.Generic;

using ImportAnalyzer.Core.Validation;

namespace ImportAnalyzer.Csv.Validation
{
	public class CsvValidationContext : ValidationContext<string[], string[], List<string[]>>
	{
		public CsvValidationContext(IReadOnlyDictionary<string, string[]> input) : base(input)
		{
			output = new Dictionary<string, List<string[]>>
			{
				["Valid"] = new List<string[]>(),
				["InvalidColumn"] = new List<string[]>(),
				["Zero"] = new List<string[]>(),
				["Exponential"] = new List<string[]>()
			};
		}
	}
}
