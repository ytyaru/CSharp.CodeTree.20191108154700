using System;
using System.IO;
using Microsoft.CSharp;
using System.CodeDom.Compiler;

namespace CodeGen
{
    class CodeClass: CodeBlock
    {
        public CodeClass(string value, StyleType style=StyleType.NewLine) : base(value, style) {}
        public override string Generate()  => $"class {Value}";
    }
}
