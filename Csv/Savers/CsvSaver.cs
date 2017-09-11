using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using ImportAnalyzer.Csv.Files;
using ImportAnalyzer.Extensions;
using ImportAnalyzer.Core.Savers;

namespace ImportAnalyzer.Csv.Savers
{
	public class CsvSaver : ISaver
	{
		public static string OutputFolderPath { get; } = Path.Combine(Environment.CurrentDirectory, "Output");

		private IEnumerable<CsvFile> files;

		public CsvSaver(IEnumerable<CsvFile> files)
		{
			this.files = files ?? throw new ArgumentNullException(nameof(files));
		}

		public void Save()
		{
			var groups = files.GroupBy(file => file.Header.Join().Trim());
			int exponentialCount = 0, zeroCount = 0, invalidColumnCount = 0, validCount = 0;

			foreach (var group in groups)
			{
				var exponential = group.Select(file => file.Content.Exponential.Select(ex => ex.Trim()))
					.Aggregate((left, right) => left.Concat(right))
					.ToList();

				if(exponential.Count > 0)
				{
					exponential.Insert(0, group.Key);
					File.WriteAllLines($"{OutputFolderPath}/Group{exponentialCount++}_Exponential.csv", exponential);
				}

				var zero = group.Select(file => file.Content.Zero.Select(ze => ze.Trim()))
					.Aggregate((left, right) => left.Concat(right))
					.ToList();

				if(zero.Count > 0)
				{
					zero.Insert(0, group.Key);
					File.WriteAllLines($"{OutputFolderPath}/Group{zeroCount++}_Zero.csv", zero);
				}

				var invalidColumn = group.Select(file => file.Content.InvalidColumn.Select(ico => ico.Trim()))
					.Aggregate((left, right) => left.Concat(right))
					.ToList();

				if (invalidColumn.Count > 0)
				{
					invalidColumn.Insert(0, group.Key);
					File.WriteAllLines($"{OutputFolderPath}/Group{invalidColumnCount++}_InvalidColumn.csv", invalidColumn);
				}

				var valid = group.Select(file => file.Content.Valid.Select(v => v.Trim()))
					.Aggregate((left, right) => left.Concat(right))
					.ToList();

				if (valid.Count > 0)
				{
					valid.Insert(0, group.Key);
					File.WriteAllLines($"{OutputFolderPath}/Group{validCount++}_Valid.csv", valid);
				}
			}
		}
	}
}
