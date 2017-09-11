namespace ImportAnalyzer.Csv.Files
{
	public interface IFile<TContent> 
	{
		string FilePath { get; set; }
		TContent Content { get; set; }
		void Process();
	}
}
