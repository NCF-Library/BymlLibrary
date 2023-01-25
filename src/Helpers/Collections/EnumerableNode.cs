using System.Collections;

namespace BymlLibrary.Collections;

internal class EnumerableNode
{
    public EnumerableNode(IEnumerable node) => Node = node;

    internal IEnumerable Node { get; set; }
    internal uint Offset { get; set; }
}
