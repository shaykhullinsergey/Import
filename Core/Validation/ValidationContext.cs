using System.Collections.Generic;

namespace ImportAnalyzer.Core.Validation
{
	public class ValidationContext<TInputValue, TOutputValue, TOutputValueCollection> where TOutputValueCollection : IList<TOutputValue>, new()
	{
		protected Dictionary<string, TOutputValueCollection> output;
		public IReadOnlyDictionary<string, TInputValue> Input { get; }
		public IReadOnlyDictionary<string, TOutputValueCollection> Output => output;

		public ValidationContext(IReadOnlyDictionary<string, TInputValue> input)
		{
			Input = input;
		}

		public TOutputValue this[string messageKey]
		{
			set
			{
				if(output.ContainsKey(messageKey))
				{
					var list = output[messageKey];
					if(!list.Contains(value))
						output[messageKey].Add(value);
				}
				else
				{
					output.Add(messageKey, new TOutputValueCollection { value });
				}
			}
		}
	}
}
