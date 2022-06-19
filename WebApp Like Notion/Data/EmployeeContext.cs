namespace WebApp_Like_Notion.Models;
using Microsoft.EntityFrameworkCore;
public class EmployeeContext : DbContext  
{  
    public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)  
    {
        
    }  
    public DbSet<tblSkill> Skills { get; set; }  
    public DbSet<tblEmployee> Employees { get; set; }  
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<tblSkill>().ToTable("Skill");
        modelBuilder.Entity<tblEmployee>().ToTable("Employee");
    }
}  