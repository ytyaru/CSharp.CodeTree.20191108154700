using System;
using System.IO;
using Microsoft.CSharp;
using System.CodeDom.Compiler;

namespace CodeGen
{
    class CodeBlock: CodeNode
    {
        public enum StyleType { None, Minimum, Space, NewLine };
        public StyleType Style { get; private set; }
        public CodeBlock(string value, StyleType style=StyleType.NewLine) : base(value) => Style = style;
     }
}
