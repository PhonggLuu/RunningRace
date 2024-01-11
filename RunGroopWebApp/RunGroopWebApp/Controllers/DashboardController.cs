using Microsoft.AspNetCore.Mvc;
using RunGroopWebApp.Data;
using RunGroopWebApp.Interfaces;
using RunGroopWebApp.ViewModels;

namespace RunGroopWebApp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardController(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        public async Task<IActionResult> Index()
        {
            var userRaces = await _dashboardRepository.GettAllUserRaces();
            var userClubs = await _dashboardRepository.GetAllUserClubs();
            var dashboardVM = new DashboardViewModel
            {
                Clubs = userClubs,
                Races = userRaces
            };
            return View(dashboardVM);
        }
    }
}
