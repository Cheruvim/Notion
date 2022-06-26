using System.ComponentModel.DataAnnotations;

namespace WebApp_Like_Notion.Models;

public class Settings
{
    [Required(ErrorMessage="Пожалуйста, введите свое имя")]
    public string Name { get; set; }

    [Required(ErrorMessage="Пожалуйста, введите email")]
    [RegularExpression(".+\\@.+\\..+", ErrorMessage="Вы ввели некорректный email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Пожалуйста, введите телефон")]
    public string Phone { get; set; }

    [Required(ErrorMessage = "Пожалуйста, укажите, примите ли участие в вечеринке")]
    public bool? WillAttend { get; set; }
}
