using System;

public enum Education
{
    Specialist,
    Bachelor,
    SecondEducation
}

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }

    public Person(string firstName, string lastName, DateTime birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}, born {BirthDate.ToShortDateString()}";
    }
}

public class Exam
{
    public string SubjectName { get; set; }  
    public int Grade { get; set; }          
    public DateTime ExamDate { get; set; }  

    public Exam(string subjectName, int grade, DateTime examDate)
    {
        SubjectName = subjectName;
        Grade = grade;
        ExamDate = examDate;
    }


    public Exam() : this("Unknown", 0, DateTime.Now) { }

    public string ToFullString()
    {
        return $"Subject: {SubjectName}, Grade: {Grade}, Date: {ExamDate.ToShortDateString()}";
    }
}


public class Student
{
    private Person person;
    private Education education;
    private int groupNumber;
    private Exam[] exams;

    public Student(Person person, Education education, int groupNumber)
    {
        this.person = person;
        this.education = education;
        this.groupNumber = groupNumber;
        this.exams = Array.Empty<Exam>();
    }


    public Student() : this(new Person("Vladislav", "Gulyaev", new DateTime(2003, 06, 18)), Education.Bachelor, 0) { }


    public Person Person
    {
        get { return person; }
        set { person = value; }
    }

    public Education Education
    {
        get { return education; }
        set { education = value; }
    }

    public int GroupNumber
    {
        get { return groupNumber; }
        set { groupNumber = value; }
    }

    public Exam[] Exams
    {
        get { return exams; }
        set { exams = value; }
    }

    public double AverageGrade
    {
        get
        {
            if (exams == null || exams.Length == 0)
                return 0;

            double sum = 0;
            foreach (var exam in exams)
            {
                sum += exam.Grade;
            }
            return sum / exams.Length;
        }
    }

    public void AddExams(params Exam[] newExams)
    {
        if (newExams == null || newExams.Length == 0)
            return;

        int oldLength = exams?.Length ?? 0;
        Array.Resize(ref exams, oldLength + newExams.Length);
        Array.Copy(newExams, 0, exams, oldLength, newExams.Length);
    }

    public string ToFullString()
    {
        string examsInfo = "Exams:\n";
        if (exams != null && exams.Length > 0)
        {
            foreach (var exam in exams)
            {
                examsInfo += exam.ToFullString() + "\n";
            }
        }
        else
        {
            examsInfo += "No exams\n";
        }

        return $"Student: {person}\n" +
               $"Education: {education}\n" +
               $"Group: {groupNumber}\n" +
               $"Average Grade: {AverageGrade:F2}\n" +
               examsInfo;
    }

    public string ToShortString()
    {
        return $"Student: {person}\n" +
               $"Education: {education}\n" +
               $"Group: {groupNumber}\n" +
               $"Average Grade: {AverageGrade:F2}";
    }
}

class Program
{
    static void Main()
    {
        Student student = new Student();
        Console.WriteLine("Initial student data:");
        Console.WriteLine(student.ToShortString());
        Console.WriteLine();

        student.Person = new Person("Griha", "Pomeshik", new DateTime(1881, 5, 15));
        student.Education = Education.Specialist;
        student.GroupNumber = 12;
        Console.WriteLine("After setting properties:");
        Console.WriteLine(student.ToFullString());
        Console.WriteLine();

        student.AddExams(
            new Exam("Mathematics", 5, new DateTime(2023, 6, 10)),
            new Exam("Physics", 4, new DateTime(2023, 6, 15)),
            new Exam("Programming", 5, new DateTime(2023, 6, 20))
        );
        Console.WriteLine("After adding exams:");
        Console.WriteLine(student.ToFullString());
    }
}