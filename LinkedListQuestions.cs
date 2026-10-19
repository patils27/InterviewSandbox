static class LinkedListQuestions
{
    #region Question 5: Create and traverse a singly linked list

    // Each node stores a value and a reference to the next node.
    // head points to the first node; the last node's Next is null.
    // Expected output: 10 -> 20 -> 30 -> null
    public static void RunQuestion5()
    {
        Console.WriteLine("Q5: Create and traverse a singly linked list");

        ListNode head = new(10);
        head.Next = new ListNode(20);
        head.Next.Next = new ListNode(30);

        PrintList(head);
        Console.WriteLine();
    }

    // Solution: start at head and follow Next until reaching null.
    // O(n) time and O(1) extra space. An empty list prints "null".
    static void PrintList(ListNode? head)
    {
        ListNode? current = head;

        while (current is not null)
        {
            Console.Write($"{current.Value} -> ");
            current = current.Next;
        }

        Console.WriteLine("null");
    }

    #endregion

    #region Question 7: Remove nth node from end of list (LeetCode 19, Medium)

    // Given a list and n (counting from 1 at the end), remove that node.
    // Example: 1 -> 2 -> 3 -> 4 -> 5, n = 2 => 1 -> 2 -> 3 -> 5.
    public static void RunQuestion7()
    {
        Console.WriteLine("Q7: Remove nth node from end of list (Medium)");
        (int[] Values, int N, int[] Expected)[] examples =
        [
            ([1, 2, 3, 4, 5], 2, [1, 2, 3, 5]),
            ([1], 1, []),
            ([1, 2], 2, [2]),
            ([1, 2], 1, [1])
        ];

        foreach (var example in examples)
        {
            ListNode? head = null;
            for (int i = example.Values.Length - 1; i >= 0; i--)
            {
                head = new ListNode(example.Values[i]) { Next = head };
            }

            Console.WriteLine($"Input: [{string.Join(", ", example.Values)}], n = {example.N}");
            ListNode? result = RemoveNthFromEnd(head, example.N);
            Console.Write("Result: ");
            PrintList(result);

            // Verify both the values and the resulting list length.
            ListNode? current = result;
            foreach (int expected in example.Expected)
            {
                if (current is null || current.Value != expected)
                    throw new InvalidOperationException("Remove nth node example failed.");

                current = current.Next;
            }

            if (current is not null)
                throw new InvalidOperationException("Result contains extra nodes.");
        }

        Console.WriteLine();
    }

    // Solution: a dummy node makes removing the head work like any other node.
    // Move fast n nodes ahead, then move both pointers until fast reaches the tail.
    // slow now points to the node BEFORE the one to remove.
    // For [1,2,3,4,5], n=2: fast ends at 5, slow at 3; bypass node 4.
    // O(length) time, O(1) extra space. Modifies the original list.
    // Requires 1 <= n <= list length; invalid n throws before modifying the list.
    public static ListNode? RemoveNthFromEnd(ListNode? head, int n)
    {
        if (n <= 0)
            throw new ArgumentOutOfRangeException(nameof(n));

        ListNode dummy = new(0) { Next = head };
        ListNode fast = dummy;
        ListNode slow = dummy;

        for (int i = 0; i < n; i++)
        {
            fast = fast.Next ?? throw new ArgumentOutOfRangeException(nameof(n));
        }

        while (fast.Next is not null)
        {
            fast = fast.Next;
            slow = slow.Next!; // The n-node gap guarantees a next node.
        }

        slow.Next = slow.Next!.Next;
        return dummy.Next;
    }

    #endregion
}

class ListNode
{
    public int Value { get; }
    public ListNode? Next { get; set; }

    public ListNode(int value)
    {
        Value = value;
    }
}
