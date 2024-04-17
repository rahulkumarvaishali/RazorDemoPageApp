using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RazorDemoPageApp.Data;
using RazorDemoPageApp.Models.Domain;
using RazorDemoPageApp.Models.ViewModels;

namespace RazorDemoPageApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly RazorpageDemoDbContext dbContext;


        public IndexModel(RazorpageDemoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [BindProperty]
        public AddMesageViewModel AddMesageViewModels { get; set; }
        public void OnGet()
        {
            {
                // Initialization logic for GET requests can be added here if needed.
            }
        }
        public void OnPost()
        {
            var addNewMessages = new MessageFromWeb
            {
                FullName= AddMesageViewModels.FullName,
                EmailAddress = AddMesageViewModels.EmailAddress,
                MobileNumber = AddMesageViewModels.MobileNumber,
                Message = AddMesageViewModels.Message
            };

            dbContext.MessageFromWebs.Add(addNewMessages);
            dbContext.SaveChanges();
            ViewData["Message"] = "Message Saved Sucessfully!";
        }
    }
}
