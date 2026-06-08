using Godot;
using Godot.Collections;

namespace SharpIDE.Godot.Features.CodeEditor;
public partial class FSharpSyntaxHighlighter : SyntaxHighlighter
{
	private SharpIDE.FSharp.FSharpSyntaxHighlighter _highlighter = new();
	public override Dictionary _GetLineSyntaxHighlighting(int line)
	{
		//var highlights = _highlighter.GetLineSyntaxHighlighting(line);

		//return highlights;
		return [];
	}
}
