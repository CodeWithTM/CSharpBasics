using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorWebApp.Models;

namespace RazorWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly EmployeeDBContext _context;

        [BindProperty]
        public Employee employee { get; set; }

        public List<Employee> employees { get; set; } = new List<Employee>();

        public IndexModel(ILogger<IndexModel> logger, EmployeeDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            employees = _context.Employees.ToList();
        }

        public IActionResult OnPost()
        {

            _context.Employees.Add(employee);

            _context.SaveChanges();

            return RedirectToPage();

        }
    }
}
