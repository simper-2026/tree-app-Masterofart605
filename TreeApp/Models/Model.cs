using System.Net.Http.Headers;

class Node
{
    public int Value { get; private set; }
    public int Height {get; private set; }
    public Node? Left;
    public Node? Right;
    public Node? Parent;
    public Node(int value,int height, Node? left = null, Node? right = null,Node? parent = null)
    {
        Value = value;
        Height = height;
        Left = left;
        Right = right;
        Parent = parent;
    }
}


class BinaryTree
{
    private Node? root;
    public void Insert(int value)
    {
        if (root == null)
        {
            root = new Node(value,0);
        }
        else
        {
            checkNodeInsert(ref root, value);
        }
    }
    public string InOrder()
    {
        return nodeValue(root);
    }
    public int Height()
    {
        return nodeHeight(root);
    }
    public string ToMermaid()
    {
        if (root == null)
        {
            return "graph TD\n empty[\"(empty tree)\"]";
        }
        if (root.Left == null && root.Right == null)
        {
            return $"graph TD\n {root.Value}[{root.Value} h:{root.Height}]";
        }
        return "graph TD\n " + buildMermaidLooper(root);
    }
    //Private functions
    private void checkNodeInsert(ref Node inputNode, int value)
    {
        // if (inputNode.Value == 0)
        // {
        //     inputNode = new Node(value, inputNode.Left, inputNode.Right);
        // }
        // else
        // {
        if (value < inputNode.Value)
        {
            if (inputNode.Left != null)
            {
                if (value > inputNode.Left.Value && value > inputNode.Value)
                {
                    if (inputNode.Right != null)
                    {
                        checkNodeInsert(ref inputNode.Right, value);
                    }
                    else
                    {
                        inputNode.Right = new Node(value,inputNode.Height+1,null,null,inputNode);
                    }
                }
                else
                {
                    checkNodeInsert(ref inputNode.Left, value);
                }
            }
            else
            {
                inputNode.Left = new Node(value,inputNode.Height+1,null,null,inputNode);
            }
        }
        if (value > inputNode.Value)
        {
            if (inputNode.Right != null)
            {
                checkNodeInsert(ref inputNode.Right, value);
            }
            else
            {
                inputNode.Right = new Node(value,inputNode.Height+1,null,null,inputNode);
            }
        }
        // }
    }
    private string nodeValue(Node inputNode)
    {
        if (inputNode == null)
        {
            return "";
        }
        string thisValue = inputNode.Value.ToString();
        string leftValue;
        string rightValue;
        if (inputNode.Left != null)
        {
            leftValue = nodeValue(inputNode.Left);
        }
        else
        {
            leftValue = "";
        }
        if (inputNode.Right != null)
        {
            rightValue = nodeValue(inputNode.Right);
        }
        else
        {
            rightValue = "";
        }
        return leftValue + " " + rightValue + " " + thisValue;
    }
    private int nodeHeight(Node? inputNode, int Height = -1)
    {
        if (inputNode == null)
        {
            return Height;
        }
        int leftHeight = Height;
        int rightHeight = Height;
        if (childExitsts(inputNode, true) == true)
        {
            leftHeight = nodeHeight(inputNode.Left, Height + 1);
        }
        if (childExitsts(inputNode, false) == true)
        {
            rightHeight = nodeHeight(inputNode.Right, Height + 1);
        }
        if (leftHeight > rightHeight)
        {
            return leftHeight;
        }
        else
        {
            return rightHeight;
        }

    }
    private bool childExitsts(Node inputNode, bool isLeft)
    {
        if (isLeft == true)
        {
            if (inputNode.Left == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            if (inputNode.Right == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    private string buildMermaidLooper(Node inputNode)
    {
        string thisNodeString = "";
        string leftValue = "";
        string leftString = "";
        string rightValue = "";
        string rightString = "";
        string returnValue = $"{inputNode.Value}[{inputNode.Value} h:{inputNode.Height}] \n";
        if (childExitsts(inputNode, true) == true)
        {
            leftValue = inputNode.Left.Value.ToString();
            leftString = buildMermaidLooper(inputNode.Left);
            thisNodeString = $"{inputNode.Value} --> {leftValue}[ {leftValue} h:{inputNode.Left.Height} ]\n";
            returnValue = returnValue + thisNodeString + leftString;
        }
        if (childExitsts(inputNode, false) == true)
        {
            rightValue = inputNode.Right.Value.ToString();
            rightString = buildMermaidLooper(inputNode.Right);
            thisNodeString = $"{inputNode.Value} --> {rightValue}[ {rightValue} h:{inputNode.Right.Height} ]\n";
            returnValue = returnValue + thisNodeString + rightString;
        }
        return returnValue;
    }
}