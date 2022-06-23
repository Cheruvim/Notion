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
        var note = _dbContext.Notes.FirstOrDefault(n => n.Id == id);
        if(note != null)
            return View(note);
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
        var elemForDelete = _dbContext.Notes.FirstOrDefault(n => n.Id == id);
        if (elemForDelete != null)
        {
            elemForDelete.IsDeleted = true;
            elemForDelete.DeleteTime = DateTime.Now;
        }
        _dbContext.SaveChanges();
        
        return View("Index", GetNotesList());
    }

    private ViewModel GetNotesList()
    {
        ViewModel mymodel = new ViewModel();
        mymodel.Notes = _dbContext.Notes.Where(n => !n.IsDeleted).ToList();
        mymodel.Note = new Note();
        return mymodel;
    }
}