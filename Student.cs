using System.Text.RegularExpressions;

class Student
{
    public string Name { get; set; }
    public int Grade { get; set; }
    public Student(string name, int grade)
    {
        Grade = grade;
        Name = name;
    }
}


