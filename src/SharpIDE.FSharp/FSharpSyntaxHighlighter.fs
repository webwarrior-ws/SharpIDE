namespace SharpIDE.FSharp

type FSharpSyntaxHighlighter() =
    member public this.Source
        with set(newValue: string) = ()

    member self.GetLineSyntaxHighlighting(line: int) =
        
        failwith "Not yet implemented"
