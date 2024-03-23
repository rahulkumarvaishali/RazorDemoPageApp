using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorDemoPageApp.Data;
using RazorDemoPageApp.Models.Domain;

namespace RazorDemoPageApp.Pages.Employees
{
    public class ListModel : PageModel
    {
        private readonly RazorpageDemoDbContext dbContext;
        public List<Employee> Employees { get; set; }

        public ListModel(RazorpageDemoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet()
        {
            Employees = dbContext.Employees.ToList();
        }
    }
}
