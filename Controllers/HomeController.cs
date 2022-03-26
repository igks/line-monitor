using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LineMonitoring.Models;
using System.Net.Http.Headers;

namespace LineMonitoring.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DBsContext _context;

    public HomeController(ILogger<HomeController> logger, DBsContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var employees = _context.Employee.ToList();
        ViewBag.Employee = employees;

        return View();
    }

    public JsonResult Get(int id)
    {
        var employee = _context.Employee.FirstOrDefault(x => x.Id == id);
        if (employee == null)
            return Json(new
            {
                message = "not found!"
            });

        return Json(employee);
    }

    public IActionResult AddUpdate(Employee employeeDto)
    {
        string imageUrl = employeeDto.Id > 0 ? employeeDto.ImageUrl : "default.jpg";
        if (employeeDto.Image != null)
        {
            var file = employeeDto.Image;
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img");
            var fileName = DateTime.Now.ToString("hhmmss_ddmmyy_") + ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
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

        return RedirectToAction("Index", "Home");
    }

    public JsonResult Delete(int id)
    {
        var employee = _context.Employee.FirstOrDefault(x => x.Id == id);
        if (employee == null)
            return Json(new
            {
                message = "not found!"
            });

        _context.Employee.Remove(employee);
        _context.SaveChanges();
        return Json(new
        {
            message = "success"
        });
    }

    public IActionResult Chart()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
