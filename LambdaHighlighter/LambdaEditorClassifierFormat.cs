using System.ComponentModel.Composition;
using System.Windows.Media;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace LambdaHighlighter;

/// <summary>Defines an editor format for the LambdaEditorClassifier type.</summary>
[Export(typeof(EditorFormatDefinition))]
[ClassificationType(ClassificationTypeNames = "LambdaEditorClassifier")]
[Name("LambdaEditorClassifier")]
[UserVisible(true)] // This should be visible to the end user
[Order(Before = Priority.High)]
internal sealed class LambdaEditorClassifierFormat : ClassificationFormatDefinition
{
	/// <summary>Initializes a new instance of the <see cref="LambdaEditorClassifierFormat" /> class.</summary>
	public LambdaEditorClassifierFormat()
	{
		DisplayName = "Lambda Operator"; // Human readable version of the name
		ForegroundColor = Colors.Goldenrod;
		BackgroundColor = Colors.Brown;
		////TextDecorations = System.Windows.TextDecorations.Underline;
	}
}