namespace WebApp_Like_Notion.Models;

public class DbInitializer
{
    public static void Initialize(NotesContext context)
    {
        context.Database.EnsureCreated();

        // Look for any notes.
        if (context.Notes.Any())
        {
            return;   // DB has been seeded
        }

        var notes = new Note[]
        {
            new() {Title = "My first note", Header = "",  Body = "It is my first note!"},
            new() {Title = "My second note", Header = "",  Body = "It is my second note!"},
            new() {Title = "My third note", Header = "",  Body = "It is my third note!"},
        };
        foreach (var note in notes)
        {
            context.Notes.Add(note);
        }
        context.SaveChanges();
    }
}