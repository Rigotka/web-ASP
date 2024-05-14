using System.ComponentModel.DataAnnotations;

namespace lab1.Models;

public class Student
{
    [Required(ErrorMessage = "Введите фамилию.")]
    [RegularExpression(@"^[А-Я][а-я]*$", ErrorMessage = "Фамилия должна содержать русские буквы и начинаться с заглавной буквы.")]
    public string Surname { get; set; }

    [Required(ErrorMessage = "Введите имя.")]
    [RegularExpression(@"^[А-Я][а-я]*$", ErrorMessage = "Имя должно содержать русские буквы и начинаться с заглавной буквы.")]
    public string Name { get; set; }

    [RegularExpression(@"^[А-Я][а-я]*$", ErrorMessage = "Отчество должно содержать русские символы и начинаться с заглавной буквы")]
    public string? Patronymic { get; set; }

    [Required(ErrorMessage = "Введите группу.")]
    [RegularExpression(@"^\d+-\d+[M]?$", ErrorMessage = "Группа должна быть в формате '***-*' или '***-*М'.")]
    public string Group { get; set; }

    [Required(ErrorMessage = "Введите почту.")]
    [RegularExpression(@"([a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+)", ErrorMessage = "Неверный формат электронной почты.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Введите номер телефона.")]
    [RegularExpression(@"^(\+7|8)?[\s\-]?\(?\d{3}\)?[\s\-]?\d{3}[\s\-]?\d{2}[\s\-]?\d{2}$", ErrorMessage = "Неверный формат телефона.")]
    public string Number { get; set; }
}

