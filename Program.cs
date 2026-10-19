// Interview practice: comment out question calls to focus on one exercise.
ArrayQuestions.RunQuestion1();
StringQuestions.RunQuestion2();
RunQuestion3();
TreeQuestions.RunQuestion4();
LinkedListQuestions.RunQuestion5();
StringQuestions.RunQuestion6();
LinkedListQuestions.RunQuestion7();

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
