using ImportAnalyzer.Core.Validation;
using System;
using System.Text.RegularExpressions;

namespace ImportAnalyzer.Csv.Validation
{
	public class BarCodeNotZeroValidator : IValidator<CsvValidationContext>
	{
		public static string BarCodeOfSalesReceiptID { get; } = "Bar code of sales receipt ID";
		public static Regex BarCodeOfSalesReceiptIDValidation { get; } = new Regex(@"\b[0]\b");

		public void Validate(CsvValidationContext context)
		{
			var row = context.Input["Row"];
			var header = context.Input["Header"];
			var headerBarCodeIndex = Array.IndexOf(header, BarCodeOfSalesReceiptID);

			if (headerBarCodeIndex == -1)
			{
				context["InvalidColumn"] = row;
			}
			else
			{
				var result = BarCodeOfSalesReceiptIDValidation.IsMatch(row[headerBarCodeIndex]);

				if(result)
				{
					context["Zero"] = row;
				}
				else
				{
					context["Valid"] = row;
				}
			}
		}
	}
}
