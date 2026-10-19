static class TreeQuestions
{
    #region Question 4: BST inorder iterator using yield return
    
    // Traverse a valid BST in ascending order without building a separate list.
    //         4
    //       /   \
    //      2     6
    //     / \   / \
    //    1   3 5   7
    // Expected output: 1 2 3 4 5 6 7
    public static void RunQuestion4()
    {
        Console.WriteLine("Q4: BST inorder iterator using yield return");
        TreeNode root = new(4,
            new(2, new(1), new(3)),
            new(6, new(5), new(7)));
    
        foreach (int value in InOrder(root))
        {
            Console.Write($"{value} ");
        }
    
        Console.WriteLine();
        Console.WriteLine();
    }
    
    // Solution: visit left subtree, node, then right subtree.
    // yield return pauses execution until the caller requests the next value.
    // Full traversal: O(n) time and O(h) space for the stack, where h is tree height.
    // An empty tree yields no values. The caller can stop enumeration early.
    static IEnumerable<int> InOrder(TreeNode? root)
    {
        Stack<TreeNode> stack = new();
        TreeNode? current = root;
    
        while (current is not null || stack.Count > 0)
        {
            while (current is not null)
            {
                stack.Push(current);
                current = current.Left;
            }
    
            current = stack.Pop();
            yield return current.Value;
            current = current.Right;
        }
    }
    
    #endregion
}

// The sample tree is constructed in BST order.
record TreeNode(int Value, TreeNode? Left = null, TreeNode? Right = null);
