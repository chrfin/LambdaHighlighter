using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace LambdaHighlighter;

/// <summary>Classification type definition export for LambdaEditorClassifier.</summary>
internal static class LambdaEditorClassifierClassificationDefinition
{
#pragma warning disable 169 // This disables "The field is never used" compiler's warning. Justification: the field is used by MEF.

	/// <summary>Defines the "LambdaEditorClassifier" classification type.</summary>
	[Export(typeof(ClassificationTypeDefinition))]
	[Name("LambdaEditorClassifier")]
	private static ClassificationTypeDefinition typeDefinition;

#pragma warning restore 169
}