using ImportAnalyzer.Csv.Files;

namespace ImportAnalyzer.Core.Parsers
{
	public interface IParser<TFile, TContentFile> where TFile : IFile<TContentFile>
	{
		TFile Parse();
	}
}
