using System;
using System.Linq;
using System.Threading.Tasks;
using KIS.Core.Domain.Models;
using KIS.Core.Services.Contracts;
using KIS.Web.Contracts.Models;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;

namespace KIS.Web.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService teamService;
        private readonly ILeagueService leagueService;

        public TeamController(ITeamService teamService, ILeagueService leagueService)
        {
            this.teamService = teamService;
            this.leagueService = leagueService;
        }

        public async Task<IActionResult> TotalCost()
        {
            var teams = await teamService.GetAllWithTotalCost();
            return View(teams);
        }

        public async Task<IActionResult> Create()
        {
            var leagues = await leagueService.GetAll();
            var result = new TeamEditViewModel
            {
                Leagues = leagues.ToList()
            };

            return View("TeamEdit", result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeamModel team)
        {
            try
            {
                await teamService.Create(team);
            }
            catch (OracleException ex)
            {
                if (ex.Number == 20027)
                {
                    ModelState.AddModelError("", "The name of the team must be unique within the league");
                }
                else
                {
                    ModelState.AddModelError("", "Team creation failed");
                }

                var leagues = await leagueService.GetAll();
                var result = new TeamEditViewModel
                {
                    Leagues = leagues.ToList(),
                    Team = team
                };

                return View("TeamEdit", result);
            }

            return RedirectToAction("TotalCost");
        }

        public async Task<IActionResult> LastYearProfit(string name)
        {
            var profit = await teamService.GetTeamLastYearProfit(name);
            ViewBag.TeamProfit = profit;
            return View("TeamLastYearProfit");
        }
    }
}
