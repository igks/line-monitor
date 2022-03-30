using LineMonitoring.Models;
using Microsoft.AspNetCore.Mvc;

namespace LiMo.Controllers
{
    public class GraphController : Controller
    {
        private readonly DBsContext _context;

        public GraphController(DBsContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var graph = _context.Graph.Find(1);
            ViewBag.Graph = graph;
            ViewBag.IsSuccess = TempData["IsSuccess"] ?? false;

            return View();
        }
        public IActionResult Get()
        {
            var graph = _context.Graph.Find(1);
            return Ok(graph);
        }

        [HttpPost]
        public IActionResult Update([FromBody] Graph dto)
        {
            var graph = _context.Graph.Find(1);
            graph.Title = dto.Title;
            graph.Line1 = dto.Line1;
            graph.Line2 = dto.Line2;
            graph.Data1 = dto.Data1;
            graph.Data2 = dto.Data2;
            graph.Axis = dto.Axis;

            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IActionResult RedirectRequest()
        {
            TempData["IsSuccess"] = true;
            return RedirectToAction("Index", "Graph");
        }
    }
}