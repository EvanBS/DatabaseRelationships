using ModLearn.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModLearn.Controllers
{
    public class HomeController : Controller
    {
        IRepository repository;

        public HomeController(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ActionResult> Index()
        {
            List<Team> teams = await repository.getAllTeamsAsync();


            return View(teams);
        }

        public async Task<ActionResult> Players()
        {
            IEnumerable<Player> players = await repository.getAllPlayersAsync();

            return View(players);
        }

        [HttpGet]
        public async Task<ActionResult> TeamOf(string Name)
        {
            if (String.IsNullOrEmpty(Name))
            {
                return RedirectToAction("Index");
            }

            Team team = await repository.GetTeamByNameAsync(Name) ?? new Team();

            return View(team);
        }



    }
}