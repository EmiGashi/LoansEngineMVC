using LoansEngineMVC.Data;
using LoansEngineMVC.Dtos;
using LoansEngineMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LoansEngineMVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<UsersController> _logger;

        public UsersController(AppDbContext appDbContext, ILogger<UsersController> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _appDbContext.Users.ToListAsync();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiforgeryToken]
        public async Task<IActionResult> Register(AddUserViewModel addUserdto)
        {


            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = addUserdto.FirstName,
                    LastName = addUserdto.LastName,
                    EmailAddress = addUserdto.EmailAddress,
                    Company = addUserdto.Company,
                    Title = addUserdto.Title,
                    Comment = addUserdto.Comment,
                    Webinar = addUserdto.Webinar
                };

                await _appDbContext.Users.AddAsync(user);
                await _appDbContext.SaveChangesAsync();

            } 
            else 
            {
                return RedirectToAction("ErrorRegistering");
            }

            return RedirectToAction("ThankYou");
        }

        [HttpGet]
        public async Task<IActionResult> ThankYou()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUser(Guid id)
        {
            var user = await _appDbContext.Users.SingleOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                var userModel = new UpdateUserViewModel()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    EmailAddress = user.EmailAddress,
                    Company = user.Company,
                    Title = user.Title,
                    Comment = user.Comment,
                    Webinar = user.Webinar
                };

                return View(userModel);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(UpdateUserViewModel model)
        {
            var user = await _appDbContext.Users.FindAsync(model.Id);

            if (user != null)
            {
                if (ModelState.IsValid)
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.EmailAddress = model.EmailAddress;
                    user.Company = model.Company;
                    user.Title = model.Title;
                    user.Comment = model.Comment;
                    user.Webinar = model.Webinar;

                    await _appDbContext.SaveChangesAsync();
                }

                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateUserViewModel model)
        {
            var user = await _appDbContext.Users.FindAsync(model.Id);

            if (user != null)
            {
                _appDbContext.Users.Remove(user);
                await _appDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ErrorRegistering()
        {
            return View();
        }

    }


}
