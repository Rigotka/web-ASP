using lab1.Models;

namespace lab1.Services;

public interface IStudentService
{
    public List<Student> GetAll();
    public bool Add(Student student);
    public List<string> GetAllGroups();
    public List<Student> GetStudentsByGroup(string group);
}