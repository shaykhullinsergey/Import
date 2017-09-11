using System.Text;

namespace ImportAnalyzer.Core.Files
{
	public interface IFileInfo
	{
		Encoding Encoding { get; }
		string FilePath { get; }
	}
}
