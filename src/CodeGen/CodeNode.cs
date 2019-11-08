using System;
using System.Collections.Generic;
using System.Collections.ObjectModel; // ReadOnlyCollection

namespace CodeGen
{
    class CodeNode
    {
        protected string Value { get; }
        protected IList<CodeNode> children { get; set; }
        protected IReadOnlyList<CodeNode> Children { get; }
        public CodeNode(string value)
        {
            children = new List<CodeNode>();
            Children = new ReadOnlyCollection<CodeNode>(children);
            Value = value;
        }
        public IReadOnlyList<CodeNode> GetChildren() => Children;
        public CodeNode Add(CodeNode node) { children.Add(node); return this; }
        public virtual string Generate() => Value;
    }
}
