public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data)
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
        // If value == Data, we don't insert (no duplicates allowed)
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2

        // If we found the value at this node, return true
        if (value == Data)
            return true;

        // If the value is less than current node, search left subtree
        if (value < Data)
        {
            if (Left is null)
                return false;
            return Left.Contains(value);
        }
        // Otherwise, search right subtree
        else
        {
            if (Right is null)
                return false;
            return Right.Contains(value);
        }
    }

    public int GetHeight()
    {
        // TODO Start Problem 4

        // Get the height of the left subtree (0 if it doesn't exist)
        int leftHeight = (Left is null) ? 0 : Left.GetHeight();

        // Get the height of the right subtree (0 if it doesn't exist)
        int rightHeight = (Right is null) ? 0 : Right.GetHeight();

        // The height of this node is 1 plus the maximum of the two subtree heights
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}