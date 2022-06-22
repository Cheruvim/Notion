using Microsoft.AspNetCore.Mvc;
using WebApp_Like_Notion.Models;

namespace WebApp_Like_Notion.Controllers;

public class DeletedElemsController : Controller
{
    private readonly NotesContext _dbContext;  

    public DeletedElemsController(NotesContext dbContext)  
    {  
        _dbContext = dbContext;  
    }  
    public IActionResult Index()
    {
        ViewBag.Title ="Первая страница";
        return View(GetNotesList());
    }

    [HttpGet]
    public ViewResult RestoreNote(int id)
    {
        var note = _dbContext.Notes.FirstOrDefault(n => n.Id == id);
        note.IsDeleted = false;
        _dbContext.SaveChanges();
        return View("Index", GetNotesList());
    }
    
    private List<Note> GetNotesList()
    {
        return _dbContext.Notes.Where(n => n.IsDeleted).OrderBy(n => n.DeleteTime).ToList();
    }
}