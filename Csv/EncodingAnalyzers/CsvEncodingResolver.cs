using System.IO;
using System.Text;

using Ude;
using ImportAnalyzer.Csv.Files;
using ImportAnalyzer.Core.EncodingAnalyzers;

namespace ImportAnalyzer.Csv.EncodingAnalyzers
{
	public class CsvEncodingAnalyzer : IEncodingAnalyzer<CsvFileInfo>
	{
		public CsvFileInfo ReadFileAndDetectEncoding(string filePath)
		{
			var data = File.ReadAllBytes(filePath);

			var detector = new CharsetDetector();
			detector.Feed(data, 0, data.Length);
			detector.DataEnd();

			if (detector.Confidence > 0.5f)
			{
				var encoding = Encoding.GetEncoding(detector.Charset);
				return new CsvFileInfo(filePath, encoding.GetString(data), encoding);
			}

			var windows1251Encoding = Encoding.GetEncoding("windows-1251");
			return new CsvFileInfo(filePath, windows1251Encoding.GetString(data), windows1251Encoding);
		}
	}
}
