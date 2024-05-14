using lab1.Models;
using lab1.Services;
using Microsoft.AspNetCore.Mvc;

namespace lab1.Controllers;

public class HomeController : Controller
{
    private readonly IStudentService _studentService;

    public HomeController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    public IActionResult Leacturer()
    {
        var viewModels = new List<LeacturerViewModel>();

        var groups = _studentService.GetAllGroups();
        foreach(var group in groups)
        {
            var students = _studentService.GetStudentsByGroup(group);
            var viewModel = new LeacturerViewModel
            {
                Students = students,
            };
            viewModels.Add(viewModel);
        }


        ViewData["Groups"] = groups;
        return View(viewModels);
    }


    [HttpGet]
    public IActionResult Index(string group = "571-1")
    {
        var viewModel = CreateStudentsViewModel(group, new Student());
        return View(viewModel);
    }

    [HttpPost]
    public ActionResult Add(Student student, string previousGroup)
    {
        if(student.Surname == "Мурзин" && student.Name == "Евгений" && student.Patronymic == "Сергеевич")
        {
            return RedirectToAction("Leacturer");
        }

        if (ModelState.IsValid)
        {
            if(_studentService.Add(student))
            {
                var group = student.Group;
                return RedirectToAction("Index", new { group = group });
            }
            TempData["Message"] = "Студент с такими данными уже существует.";
        }

        var viewModel = CreateStudentsViewModel(previousGroup, student);
        return View("Index", viewModel);
    }

    public StudentsViewModel CreateStudentsViewModel(string group, Student student)
    {
        ViewData["Groups"] = _studentService.GetAllGroups();

        var students = _studentService.GetStudentsByGroup(group);
        var viewModel = new StudentsViewModel
        {
            Students = students,
            NewStudent = student,
            Group = group

        };
        return viewModel;
    }
} 

