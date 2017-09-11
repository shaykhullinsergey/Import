using System;
using System.IO;
using System.Linq;

using ImportAnalyzer.Csv.Savers;
using ImportAnalyzer.Csv.Parsers;
using ImportAnalyzer.Csv.EncodingAnalyzers;

namespace ImportAnalyzer.Csv
{
	public class Processor
	{
		public static string FolderPath { get; } = Path.Combine(Environment.CurrentDirectory, "Input");

		public void Process()
		{
			var filePaths = Directory.EnumerateFiles(FolderPath);
			var encodingResolver = new CsvEncodingAnalyzer();

			var csvFiles = filePaths.AsParallel()
				.Select(filePath => new CsvParser(filePath, encodingResolver.ReadFileAndDetectEncoding(filePath)).Parse())
				.ToList();

			var saver = new CsvSaver(csvFiles);
			saver.Save();
		}
	}
}
