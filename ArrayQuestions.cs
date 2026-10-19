static class ArrayQuestions
{
    #region Question 1: Find duplicate values in an integer array

    // Print each duplicate once, in the order it is first repeated.
    // Expected output: 2, 1
    public static void RunQuestion1()
    {
        Console.WriteLine("Q1: Find duplicate values in an integer array");
        int[] numbers = [1, 2, 3, 2, 4, 1, 2];
        Console.WriteLine($"Input: [{string.Join(", ", numbers)}]");
        PrintDuplicateValues(numbers);
        Console.WriteLine();
    }

    // Solution: use HashSets to track seen values and duplicates already printed.
    static void PrintDuplicateValues(int[] numbers)
    {
        HashSet<int> seen = [];
        HashSet<int> reportedDuplicates = [];

        Console.WriteLine("Duplicate values:");

        foreach (int number in numbers)
        {
            if (!seen.Add(number) && reportedDuplicates.Add(number))
            {
                Console.WriteLine(number);
            }
        }
    }

    #endregion
}
