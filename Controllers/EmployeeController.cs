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

    [HttpGet]
    public IActionResult Index()
    {
        var employees = _context.Employee.ToList();
        ViewBag.Employee = employees;

        var Action = TempData["action"];
        switch (Action)
        {
            case "create":
                ViewBag.Action = "create";
                break;
            case "update":
                ViewBag.Action = "update";
                break;
            case "delete":
                ViewBag.Action = "delete";
                break;
            default:
                ViewBag.Action = "";
                break;
        }

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
        var isImageUpdated = false;
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
            isImageUpdated = true;
        }

        if (employeeDto.Id > 0)
        {
            var currentEmployee = _context.Employee.FirstOrDefault(x => x.Id == employeeDto.Id);
            if (currentEmployee != null)
            {
                if (isImageUpdated)
                {
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img");
                    var existingImagePath = Path.Combine(pathToSave, currentEmployee.ImageUrl);
                    if (System.IO.File.Exists(existingImagePath))
                    {
                        System.IO.File.Delete(existingImagePath);
                    }
                }

                currentEmployee.Code = employeeDto.Code;
                currentEmployee.Name = employeeDto.Name;
                currentEmployee.BatchId = employeeDto.BatchId;
                currentEmployee.ProductId = employeeDto.ProductId;
                currentEmployee.ImageUrl = imageUrl;

                _context.SaveChanges();
                TempData["action"] = "update";
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
            TempData["action"] = "create";
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

        var fileName = employee.ImageUrl;
        if (fileName != "default.jpg")
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img");
            var fullPath = Path.Combine(filePath, fileName);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
        }

        _context.Employee.Remove(employee);
        _context.SaveChanges();

        return Ok(new
        {
            message = "success"
        });
    }

    [HttpGet]
    public IActionResult RedirectRequest()
    {
        TempData["action"] = "delete";
        return RedirectToAction("Index", "Employee");
    }
}
