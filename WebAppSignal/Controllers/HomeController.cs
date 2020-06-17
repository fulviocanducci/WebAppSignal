using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using WebAppSignal.Hubs;
using WebAppSignal.Models;

namespace WebAppSignal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Client()
        {
            return View();
        }

        [HttpGet]
        [Route("todos")]
        public IActionResult GetTodos()
        {
            return View();
        }

        [HttpGet]
        [Route("todos/add")]
        public IActionResult AddTodos()
        {

            return View();
        }


        [HttpGet]
        [Route("todos/base")]
        public async Task<IActionResult> BaseTodos([FromServices] DbaseContext dbaseContext)
        {
            dbaseContext.Todo.Add(new Todo { Done = true, Description = Guid.NewGuid().ToString() });
            await dbaseContext.SaveChangesAsync();
            return View(await dbaseContext.Todo.CountAsync());
        }
    }
}
