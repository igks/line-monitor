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

        public IActionResult Get()
        {
            var graph = _context.Graph.Find(1);
            return Ok(graph);
        }
    }
}