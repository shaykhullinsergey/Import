using System.Linq;
using System.Collections.Generic;

using ImportAnalyzer.Extensions;
using ImportAnalyzer.Csv.Validation;
using ImportAnalyzer.Core.Validation;

namespace ImportAnalyzer.Csv.Files
{
	public class CsvFile : IFile<CsvContent>
	{
		public string[] Header { get; set; }
		public CsvContent Content { get; set; }
		public string FilePath { get; set; }
		public IEnumerable<IValidator<CsvValidationContext>> Validators { get; set; }

		public void Process()
		{
			foreach (var row in Content.Source)
			{
				var validationContext = new CsvValidationContext(new Dictionary<string, string[]>
				{
					["Header"] = Header,
					["Row"] = row
				});

				foreach (var validator in Validators)
				{
					validator.Validate(validationContext);
				}

				Content.Valid.AddRange(validationContext.Output["Valid"].Join());
				Content.InvalidColumn.AddRange(validationContext.Output["InvalidColumn"].Join());
				Content.Zero.AddRange(validationContext.Output["Zero"].Join());
				Content.Exponential.AddRange(validationContext.Output["Exponential"].Join());
			}
		}
	}
}
