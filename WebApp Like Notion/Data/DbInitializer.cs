namespace WebApp_Like_Notion.Models;

public class DbInitializer
{
    public static void Initialize(EmployeeContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Employees.Any())
            {
                return;   // DB has been seeded
            }

            var employees = new tblEmployee[]
            {
                new() {EmployeeName = "hi1", PhoneNumber = "2131311", YearsExperience = 5, SkillID = 1},
                new() {EmployeeName = "hi2", PhoneNumber = "2131312", YearsExperience = 2, SkillID = 2},
                new() {EmployeeName = "hi3", PhoneNumber = "2131313", YearsExperience = 4, SkillID = 1},
                new() {EmployeeName = "hi4", PhoneNumber = "2131314", YearsExperience = 7, SkillID = 2},

            };
            foreach (var employee in employees)
            {
                context.Employees.Add(employee);
            }
            context.SaveChanges();

            var skills = new tblSkill[]
            {
            new() {Title = "Hier"},
            new() {Title = "Hier#2"}

            };
            foreach (var skill in skills)
            {
                context.Skills.Add(skill);
            }
            context.SaveChanges();
        }
}