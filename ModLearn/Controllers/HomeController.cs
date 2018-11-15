using ModLearn.Models;
using System;
using System.Collections.Generic;
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

        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            List<Team> teams = await repository.getAllTeamsAsync();


            return View(teams);
        }

        public async System.Threading.Tasks.Task<ActionResult> Players()
        {
            IEnumerable<Player> players = await repository.getAllPlayersAsync();

            return View(players);
        }



    }
}