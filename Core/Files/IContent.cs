namespace ImportAnalyzer.Core.Files
{
	public interface IContent<TSource>
	{
		TSource Source { get; set; }
	}
}
