using System;
using System.Collections.Generic;

using ImportAnalyzer.Csv.Files;
using ImportAnalyzer.Core.Parsers;
using ImportAnalyzer.Csv.Validation;
using ImportAnalyzer.Core.Validation;

namespace ImportAnalyzer.Csv.Parsers
{
	public class CsvParser : IParser<CsvFile, CsvContent>
	{
		private string filePath;
		private CsvFileInfo sourceFile;

		public CsvParser(string filePath, CsvFileInfo sourceFile)
		{
			this.filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
			this.sourceFile = sourceFile ?? throw new ArgumentNullException(nameof(sourceFile));
		}

		public CsvFile Parse()
		{
			var csvFile = new CsvFile
			{
				FilePath = filePath,
				Header = sourceFile.Header,
				Content = new CsvContent
				{
					Source = sourceFile.Content,
					Valid = new List<string>(),
					Zero = new List<string>(),
					Exponential = new List<string>(),
					InvalidColumn = new List<string>()
				},
				Validators = new List<IValidator<CsvValidationContext>>
				{
					// Обязательный порядок!
					new BarCodeNotExponentialValidator(),
					new BarCodeNotZeroValidator()
				}
			};
			csvFile.Process();
			return csvFile;
		}
	}
}
