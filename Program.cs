// Interview practice: comment out question calls to focus on one exercise.
RunQuestion1();
RunQuestion2();
RunQuestion3();

#region Question 1: Find duplicate values in an integer array

// Print each duplicate once, in the order it is first repeated.
// Expected output: 2, 1
static void RunQuestion1()
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

#region Question 2: Find the first non-repeating character in a string

// Expected output: w
static void RunQuestion2()
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

#region Question 3: Group employees by department using LINQ

// Expected groups: IT => Alice, Charlie; HR => Bob, Eve; Finance => Diana.
static void RunQuestion3()
{
    Console.WriteLine("Q3: Group employees by department using LINQ");
    Employee[] employees =
    [
        new("Alice", "IT"),
        new("Bob", "HR"),
        new("Charlie", "IT"),
        new("Diana", "Finance"),
        new("Eve", "HR")
    ];

    PrintEmployeesByDepartment(employees);
    Console.WriteLine();
}

// Solution: GroupBy groups employees by department; Key holds the department name.
static void PrintEmployeesByDepartment(IEnumerable<Employee> employees)
{
    var departments = employees.GroupBy(employee => employee.Department);

    foreach (var department in departments)
    {
        Console.WriteLine($"Department: {department.Key}");

        foreach (var employee in department)
        {
            Console.WriteLine($"  {employee.Name}");
        }
    }
}

#endregion

// Model used by Question 3.
record Employee(string Name, string Department);
