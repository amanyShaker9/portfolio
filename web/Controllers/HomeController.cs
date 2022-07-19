using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using web.ViewModels;

namespace web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork<Owner> _owner;
        private readonly IUnitOfWork<PortfolioItem> _portfolio;

        public HomeController(IUnitOfWork<Owner> Owner, IUnitOfWork<PortfolioItem> Portfolio)
        {
            _owner = Owner;
            _portfolio = Portfolio;
        }
        public IActionResult Index()
        {
            var homeviewmodel = new HomeViewModel
            {
                Owner = _owner.Entity.GetAll().First(),
                PortfolioItems  = _portfolio.Entity.GetAll().ToList()
            };
            return View(homeviewmodel);
            
        }
    }
}
