using Microsoft.AspNetCore.Mvc;
using WebApp_Like_Notion.Models;

namespace WebApp_Like_Notion.Controllers;

public class HomeController : Controller
{
    private readonly NotesContext _dbContext;  

    public HomeController(NotesContext dbContext)  
    {  
        _dbContext = dbContext;  
    }  
    
    public IActionResult Index()
    {
        ViewBag.Title ="Первая страница";
        return View(GetNotesList());
    }

    [HttpGet]
    public ViewResult AddNote()
    {
        return View();
    }

    [HttpPost]
    public ViewResult AddNote(Note note)
    {
        _dbContext.Add(note);
        _dbContext.SaveChanges();
        
        return View("Index", GetNotesList());
    }
    
    [HttpGet]
    public ViewResult EditNote(int id)
    {
        var note = _dbContext.Notes.Where(n => n.Id == id).FirstOrDefault();
        if(note != null)
            return View();
        else
            return View("Index", GetNotesList());
    }

    [HttpPost]
    public ViewResult EditNote(Note note)
    {
        _dbContext.Update(note);
        _dbContext.SaveChanges();
        
        return View("Index", GetNotesList());
    }
    
    [HttpGet]
    public ViewResult DeleteNote(int id)
    {
        var elemForDelete = _dbContext.Notes.Where(n => n.Id == id).FirstOrDefault();
        if (elemForDelete != null)
        {
            elemForDelete.IsDeleted = true;
            elemForDelete.DeleteTime = DateTime.Now;
        }
        _dbContext.SaveChanges();
        
        return View("Index", GetNotesList());
    }

    private List<Note> GetNotesList()
    {
        return _dbContext.Notes.Where(n => !n.IsDeleted).ToList();
    }
}