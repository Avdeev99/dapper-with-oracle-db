using System.Threading.Tasks;
using KIS.Core.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace KIS.Web.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerService playerService;

        public PlayerController(IPlayerService playerService)
        {
            this.playerService = playerService;
        }

        public async Task<IActionResult> Team(long id)
        {
            var players = await playerService.GetByTeamId(id);

            return View("PlayersByTeam", players);
        }
    }
}
