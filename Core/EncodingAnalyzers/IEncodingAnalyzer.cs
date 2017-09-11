namespace ImportAnalyzer.Core.EncodingAnalyzers
{
	public interface IEncodingAnalyzer<TFileInfo>
	{
		TFileInfo ReadFileAndDetectEncoding(string filePath);
	}
}
