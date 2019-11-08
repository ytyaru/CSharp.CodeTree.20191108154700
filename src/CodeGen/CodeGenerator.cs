using System;
using System.Text;

namespace CodeGen
{
    class CodeGenerator
    {
        public string Indent { get; set; } = "    ";
        private StringBuilder builder;
        private BlockCodeGenerator blockGen;
        public CodeGenerator()
        {
            this.builder = new StringBuilder();
            this.blockGen = new BlockCodeGenerator(this.builder, Indent);
        }
        public string Generate(CodeTree tree)
        {
            builder.Clear();
            foreach(CodeNode node in tree.GetChildren()) { _Generate(node, 0); }
            return builder.ToString().TrimStart('\n'); // 先頭の改行を1つ削除
        }
        private void _Generate(CodeNode node, int indent)
        {
            builder.Append("\n");
            builder.Insert(builder.Length, Indent, indent).Append(node.Generate());
            blockGen.Blocking(node, indent);
            if (0 < node.GetChildren().Count)
            {
                indent++;
                foreach(CodeNode n in node.GetChildren()) { _Generate(n, indent); }
                indent--;
            }
            blockGen.Blocked(node, indent);
        }

        class BlockCodeGenerator
        {
            public string Start { get; private set; }
            public string End { get; private set; }
            public string Indent { get; private set; }
            private StringBuilder builder;
            public BlockCodeGenerator(in StringBuilder builder, in string Indent, string start="{", string end="}")
                => (this.builder, this.Indent, Start, End) = (builder, Indent, start, end);
            public void Blocking(CodeNode node, int indent) => Block(node, Start, indent);
            public void Blocked(CodeNode node, int indent) => Block(node, End, indent);
            private void Block(CodeNode node, string keyword, int indent)
            {
                if (node is CodeBlock n) {
                    switch (n.Style) {
                        case CodeBlock.StyleType.None: return;
                        case CodeBlock.StyleType.Minimum: builder.Append(keyword); return;
                        case CodeBlock.StyleType.Space: builder.Append($" {keyword}"); return;
                        case CodeBlock.StyleType.NewLine: builder.AppendLine().Insert(builder.Length, Indent, indent).Append(keyword); return;
                        default: return;
                    }
                }
            }
        }
    }
}
