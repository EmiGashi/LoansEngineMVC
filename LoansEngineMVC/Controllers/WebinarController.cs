using LoansEngineMVC.Data;
using Microsoft.AspNetCore.Mvc;

namespace LoansEngineMVC.Controllers
{
    public class WebinarController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public WebinarController(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            //var webinars = _appDbContext.
            return View();
        }
    }
}
