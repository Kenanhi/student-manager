using System.Runtime.CompilerServices;
using NUnit.Framework;
using StudentLibrary;

namespace StudentLibrary.Tests;

public class StudentTests
{

    [Test]
    public void SetGrade_ValidValue_UptadesGrade()
    {
        var student = new Student("Ali", 85);
        student.SetGrade(95);
        Assert.That(student.Grade, Is.EqualTo(95));
    }

    [Test]
    public void SetGrade_InvalidValues_ThrowsArgumentOutOfRangeException()
    {
        var student = new Student("Bob", 50);
        Assert.Throws<ArgumentException>(() => student.SetGrade(-5));
    }
}