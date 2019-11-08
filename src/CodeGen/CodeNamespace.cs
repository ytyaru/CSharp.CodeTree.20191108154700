using System;
using System.IO;
using Microsoft.CSharp;
using System.CodeDom.Compiler;

namespace CodeGen
{
    class CodeNamespace: CodeBlock
    {
        public CodeNamespace(string value, StyleType style=StyleType.NewLine) : base(value, style) {}
        public override string Generate()  => $"namespace {Value}";
    }
}
