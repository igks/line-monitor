using LineMonitoring.Models;
using Microsoft.AspNetCore.Mvc;

namespace LiMo.Controllers
{
    public class DisplayController : Controller
    {
        private readonly DBsContext _context;

        public DisplayController(DBsContext context)
        {
            _context = context;
        }

        public IActionResult Index(string id, string process)
        {
            var employee = new Employee()
            {
                Id = 1,
                Name = "Employee Name",
                BatchId = "00000",
                ProductId = "00000",
                ImageUrl = "default.jpg"
            };

            ViewBag.Employee = employee;
            ViewBag.Process = process != null ? process : "Process Name";

            if (id != null)
            {
                employee = _context.Employee.FirstOrDefault(x => x.Code == id);
                if (employee != null)
                {
                    ViewBag.Employee = employee;
                }
            }

            return View();
        }
    }
}