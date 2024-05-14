using System.Text.RegularExpressions;
using lab1.Models;

namespace lab1.Services;

public class StudentService : IStudentService
{
    private List<Student> _students;

    public StudentService()
    {
        _students = new List<Student>
        {
            new Student { Surname = "Иванов", Name = "Иван", Group = "571-1", Email = "ivanov@example.com", Number = "+1(111)1111111" },
            new Student { Surname = "Петров", Name = "Петр", Group = "571-2", Email = "petrov@example.com", Number = "+1(234)5678900" },
            new Student { Surname = "Иванов", Name = "Иван", Patronymic = "Иванович", Group = "571-3", Email = "ivanov@example.com", Number = "+1(111)1111111" },
            new Student { Surname = "Петров", Name = "Петр", Patronymic = "Петрович", Group = "571-1", Email = "petrov@example.com", Number = "+1(111)1111112" },
            new Student { Surname = "Сидоров", Name = "Сидор", Patronymic = "Сидорович", Group = "571-2", Email = "sidorov@example.com", Number = "+1(111)1111113" },
            new Student { Surname = "Алексеев", Name = "Алексей", Patronymic = "Алексеевич", Group = "571-3", Email = "alekseev@example.com", Number = "+1(111)1111114" },
            new Student { Surname = "Андреев", Name = "Андрей", Patronymic = "Андреевич", Group = "571-1", Email = "andreev@example.com", Number = "+1(111)1111115" },
            new Student { Surname = "Борисов", Name = "Борис", Patronymic = "Борисович", Group = "571-2", Email = "borisov@example.com", Number = "+1(111)1111116" },
            new Student { Surname = "Васильев", Name = "Василий", Patronymic = "Васильевич", Group = "571-3", Email = "vasilev@example.com", Number = "+1(111)1111117" },
            new Student { Surname = "Григорьев", Name = "Григорий", Patronymic = "Григорьевич", Group = "571-1", Email = "grigorev@example.com", Number = "+1(111)1111118" },
            new Student { Surname = "Дмитриев", Name = "Дмитрий", Patronymic = "Дмитриевич", Group = "571-2", Email = "dmitriev@example.com", Number = "+1(111)1111119" },
            new Student { Surname = "Евгеньев", Name = "Евгений", Patronymic = "Евгеньевич", Group = "571-3", Email = "evgenev@example.com", Number = "+1(111)1111120" },
            new Student { Surname = "Жданов", Name = "Ждан", Patronymic = "Жданович", Group = "571-1", Email = "zhdanov@example.com", Number = "+1(111)1111121" },
            new Student { Surname = "Зайцев", Name = "Зайцев", Patronymic = "Зайцевич", Group = "571-2", Email = "zaytsev@example.com", Number = "+1(111)1111122" },
            new Student { Surname = "Ильин", Name = "Илья", Patronymic = "Ильич", Group = "571-3", Email = "ilin@example.com", Number = "+1(111)1111123" },
            new Student { Surname = "Кузнецов", Name = "Кузнецов", Patronymic = "Кузнецович", Group = "571-1", Email = "kuznetsov@example.com", Number = "+1(111)1111124" },
            new Student { Surname = "Лебедев", Name = "Лебедев", Patronymic = "Лебедевич", Group = "571-2", Email = "lebedev@example.com", Number = "+1(111)1111125" },
            new Student { Surname = "Макаров", Name = "Макаров", Patronymic = "Макарович", Group = "571-3", Email = "makarov@example.com", Number = "+1(111)1111126" },
            new Student { Surname = "Николаев", Name = "Николай", Patronymic = "Николаевич", Group = "571-1", Email = "nikolaev@example.com", Number = "+1(111)1111127" }
        };
    }

    public List<Student> GetAll()
    {
        return _students;
    }

    public bool Add(Student student)
    {
        if (_students.Any(s => s.Name == student.Name && s.Surname == student.Surname && s.Group == student.Group))
        {
            return false;
        }

        student.Number = FormatPhoneNumber(student.Number);
        _students.Add(student);
        return true;
    }

    public List<string> GetAllGroups() 
    {
        return _students.Select(s => s.Group).Distinct().ToList();
    }

    public List<Student> GetStudentsByGroup(string group)
    {
        return _students.Where(s => s.Group == group).ToList();
    }

    public string FormatPhoneNumber(string phoneNumber)
    {
        string cleanedPhoneNumber = Regex.Replace(phoneNumber, @"\D", "");

        if (cleanedPhoneNumber.Length == 11)
        {
            cleanedPhoneNumber = cleanedPhoneNumber.Substring(1);
        }

        return $"+7({cleanedPhoneNumber.Substring(0, 3)}){cleanedPhoneNumber.Substring(3)}";
    }
}