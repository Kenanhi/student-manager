using System.Text.RegularExpressions;

public class Student
{
    public string Name { get; private set; }
    public int Grade { get; private set; }
    public Student(string name, int grade)
    {
        Name = name;
        SetGrade(grade);
    }
    public void SetGrade(int grade)
    {
        if (grade < 0 || grade > 100)
        {
            throw new ArgumentException("Grade must be between 0 and 100");
        }
        Grade = grade;
    }
}


