static class StringQuestions
{
    #region Question 2: Find the first non-repeating character in a string

    // Expected output: w
    public static void RunQuestion2()
    {
        Console.WriteLine("Q2: Find the first non-repeating character in a string");
        string input = "swiss";
        Console.WriteLine($"Input: {input}");
        PrintFirstNonRepeatingCharacter(input);
        Console.WriteLine();
    }

    // Solution: count characters, then find the first with a count of 1.
    static void PrintFirstNonRepeatingCharacter(string input)
    {
        Dictionary<char, int> characterCounts = [];

        foreach (char countedCharacter in input)
        {
            characterCounts[countedCharacter] = characterCounts.GetValueOrDefault(countedCharacter) + 1;
        }

        foreach (char candidate in input)
        {
            if (characterCounts[candidate] == 1)
            {
                Console.WriteLine($"First non-repeating character: {candidate}");
                return;
            }
        }

        Console.WriteLine("There is no non-repeating character.");
    }

    #endregion

    #region Question 6: Longest substring without repeating characters (LeetCode 3, Medium)

    // Return the length of the longest contiguous substring with unique characters.
    // Example: "abcabcbb" => 3 ("abc"). A substring cannot skip characters.
    public static void RunQuestion6()
    {
        Console.WriteLine("Q6: Longest substring without repeating characters (Medium)");
        (string Input, int Expected)[] examples =
        [
            ("abcabcbb", 3),
            ("bbbbb", 1),
            ("pwwkew", 3),
            ("abba", 2),
            ("", 0),
            ("a", 1)
        ];

        foreach (var example in examples)
        {
            int actual = LengthOfLongestSubstring(example.Input);
            Console.WriteLine($"Input: \"{example.Input}\" => {actual} (expected {example.Expected})");
            if (actual != example.Expected)
            {
                throw new InvalidOperationException("Longest substring example failed.");
            }
        }

        Console.WriteLine();
    }

    // Sliding window: input[left..right] always contains unique characters.
    // Remember each character's latest index. On a repeat inside the window,
    // move left past the previous occurrence. Never move left backwards.
    // Example "abba": left moves to 2 at the second 'b'; the final 'a' is
    // outside the old window, so left stays at 2 and the answer remains 2.
    // O(n) time, O(k) space, where k is the number of distinct characters.
    public static int LengthOfLongestSubstring(string input)
    {
        Dictionary<char, int> lastSeen = [];
        int left = 0;
        int longest = 0;

        for (int right = 0; right < input.Length; right++)
        {
            char current = input[right];
            if (lastSeen.TryGetValue(current, out int previousIndex) && previousIndex >= left)
            {
                left = previousIndex + 1;
            }

            lastSeen[current] = right;
            longest = Math.Max(longest, right - left + 1);
        }

        return longest;
    }

    #endregion
}
