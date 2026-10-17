int[] numbers = [1, 2, 3, 2, 4, 1, 2];

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
