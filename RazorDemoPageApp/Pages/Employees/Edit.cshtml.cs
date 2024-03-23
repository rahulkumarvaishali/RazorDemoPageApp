using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorDemoPageApp.Data;
using RazorDemoPageApp.Models.Domain;
using RazorDemoPageApp.Models.ViewModels;

namespace RazorDemoPageApp.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly RazorpageDemoDbContext dbContext;
        [BindProperty]
        public EditEmployeeViewModel EditEmployeeViewModel { get; set; }

        public EditModel(RazorpageDemoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet(Guid id)
        {
            var employee = dbContext.Employees.Find(id);
            if (employee != null)
            {
                //Convert domain model to view model
                EditEmployeeViewModel = new EditEmployeeViewModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    DateOfBirth = employee.DateOfBirth,
                    Salary = employee.Salary,
                    Department = employee.Department
                };
            }
        }
        public void OnPostUpdate()
        {
            if (EditEmployeeViewModel != null)
            {
                var existingEmployee = dbContext.Employees.Find(EditEmployeeViewModel.Id);
                if (existingEmployee != null)
                {
                    //Convert View model to Domain model

                    existingEmployee.Name = EditEmployeeViewModel.Name;
                    existingEmployee.Email = EditEmployeeViewModel.Email;
                    existingEmployee.DateOfBirth = EditEmployeeViewModel.DateOfBirth;
                    existingEmployee.Salary = EditEmployeeViewModel.Salary;
                    existingEmployee.Department = EditEmployeeViewModel.Department;
                    dbContext.SaveChanges();
                    ViewData["Message"] = "Employee Updated Sucessfully";
                }

            }

        }
        public IActionResult OnPostDelete()
        {
            var existingEmployee = dbContext.Employees.Find(EditEmployeeViewModel.Id);
            if(existingEmployee != null)
            {
                dbContext.Employees.Remove(existingEmployee);
                dbContext.SaveChanges();
                return RedirectToPage("/Employees/List");
            }
            return Page();
        }
    }
}
