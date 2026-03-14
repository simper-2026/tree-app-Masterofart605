class Node
{
    public int Value { get; private set; }
    public Node? Left;
    public Node? Right;
    public Node(int value, Node? left = null, Node? right = null)
    {
        Value=value;
        left=left;
        right=right;
    }
}


class BinaryTree
{
    void Insert(int value){}
    string InOrder(){}
    int Height(){}
    string ToMermaid(){}

}