using Microsoft.AspNetCore.Mvc;
using LineMonitoring.Models;

namespace LineMonitoring.Controllers;

public class EmployeeController : Controller
{
    private readonly DBsContext _context;

    public EmployeeController(DBsContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var employees = _context.Employee.ToList();
        ViewBag.Employee = employees;

        return View();
    }

    [HttpGet]
    public IActionResult Get(int id)
    {
        var employee = _context.Employee.FirstOrDefault(x => x.Id == id);
        if (employee == null)
            return StatusCode(404, new
            {
                message = "not found!"
            });

        return Ok(employee);
    }

    [HttpPost]
    public IActionResult AddUpdate(Employee employeeDto)
    {
        string imageUrl = (employeeDto.Id != null && employeeDto.Id > 0) ? employeeDto.ImageUrl : "default.jpg";
        if (employeeDto.Image != null)
        {
            var file = employeeDto.Image;
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img");
            var fileName = DateTime.Now.ToString("hhmmss_ddmmyy_") + file.FileName;
            var fullPath = Path.Combine(pathToSave, fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            imageUrl = fileName;
        }

        if (employeeDto.Id > 0)
        {
            var currentEmployee = _context.Employee.FirstOrDefault(x => x.Id == employeeDto.Id);
            if (currentEmployee != null)
            {
                currentEmployee.Code = employeeDto.Code;
                currentEmployee.Name = employeeDto.Name;
                currentEmployee.BatchId = employeeDto.BatchId;
                currentEmployee.ProductId = employeeDto.ProductId;
                currentEmployee.ImageUrl = imageUrl;

                _context.SaveChanges();
            }
        }
        else
        {
            var employee = new Employee()
            {
                Code = employeeDto.Code,
                Name = employeeDto.Name,
                BatchId = employeeDto.BatchId,
                ProductId = employeeDto.ProductId,
                ImageUrl = imageUrl
            };

            _context.Employee.Add(employee);
            _context.SaveChanges();
        }

        return RedirectToAction("Index", "Employee");
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var employee = _context.Employee.FirstOrDefault(x => x.Id == id);
        if (employee == null)
            return StatusCode(404, new
            {
                message = "Not found!"
            });

        _context.Employee.Remove(employee);
        _context.SaveChanges();
        return Ok(new
        {
            message = "success"
        });
    }
}
