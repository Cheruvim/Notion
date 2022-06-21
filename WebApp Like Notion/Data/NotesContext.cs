using Microsoft.EntityFrameworkCore;

namespace WebApp_Like_Notion.Models;

public class NotesContext : DbContext  
{
    public NotesContext(DbContextOptions<NotesContext> options) : base(options)  
    {
        
    }  
    public DbSet<Note> Notes { get; set; }  
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Note>().ToTable("Notes");
    }
}