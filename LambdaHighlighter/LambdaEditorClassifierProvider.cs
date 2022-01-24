using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace LambdaHighlighter;

/// <summary>Classifier provider. It adds the classifier to the set of classifiers.</summary>
[Export(typeof(IClassifierProvider))]
[ContentType("code")] // This classifier applies to all code files.
internal class LambdaEditorClassifierProvider : IClassifierProvider
{
#pragma warning disable 649 // Disable "Field is never assigned to..." compiler's warning. Justification: the field is assigned by MEF.

	/// <summary>Classification registry to be used for getting a reference to the custom classification type later.</summary>
	[Import]
	private IClassificationTypeRegistryService classificationRegistry;

#pragma warning restore 649

	/// <summary>Gets a classifier for the given text buffer.</summary>
	/// <param name="buffer">The <see cref="ITextBuffer" /> to classify.</param>
	/// <returns>A classifier for the text buffer, or null if the provider cannot do so in its current state.</returns>
	public IClassifier GetClassifier(ITextBuffer buffer) => buffer.Properties.GetOrCreateSingletonProperty<LambdaEditorClassifier>(creator: () => new LambdaEditorClassifier(classificationRegistry));
}