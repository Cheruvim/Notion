﻿using System.ComponentModel.DataAnnotations;

namespace WebApp_Like_Notion.Models;

public class tblEmployee  
{  
    [Key]  
    public int EmployeeID { get; set; }  
  
    [Display(Name = "Employee Name")]  
    public string EmployeeName { get; set; }  
  
    [Display(Name = "Contact Number")]  
    public string PhoneNumber { get; set; }  
  
    [Display(Name = "Your Skill")]  
    public int SkillID { get; set; }  
  
    [Display(Name = "Years of Experience")]  
    public int YearsExperience { get; set; }  
}  