using Microsoft.AspNetCore.Mvc;
using WebApp_Like_Notion.Models;

namespace WebApp_Like_Notion.Controllers;

public class HomeController : Controller
{
    private readonly EmployeeContext _dbContext;  

    public HomeController(EmployeeContext dbContext)  
    {  
        _dbContext = dbContext;  
    }  
    
    public IActionResult Index()
    {
        var _emplst = _dbContext.Employees.  
            Join(_dbContext.Skills, e => e.SkillID, s => s.SkillID,  
                (e, s) => new EmployeeViewModel  
                { EmployeeID = e.EmployeeID, EmployeeName = e.EmployeeName,  
                    PhoneNumber = e.PhoneNumber, Skill = s.Title,  
                    YearsExperience = e.YearsExperience }).ToList();  
        IList<EmployeeViewModel> emplst  = _emplst;  
        
        ViewBag.Title ="Доброе утро";
        return View(emplst);
    }

    [HttpGet]
    public ViewResult RsvpForm()
    {
        return View();
    }

    [HttpPost]
    public ViewResult RsvpForm(GuestResponse guest)
    {
        if (ModelState.IsValid)
            // Нужно отправить данные нового гостя по электронной почте 
            // организатору вечеринки.
            return View("Thanks", guest);
        return View();
    }
}