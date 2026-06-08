using Godot;
using Godot.Collections;

using FSharp.Compiler.Tokenization;
using Microsoft.VisualStudio.Shared.VSCodeDebugProtocol.Messages;

namespace SharpIDE.Godot.Features.CodeEditor;
public partial class FSharpSyntaxHighlighter(string source) : SyntaxHighlighter
{
	private SharpIDE.FSharp.FSharpSyntaxHighlighter _highlighter = new() { Source = source };

	public void SetSource(string source)
	{
		_highlighter.Source = source;
	}

	public override Dictionary _GetLineSyntaxHighlighting(int line)
	{
		var tokens = _highlighter.GetLineSyntaxHighlighting(line);
		var highlights = new Dictionary();
		foreach (var token in tokens)
		{
			var color = EditorThemeColours.Dark.White;
			switch (token.ColorClass)
			{
				case FSharpTokenColorKind.Keyword: color = EditorThemeColours.Dark.KeywordBlue; break;
			};
			highlights[token.LeftColumn] = new Dictionary() { { "color", color } };
		}

		return highlights;
	}
}
