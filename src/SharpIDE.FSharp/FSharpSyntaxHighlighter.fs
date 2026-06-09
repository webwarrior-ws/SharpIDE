namespace SharpIDE.FSharp

open FSharp.Compiler.Tokenization

type FSharpSyntaxHighlighter() =
    let sourceTok = FSharpSourceTokenizer([], Some "<source>", None, None)
    let mutable sourceLines: array<string> = [||]

    member public this.Source
        with set(newValue: string) =
            sourceLines <- newValue.Replace("\r\n", "\n").Split('\n')

    member self.GetLineSyntaxHighlighting(line: int): seq<FSharpTokenInfo> =
        let tokenizer = sourceTok.CreateLineTokenizer sourceLines.[line]

        let rec tokenizeLine (tokenizer: FSharpLineTokenizer) previousTokens state =
            match tokenizer.ScanToken(state) with
            | Some tok, state ->
                // Tokenize the rest, in the new state
                tok :: (tokenizeLine tokenizer previousTokens state)
            | None, _state -> previousTokens

        let tokens = tokenizeLine tokenizer List.Empty FSharpTokenizerLexState.Initial

        tokens
