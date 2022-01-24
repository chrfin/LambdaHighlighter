using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaHighlighter;

internal static class StringExtensionMethods
{
	/// <summary>Gets all indexes of a given value.</summary>
	/// <param name="data">The string.</param>
	/// <param name="value">The value.</param>
	/// <returns></returns>
	/// <exception cref="System.ArgumentException">The string to find may not be empty. - value</exception>
	public static List<int> AllIndexesOf(this string data, string value)
	{
		if (String.IsNullOrEmpty(value))
			throw new ArgumentException("The string to find may not be empty.", nameof(value));

		var indexes = new List<int>();
		for (var index = 0;; index += value.Length)
		{
			index = data.IndexOf(value, index, StringComparison.Ordinal);
			if (index == -1)
				return indexes;
			indexes.Add(index);
		}
	}
}