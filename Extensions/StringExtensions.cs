using System;
using System.Linq;
using System.Collections.Generic;

namespace ImportAnalyzer.Extensions
{
	public static class StringExtensions
	{
		public static string[] Split(this string row, string separator)
		{
			return row.Split(new[] { separator }, StringSplitOptions.None);
		}

		public static string[] Split(this string row, char separator)
		{
			return row.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries);
		}

		public static string Join(this string[] row, string separator = ";")
		{
			return string.Join(separator, row);
		}

		public static IEnumerable<string> Join(this List<string[]> row, string separator = ";")
		{
			return row.Select(r => r.Join());
		}
	}
}
