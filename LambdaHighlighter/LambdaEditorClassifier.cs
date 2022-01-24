using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;

namespace LambdaHighlighter;

/// <summary>Classifier that classifies all text as an instance of the "LambdaEditorClassifier" classification type.</summary>
internal class LambdaEditorClassifier : IClassifier
{
	/// <summary>Classification type.</summary>
	private readonly IClassificationType classificationType;

	/// <summary>Initializes a new instance of the <see cref="LambdaEditorClassifier" /> class.</summary>
	/// <param name="registry">Classification registry.</param>
	internal LambdaEditorClassifier(IClassificationTypeRegistryService registry) => classificationType = registry.GetClassificationType("LambdaEditorClassifier");

#pragma warning disable 67

	/// <summary>An event that occurs when the classification of a span of text has changed.</summary>
	/// <remarks>
	/// This event gets raised if a non-text change would affect the classification in some way,
	/// for example typing /* would cause the classification to change in C# without directly affecting the span.
	/// </remarks>
	public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;

#pragma warning restore 67

	/// <summary>Gets all the <see cref="ClassificationSpan" /> objects that intersect with the given range of text.</summary>
	/// <param name="span">The span currently being classified.</param>
	/// <returns>A list of ClassificationSpans that represent spans identified to be of this classification.</returns>
	/// <remarks>
	/// This method scans the given SnapshotSpan for potential matches for this classification. In this instance, it classifies everything and returns each span as a new ClassificationSpan.
	/// </remarks>
	public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
	{
		var result = new List<ClassificationSpan>();
		foreach (var line in span.Snapshot.Lines.Where(x => x.GetText().Contains("=>")))
		{
			result.AddRange(line.GetText().AllIndexesOf("=>")
				.Select(idx => new ClassificationSpan(new SnapshotSpan(line.Snapshot, new Span(line.Start.Position + idx, 2)), classificationType)));
		}

		return result;
	}
}