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

        public IActionResult Index(string id)
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
            if (id != null)
            {
                employee = _context.Employee.FirstOrDefault(x => x.ProcessName == id && x.IsCurrent == true);
                if (employee != null)
                {
                    ViewBag.Employee = employee;
                }
            }

            var employeeList = _context.Employee.Where(x => x.IsCurrent == true).ToList();
            ViewBag.EmpList = employeeList;

            return View();
        }

        public IActionResult Chart()
        {
            return View();
        }
    }
}