namespace ImportAnalyzer.Core.Validation
{
	public interface IValidator<TValidationContext> 
	{
		void Validate(TValidationContext context);
	}
}
