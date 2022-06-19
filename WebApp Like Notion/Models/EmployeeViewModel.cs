using System.ComponentModel.DataAnnotations;

namespace WebApp_Like_Notion.Models;

public class EmployeeViewModel  
{  
    [Key]  
    public int EmployeeID { get; set; }  
  
    public string EmployeeName { get; set; }  
  
    public string PhoneNumber { get; set; }  
  
    public string Skill { get; set; }  
  
    public int YearsExperience { get; set; }  
}  