using ModLearn.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ModLearn.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;

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
        public async Task<ActionResult> TeamOf(string id, string name)
        {
            if (String.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index");
            }

            Team team = await repository.GetTeamByNameAsync(id) ?? new Team();

            return View(team);
        }

        [HttpGet]
        public ActionResult AddPlayer()
        {
            //  Initializes a new instance of the SelectList class by using the specified items for the list, the data value field, and the data text field.
            SelectList teams = new SelectList(repository.context.Teams, "Id", "Name");

            ViewBag.Teams = teams;

            return View();
        }

        [HttpPost]
        public ActionResult AddPlayer(Player player)
        {
            if (player != null)
            {
                repository.AddPlayer(player);
                repository.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}