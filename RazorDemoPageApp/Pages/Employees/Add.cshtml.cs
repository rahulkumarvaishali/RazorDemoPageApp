using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorDemoPageApp.Data;
using RazorDemoPageApp.Models.Domain;
using RazorDemoPageApp.Models.ViewModels;

namespace RazorDemoPageApp.Pages.Employees
{
    public class AddModel : PageModel
    {
        private readonly RazorpageDemoDbContext dbContext;

        public AddModel(RazorpageDemoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [BindProperty]
        public AddEmployeeViewModel AddEmployeeRequest { get; set; }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            //Convert ViewModel to DomainModel
            var employeeDomainModel = new Employee
            {
                Name = AddEmployeeRequest.Name,
                Email = AddEmployeeRequest.Email,
                Salary = AddEmployeeRequest.Salary,
                DateOfBirth = AddEmployeeRequest.DateOfBirth,
                Department = AddEmployeeRequest.Department
            };
            dbContext.Employees.Add(employeeDomainModel);
            dbContext.SaveChanges();
            ViewData["Message"] = "Employee Created Sucessfully!";
        }
    }
}
