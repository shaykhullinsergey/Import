using System;
using System.Text.RegularExpressions;
using ImportAnalyzer.Core.Validation;

namespace ImportAnalyzer.Csv.Validation
{
	public class BarCodeNotExponentialValidator : IValidator<CsvValidationContext>
	{
		public static string BarCodeOfSalesReceiptID { get; } = "Bar code of sales receipt ID";
		public static string CustomerCustomerNo { get; } = "Customer Customer No";
		public static Regex IsExponentialValidation { get; } = new Regex(@"[-+]?[0-9]*[\.\,]?[0-9]+([eE][-+]?[0-9]+)");

		public void Validate(CsvValidationContext context)
		{
			var row = context.Input["Row"];
			var header = context.Input["Header"];
			var headerBarCodeIndex = Array.IndexOf(header, BarCodeOfSalesReceiptID);
			var headerCustomerNo = Array.IndexOf(header, CustomerCustomerNo);

			if (headerBarCodeIndex == -1 || headerCustomerNo == -1)
			{
				context["InvalidColumn"] = row;
			}
			else
			{
				var barCoreResult = IsExponentialValidation.IsMatch(row[headerBarCodeIndex]);
				var cursomerOrderResult = IsExponentialValidation.IsMatch(row[headerCustomerNo]);

				if (barCoreResult || cursomerOrderResult)
				{
					context["Exponential"] = row;
				}
				else
				{
					context["Valid"] = row;
				}
			}
		}
	}
}
