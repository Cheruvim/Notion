using System.ComponentModel.DataAnnotations;

namespace WebApp_Like_Notion.Models;

public class tblSkill  
{  
    [Key]  
    public int SkillID { get; set; }  
  
    [Display(Name = "Type of Skill")]  
    public string Title { get; set; }  
} 