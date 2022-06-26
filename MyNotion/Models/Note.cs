using System.ComponentModel.DataAnnotations;

namespace WebApp_Like_Notion.Models;

public class Note
{
    [Key]
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string Header { get; set; }
    
    public string Body { get; set; }
    
    public bool IsDeleted { get; set; }
    
    public DateTime DeleteTime { get; set; }
}