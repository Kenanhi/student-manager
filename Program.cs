using Newtonsoft.Json;
using System.IO;


class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student("Alice", 92),
            new Student("Bob", 75),
            new Student("Charlie", 88),
            new Student("Diana", 60),
            new Student("Eve", 95)

        };
        if (File.Exists("students.json"))
        {
            string json = File.ReadAllText("students.json");
            students = JsonConvert.DeserializeObject<List<Student>>(json);
        }


        while (true)
        {
            System.Console.WriteLine(" 1.List all students \n 2.Add a student. \n 3.Find top students \n 4. Show honors\n 5. Check failures\n 6. Group by grade\n 7. Exit");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    foreach (var s in students)
                    {
                        Console.WriteLine($"{s.Name} + {s.Grade}");
                    }
                    break;
                case "2":
                    System.Console.WriteLine("Add a student name and grade: ");
                    string name = Console.ReadLine();
                    int grade = int.Parse(Console.ReadLine());
                    students.Add(new Student(name, grade));
                    break;
                case "3":
                    var topStudents = students.Where(s => s.Grade > 80);
                    foreach (var s in topStudents)
                    {
                        Console.WriteLine($"{s.Name} - {s.Grade}");
                    }
                    break;
                case "4":
                    var honors = students
                        .Where(s => s.Grade >= 90);

                    foreach (var s in honors)
                    {
                        Console.WriteLine($"{s.Name} - {s.Grade}");
                    }
                    break;
                case "5":
                    bool hasFailed = students.Any(s => s.Grade < 50);
                    var failedStudents = students.Where(s => s.Grade < 50);
                    System.Console.WriteLine(hasFailed);
                    foreach (var s in failedStudents)
                    {
                        Console.WriteLine($"{s.Name} - {s.Grade}");
                    }
                    break;
                case "6":
                    var grouped = students.GroupBy(s => s.Grade);
                    foreach (var group in grouped)
                    {
                        System.Console.WriteLine($" Grade {group.Key}: ");
                        foreach (var student in group)
                        {
                            Console.WriteLine($"{student.Name}");
                        }
                    }
                    break;
                case "7":
                    string json = JsonConvert.SerializeObject(students, Formatting.Indented);
                    File.WriteAllText("students.json", json);
                    Console.WriteLine("Students saved. Exiting...");
                    return;

            }
        }


    }
}