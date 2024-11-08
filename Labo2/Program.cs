using System;

public enum EducationType
{
    Specialist,
    Bachelor,
    SecondEducation
}

public class Person // создание самого класса
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }

    public Person(string Name, string lastName, DateTime birthDate)
    {
        Name = Name;
        LastName = lastName;
        BirthDate = birthDate;
    }

    public Person()
    {
        Name = "Иван";
        LastName = "Иванов";
        BirthDate = new DateTime(2004, 2, 6);
    }
}

public class Exam
{
    private string _subject;// частные поля класса Exam
    private int _grade;// оценка
    private DateTime _date;

    public Exam(string subject, int grade, DateTime date)
    {
        Subject = subject;
        Grade = grade;
        Date = date;
    }

    public Exam()
    {
        Subject = "Математика";
        Grade = 5;
        Date = DateTime.Now;
    }

    public string Subject
    {
        get { return _subject; }
        set { _subject = value; }
    }

    public int Grade
    {
        get { return _grade; }
        set { _grade = value; }
    }

    public DateTime Date
    {
        get { return _date; }
        set { _date = value; }
    }

    public string ToFullString()// строка со всеми значениями (полями) класса + список экзамена 
    {
        return $"Предмет: {Subject}, Оценка: {Grade}, Дата: {Date}";
    }
}

public class Student
{
    private Person _person;
    private EducationType _education;
    private int _groupNumber;
    private Exam[] _exams;

    public Student(Person person, EducationType education, int groupNumber)
    {
        _person = person;
        _education = education;
        _groupNumber = groupNumber;
        _exams = new Exam[0];
    }

    public Student()
    {
        _person = new Person();
        _education = EducationType.Bachelor;
        _groupNumber = 21;
        _exams = new Exam[0];
    }

    public Person Person
    {
        get { return _person; }
        set { _person = value; }
    }

    public EducationType Education
    {
        get { return _education; }
        set { _education = value; }
    }

    public int GroupNumber
    {
        get { return _groupNumber; }
        set { _groupNumber = value; }
    }

    public Exam[] Exams
    {
        get { return _exams; }
        set { _exams = value; }
    }

    public void AddExams(params Exam[] exams)
    {
        Array.Resize(ref _exams, _exams.Length + exams.Length); // работа с массивом, позволяет менять размер массива 
        Array.Copy(exams, 0, _exams, _exams.Length - exams.Length, exams.Length);
    }

    public string ToFullString() //формирование строки со всеми значениями полей, + СЭлем
    {
        string examString = "";
        if (_exams.Length > 0)
        {
            examString = "Экзамены:\n";
            foreach (Exam exam in _exams) //позволяет перебирать элементы коллекции (например, массива, списка, словаря) по одному, не зная заранее их количество. 
            {
                examString += $"{exam.ToFullString()}\n";
            }
        }
        return $"Имя: {_person.Name} {_person.LastName}, Дата рождения: {_person.BirthDate}, Форма обучения: {_education}, Номер группы: {_groupNumber}, {examString}";
    }

    public string ToShortString()
    {
        return $"Имя: {_person.Name} {_person.LastName}, Дата рождения: {_person.BirthDate}, Форма обучения: {_education}, Номер группы: {_groupNumber}";
    }
}

public class MainCl// ПАТАМУ ЧТА СОВПАДАЕТ! НЕ МЕНЯТЬ 
{
    public static void Main(string[] args)
    {
        Student student1 = new Student();
        Console.WriteLine(student1.ToShortString());

        Student student2 = new Student(new Person("Петр", "Петров", new DateTime(2004, 2,6)), EducationType.Specialist, 21);
        Console.WriteLine(student2.ToFullString());

        student2.AddExams(
            new Exam("Программирование", 3, new DateTime(2023, 6, 16)),
            new Exam("Бухгалтерский учет", 4, new DateTime(2023, 6, 17))
        );
        Console.WriteLine(student2.ToFullString());
    }
}
