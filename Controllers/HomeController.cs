using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using lab1.Models;

namespace lab1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpGet]
    public IActionResult Task3()
    {
        var viewModel = new Task3ViewModel
        {
            N = 1,
            M = 1, 
            ResultMessage = ""
        };

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Task3(Task3ViewModel viewModel)
    {
        if (viewModel.N == 0 || viewModel.M == 0)
        {
            viewModel.ResultMessage = "Ошибка: N и M не может быть равны нулю.";
        }
        else
        {
            bool isMultiple = viewModel.M % viewModel.N == 0;
            viewModel.ResultMessage = isMultiple ? "Число N кратно числу M" : "Число N не кратно числу M";
        }

        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Task4()
    {
        var viewModel = new Task4ViewModel
        {
            Text = "",
            firstIndex = -1,
            lastIndex = -1
        };

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Task4(Task4ViewModel viewModel)
    {
        string text = viewModel.Text;
        if(string.IsNullOrEmpty(text))
        {
            viewModel.ResultMessage = "Ошибка! Введите предложение.";
            return View(viewModel);
        }

        string lowerText = text.ToLower();
        int firstIndex = lowerText.IndexOf('я');
        int lastIndex = lowerText.LastIndexOf('я');
        if (firstIndex == -1)
        {
            viewModel.ResultMessage = "В предложении нет буквы 'Я'.";
        }
        else
        {
            viewModel.ResultMessage = $"<p>Порядковый номер первой буквы 'Я': {firstIndex + 1}</p>" +
                                      $"<p class='mb-0'>Порядковый номер последней буквы 'Я': {lastIndex + 1}</p>";
        }

        return View(viewModel);
    }
} 

